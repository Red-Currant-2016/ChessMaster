namespace ChessMaster2017.Engine
{
    using System;
    using System.Collections.Generic;
    using ChessMaster2017.Engine.Enums;
    using ChessMaster2017.Engine.Contracts;

    public class BoardManager : IBoardManger
    {
        private const int BOARD_SIZE = 8;
        private const int TOTAL_CHESS_PIECE_COUNT = 32;

        public IChessPiece[,] chessBoard;
        public IChessPiece selectedChessPiece; // Contains a copy of a single chessBoard cell.

        private EnumChessPieceColor playerTurn;

        private List<IChessPiece> chessPiecePrefab; // Used to create all the chess pieces object and set there initial position.
        private List<IChessPiece> activeChessPieces;
        private List<IChessPiece> capturedChessPieces;

        private bool[,] highlightChessPieceMoves = new bool[BOARD_SIZE, BOARD_SIZE];
        private bool checkMate;

        public BoardManager()
        {
            this.chessBoard = new IChessPiece[BOARD_SIZE, BOARD_SIZE];
            this.chessPiecePrefab = new List<IChessPiece>(TOTAL_CHESS_PIECE_COUNT);

            InitializeChessPieces();

            SpawnAllChessPieces();

            playerTurn = EnumChessPieceColor.White;
            selectedChessPiece = null;
            checkMate = false;

            capturedChessPieces = new List<IChessPiece>();
        }

        public void changePlayerTurn()
        {
            if (playerTurn == EnumChessPieceColor.White)
            {
                playerTurn = EnumChessPieceColor.Black;
            }
            else
            {
                playerTurn = EnumChessPieceColor.White;
            }
        }

        public bool SelectChessPiece(int x, int y)
        {
            if (selectedChessPiece == null && chessBoard[x, y] == null)
            {
                return false;
            }
            else if (chessBoard[x, y].Color != playerTurn)
            {
                return false;
            }
            selectedChessPiece = chessBoard[x, y];
            highlightChessPieceMoves = selectedChessPiece.PossibleMove(chessBoard); // ChessPiece[,] chessBoard.
            return true;
        }

        public bool[,] GetHighlightedMoves()
        {
            return highlightChessPieceMoves;
        }

        public bool isKingCheck()
        {
            // NOT TESTED!!!
            try
            {
                King currentPlayerKing = getCurrentKing();
                if (currentPlayerKing.isKingChecked(chessBoard))
                {
                    return true;
                }
            }
            catch (InvalidCastException ex)
            {
                throw new Exception("activeChessPieces didn't return king /r/n" + ex.Message);
            }

            return false;
        }

        public bool isValidMove(int x, int y)
        {
            if (highlightChessPieceMoves[x, y] == true)
            {
                return true;
            }

            return false;
        }

        public bool isPlayerCheckmate()
        {
            if (checkMate == true)
            {
                return true;
            }
            return false;
        }

        public bool MoveChessPiece(int x, int y)
        {
            // Chess piece is selected and is current player turn.
            if (selectedChessPiece != null && selectedChessPiece.Color == playerTurn)
            {
                // Same chess squar deselect.
                if (selectedChessPiece.CurrentX == x && selectedChessPiece.CurrentY == y)
                {
                    selectedChessPiece = null;
                    return false;
                }
                else
                {
                    // Selected piece can move to x,y coordinates.
                    if (highlightChessPieceMoves[x, y] == true)
                    {
                        // Capture enemy piece.
                        if (chessBoard[x, y] != null && chessBoard[x, y].Color != playerTurn)
                        {

                            if (chessBoard[x, y].Type == EnumChessPieceType.King)
                            {
                                checkMate = true;
                            }
                            capturedChessPieces.Add(chessBoard[x, y]); // Add enemy piece to captured pieces List.
                            activeChessPieces.Remove(chessBoard[x, y]); // Remove enemy piece from activetChessPieces List.
                            chessBoard[x, y].IsCaptured = true;

                            chessBoard[selectedChessPiece.CurrentX, selectedChessPiece.CurrentY] = null; // Clear board square.
                            chessBoard[x, y] = selectedChessPiece; // Move.
                            chessBoard[x, y].SetPosition(x, y); // Set piece new coordinates.

                            selectedChessPiece = null; // De-Select.
                            changePlayerTurn(); // Next turn.

                        }
                        // Else just move piece.
                        else
                        {
                            chessBoard[selectedChessPiece.CurrentX, selectedChessPiece.CurrentY] = null; // Clear.
                            chessBoard[x, y] = selectedChessPiece; // Move.
                            chessBoard[x, y].SetPosition(x, y); // Set piece new coordinates.

                            selectedChessPiece = null; // De-Select.
                            changePlayerTurn(); // Next turn.
                        }

                        return true;
                    }
                    else
                    {
                        selectedChessPiece = null;
                        return false;
                    }
                }
            }
            else
            {
                throw new Exception("BoardManager.cs->MoveChessPiece() line:195 -> selectedChessPiece is null OR selectedChessPiece is one of the enemy player pieces(.color is wrong)!");
                // Return false. // Case something goes horrably wrong.
            }
        }

        public EnumChessPieceColor GetPlayerTurn()
        {
            return playerTurn;
        }

        /// <summary>
        /// List of all the chess piece objects:
        /// 0-White Rook; 1-White Rook; 2-White Knight; 3-White Knight; 4-White Bishop; 5-White Bishop; 6-White Queen; 7-White King;            8-15 White Pawns;
        /// 16-Black Rook; 17-Black Rook; 18-Black Knight; 19-Black Knight; 20-Black Bishop; 21-Black Bishop; 22-Black King; 23-Black Queen;    24-32 Black Pawns;
        /// </summary>
        private void InitializeChessPieces()
        {
            // WHITE PLAYER
            // Rooks:
            chessPiecePrefab.Add(new Rook(0, 0, EnumChessPieceColor.White, EnumChessPieceType.Rook));
            chessPiecePrefab.Add(new Rook(0, 7, EnumChessPieceColor.White, EnumChessPieceType.Rook));
            // Knights:
            chessPiecePrefab.Add(new Knight(0, 1, EnumChessPieceColor.White, EnumChessPieceType.Knight));
            chessPiecePrefab.Add(new Knight(0, 6, EnumChessPieceColor.White, EnumChessPieceType.Knight));
            // Bishops:
            chessPiecePrefab.Add(new Bishop(0, 2, EnumChessPieceColor.White, EnumChessPieceType.Bishop));
            chessPiecePrefab.Add(new Bishop(0, 5, EnumChessPieceColor.White, EnumChessPieceType.Bishop));
            // Queen:
            chessPiecePrefab.Add(new Queen(0, 3, EnumChessPieceColor.White, EnumChessPieceType.Queen)); // White queen => white square.
            // King:
            chessPiecePrefab.Add(new King(0, 4, EnumChessPieceColor.White, EnumChessPieceType.King));
            // Pawns:
            for (int y = 0; y < 8; y++)
            {
                chessPiecePrefab.Add(new Pawn(1, y, EnumChessPieceColor.White, EnumChessPieceType.Pawn));
            }

            // BLACK PLAYER
            // Rooks:
            chessPiecePrefab.Add(new Rook(7, 0, EnumChessPieceColor.Black, EnumChessPieceType.Rook));
            chessPiecePrefab.Add(new Rook(7, 7, EnumChessPieceColor.Black, EnumChessPieceType.Rook));
            // Knights:
            chessPiecePrefab.Add(new Knight(7, 1, EnumChessPieceColor.Black, EnumChessPieceType.Knight));
            chessPiecePrefab.Add(new Knight(7, 6, EnumChessPieceColor.Black, EnumChessPieceType.Knight));
            // Bishops:
            chessPiecePrefab.Add(new Bishop(7, 2, EnumChessPieceColor.Black, EnumChessPieceType.Bishop));
            chessPiecePrefab.Add(new Bishop(7, 5, EnumChessPieceColor.Black, EnumChessPieceType.Bishop));
            // King:
            chessPiecePrefab.Add(new King(7, 4, EnumChessPieceColor.Black, EnumChessPieceType.King));
            // Queen:
            chessPiecePrefab.Add(new Queen(7, 3, EnumChessPieceColor.Black, EnumChessPieceType.Queen)); // black queen => black square
            // Pawns:
            for (int y = 0; y < 8; y++)
            {
                chessPiecePrefab.Add(new Pawn(6, y, EnumChessPieceColor.Black, EnumChessPieceType.Pawn));
            }
        }

        /// <summary>
        /// Spawn a chess piece on chessBoard from chessPiecePrefab List.
        /// </summary>
        /// <param name="chessPieceIndex">the index of the chess piece in chessPiecePrefab List.</param>
        /// <param name="x"> X coordinate in chessBoard matrix.</param>
        /// <param name="y"> Y coordinate in chessBoard matrix.</param>
        private void SpawnChessPiece(int chessPieceIndex, int x, int y)
        {
            this.chessBoard[x, y] = this.chessPiecePrefab[chessPieceIndex];
        }

        /// <summary>
        /// When starting a new game place all chess pieces on chessBoard using SpawnChessPiece().
        /// All of the chess pieces get moved to activeChessPieces List.
        /// </summary>
        private void SpawnAllChessPieces()
        {
            for (int i = 0; i < TOTAL_CHESS_PIECE_COUNT; i++)
            {
                SpawnChessPiece(i, chessPiecePrefab[i].CurrentX, chessPiecePrefab[i].CurrentY);
            }

            activeChessPieces = new List<IChessPiece>(chessPiecePrefab);
        }

        private King getCurrentKing()
        {
            return (King)activeChessPieces.Find(x => x.Type == EnumChessPieceType.King && x.Color == playerTurn);
        }
    }
}
