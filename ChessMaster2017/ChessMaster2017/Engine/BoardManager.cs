using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster2017.Engine
{
    public class BoardManager
    {
        private const int BOARD_SIZE = 8;
        private const int TOTAL_CHESS_PIECE_COUNT = 32;

        private EnumColor playerTurn;

        public ChessPiece[,] chessBoard;
        public ChessPiece selectedChessPiece;// contains a copy of a single chessBoard cell

        private List<ChessPiece> chessPiecePrefab;// used to create all the chess pieces object and set there initial position;
        private List<ChessPiece> activeChessPieces;
        private List<ChessPiece> capturedChessPieces;

        private bool[,] highlightChessPieceMoves = new bool[BOARD_SIZE, BOARD_SIZE];
        private bool checkMate;

        public BoardManager()
        {
            chessBoard = new ChessPiece[BOARD_SIZE, BOARD_SIZE];
            chessPiecePrefab = new List<ChessPiece>(TOTAL_CHESS_PIECE_COUNT);

            InitializeChessPieces();

            SpawnAllChessPieces();

            playerTurn = EnumColor.White;
            selectedChessPiece = null;
            checkMate = false;

            capturedChessPieces = new List<ChessPiece>();
        }

        /// <summary>
        /// list of all the chess piece objects
        /// 0-White Rook; 1-White Rook; 2-White Knight; 3-White Knight; 4-White Bishop; 5-White Bishop; 6-White Queen; 7-White King;            8-15 White Pawns;
        /// 16-Black Rook; 17-Black Rook; 18-Black Knight; 19-Black Knight; 20-Black Bishop; 21-Black Bishop; 22-Black King; 23-Black Queen;    24-32 Black Pawns;
        /// </summary>
        private void InitializeChessPieces()
        {
            //WHITE PLAYER
            //Rooks
            chessPiecePrefab.Add(new Rook(0, 0, EnumColor.White, EnumType.Rook));
            chessPiecePrefab.Add(new Rook(0, 7, EnumColor.White, EnumType.Rook));
            //Knights
            chessPiecePrefab.Add(new Knight(0, 1, EnumColor.White, EnumType.Knight));
            chessPiecePrefab.Add(new Knight(0, 6, EnumColor.White, EnumType.Knight));
            //Bishops
            chessPiecePrefab.Add(new Bishop(0, 2, EnumColor.White, EnumType.Bishop));
            chessPiecePrefab.Add(new Bishop(0, 5, EnumColor.White, EnumType.Bishop));
            //Queen
            chessPiecePrefab.Add(new Queen(0, 3, EnumColor.White, EnumType.Queen));// white queen => white squar
            //King
            chessPiecePrefab.Add(new King(0, 4, EnumColor.White, EnumType.King));
            //Pawns
            for(int y = 0; y < 8; y++)
            {
                chessPiecePrefab.Add(new Pawn(1, y, EnumColor.White, EnumType.Pawn));
            }

            //BLACK PLAYER
            //Rooks
            chessPiecePrefab.Add(new Rook(7, 0, EnumColor.Black, EnumType.Rook));
            chessPiecePrefab.Add(new Rook(7, 7, EnumColor.Black, EnumType.Rook));
            //Knights
            chessPiecePrefab.Add(new Knight(7, 1, EnumColor.Black, EnumType.Knight));
            chessPiecePrefab.Add(new Knight(7, 6, EnumColor.Black, EnumType.Knight));
            //Bishops
            chessPiecePrefab.Add(new Bishop(7, 2, EnumColor.Black, EnumType.Bishop));
            chessPiecePrefab.Add(new Bishop(7, 5, EnumColor.Black, EnumType.Bishop));
            //King
            chessPiecePrefab.Add(new King(7, 4, EnumColor.Black, EnumType.King));
            //Queen
            chessPiecePrefab.Add(new Queen(7, 3, EnumColor.Black, EnumType.Queen));// black queen => black squar
            
            //Pawns
            for (int y = 0; y < 8; y++)
            {
                chessPiecePrefab.Add(new Pawn(6, y, EnumColor.Black, EnumType.Pawn));
            }
        }

        /// <summary>
        /// Spawn a chess piece on chessBoard from chessPiecePrefab List
        /// </summary>
        /// <param name="chessPieceIndex">the index of the chess piece in chessPiecePrefab List.</param>
        /// <param name="x"> X coordinate in chessBoard matrix.</param>
        /// <param name="y"> Y coordinate in chessBoard matrix.</param>
        private void SpawnChessPiece(int chessPieceIndex, int x, int y)
        {
            chessBoard[x, y] = chessPiecePrefab[chessPieceIndex];
        }

        /// <summary>
        /// When starting a new game place all chess pieces on chessBoard using SpawnChessPiece()
        /// All of the chess pieces get moved to activeChessPieces List;
        /// </summary>
        private void SpawnAllChessPieces()
        {
            for (int i = 0; i < TOTAL_CHESS_PIECE_COUNT; i++)
            {
                SpawnChessPiece(i, chessPiecePrefab[i].CurrentX, chessPiecePrefab[i].CurrentY);
            }

            activeChessPieces = new List<ChessPiece>(chessPiecePrefab);
        }

        public void changePlayerTurn()
        {

            if (playerTurn == EnumColor.White)
            {
                playerTurn = EnumColor.Black;
            }
            else
            {
                playerTurn = EnumColor.White;
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
            highlightChessPieceMoves = selectedChessPiece.PossibleMove(chessBoard);//ChessPiece[,] chessBoard
            return true;
        }

        public EnumColor GetPlayerTurn()
        {
            return playerTurn;
        }

        public bool[,] GetHighlightedMoves()
        {
            return highlightChessPieceMoves;
        }

        private King getCurrentKing()
        {
            return (King)activeChessPieces.Find(x => x.Type == EnumType.King && x.Color == playerTurn);
        }

        public bool isKingCheck()
        {
            //not tested!!!
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
            // chess piece is selected and is current player turn
            if (selectedChessPiece != null && selectedChessPiece.Color == playerTurn)
            {
                // same chess squar deselect
                if (selectedChessPiece.CurrentX == x && selectedChessPiece.CurrentY == y)
                {
                    selectedChessPiece = null;
                    return false;
                }
                else
                {
                    //selected piece can move to x,y coordinates
                    if (highlightChessPieceMoves[x, y] == true)
                    {                        

                        //capture enemy piece
                        if (chessBoard[x,y] != null && chessBoard[x,y].Color != playerTurn)
                        {

                            if(chessBoard[x,y].Type == EnumType.King)
                            {
                                checkMate = true;
                            }
                            capturedChessPieces.Add(chessBoard[x, y]);// add enemy piece to captured pieces List
                            activeChessPieces.Remove(chessBoard[x, y]);// remove enemy piece from activetChessPieces List
                            chessBoard[x, y].isCaptured = true;

                            chessBoard[selectedChessPiece.CurrentX, selectedChessPiece.CurrentY] = null; //clear board squar
                            chessBoard[x, y] = selectedChessPiece; //move
                            chessBoard[x, y].SetPosition(x, y);// set piece new coordinates

                            selectedChessPiece = null; //de-select
                            changePlayerTurn();// next turn

                        }
                        //else just move piece
                        else
                        {
                            chessBoard[selectedChessPiece.CurrentX, selectedChessPiece.CurrentY] = null; //clear
                            chessBoard[x, y] = selectedChessPiece; //move
                            chessBoard[x, y].SetPosition(x, y);// set piece new coordinates

                            selectedChessPiece = null; //de-select
                            changePlayerTurn();// next turn
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
                //return false;// case something goes horrably wrong;
            }
        }

    }
}
