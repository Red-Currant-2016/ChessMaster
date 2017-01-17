namespace ChessMaster2017.Engine
{
    using System;
    using System.Collections.Generic;

    public class BoardManager
    {
        private const int BOARD_SIZE = 8;
        private const int TOTAL_CHESS_PIECE_COUNT = 32;

        private EnumPlayerTurn currentPlayerColor;
        //private Position currentSelectedTile;
        private List<ChessPiece> chessPiecePrefab;// used to create all the chess pieces object and set there initial position;
        private List<ChessPiece> activeChessPieces;
        private List<ChessPiece> capturedChessPieces;
        private King blackKing;
        private King whiteKing;
        private bool[,] highlightChessPieceMoves;
        private bool checkMate;

        public ChessPiece[,] chessBoard;
        public ChessPiece selectedChessPiece;// contains a copy of a single chessBoard cell



        public BoardManager()
        {
            chessBoard = new ChessPiece[BOARD_SIZE, BOARD_SIZE];
            chessPiecePrefab = new List<ChessPiece>(TOTAL_CHESS_PIECE_COUNT);

            InitializeChessPieces();
            SpawnAllChessPieces();

            currentPlayerColor = EnumPlayerTurn.WhitePlayer;
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
            chessPiecePrefab.Add(new Rook(0, 0, EnumChessPieceColor.White, EnumChessPieceType.Rook));
            chessPiecePrefab.Add(new Rook(0, 7, EnumChessPieceColor.White, EnumChessPieceType.Rook));
            //Knights
            chessPiecePrefab.Add(new Knight(0, 1, EnumChessPieceColor.White, EnumChessPieceType.Knight));
            chessPiecePrefab.Add(new Knight(0, 6, EnumChessPieceColor.White, EnumChessPieceType.Knight));
            //Bishops
            chessPiecePrefab.Add(new Bishop(0, 2, EnumChessPieceColor.White, EnumChessPieceType.Bishop));
            chessPiecePrefab.Add(new Bishop(0, 5, EnumChessPieceColor.White, EnumChessPieceType.Bishop));
            //Queen
            chessPiecePrefab.Add(new Queen(0, 3, EnumChessPieceColor.White, EnumChessPieceType.Queen));// white queen => white squar
            //King
            whiteKing = new King(0, 4, EnumChessPieceColor.White, EnumChessPieceType.King);
            chessPiecePrefab.Add(whiteKing);
            //Pawns
            for (int y = 0; y < 8; y++)
            {
                chessPiecePrefab.Add(new Pawn(1, y, EnumChessPieceColor.White, EnumChessPieceType.Pawn));
            }

            //BLACK PLAYER
            //Rooks
            chessPiecePrefab.Add(new Rook(7, 0, EnumChessPieceColor.Black, EnumChessPieceType.Rook));
            chessPiecePrefab.Add(new Rook(7, 7, EnumChessPieceColor.Black, EnumChessPieceType.Rook));
            //Knights
            chessPiecePrefab.Add(new Knight(7, 1, EnumChessPieceColor.Black, EnumChessPieceType.Knight));
            chessPiecePrefab.Add(new Knight(7, 6, EnumChessPieceColor.Black, EnumChessPieceType.Knight));
            //Bishops
            chessPiecePrefab.Add(new Bishop(7, 2, EnumChessPieceColor.Black, EnumChessPieceType.Bishop));
            chessPiecePrefab.Add(new Bishop(7, 5, EnumChessPieceColor.Black, EnumChessPieceType.Bishop));
            //King
            blackKing = new King(7, 4, EnumChessPieceColor.Black, EnumChessPieceType.King);
            chessPiecePrefab.Add(blackKing);
            //Queen
            chessPiecePrefab.Add(new Queen(7, 3, EnumChessPieceColor.Black, EnumChessPieceType.Queen));// black queen => black squar

            //Pawns
            for (int y = 0; y < 8; y++)
            {
                chessPiecePrefab.Add(new Pawn(6, y, EnumChessPieceColor.Black, EnumChessPieceType.Pawn));
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

        private bool IsChessPieceSelected(ChessPiece chessPiece)
        {
            return chessPiece != null;
        }
        private bool IsNotEmpty(Position position)
        {
            return chessBoard[position.x, position.y] != null;
        }
        private bool IsNotEmpty(int x, int y)
        {
            return chessBoard[x, y] != null;
        }
        private bool IsChessPicesOwnedByCurrentPlayer(ChessPiece chessPiece)
        {
            if (chessPiece.Color == EnumChessPieceColor.White && this.currentPlayerColor == EnumPlayerTurn.WhitePlayer)
            {
                return true;
            }
            else if (chessPiece.Color == EnumChessPieceColor.Black && this.currentPlayerColor == EnumPlayerTurn.BlackPlayer)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private bool IsEnemy(ChessPiece chessPieceAt, ChessPiece currentChessPiece)
        {
            if (chessPieceAt.Color != currentChessPiece.Color)
            {
                return true;
            }
            return false;
        }
        private bool IsBishop(ChessPiece chessPiece)
        {
            if (chessPiece.Type == EnumChessPieceType.Bishop)
            {
                return true;
            }
            return false;
        }
        private bool IsKnight(ChessPiece chessPiece)
        {
            if (chessPiece.Type == EnumChessPieceType.Knight)
            {
                return true;
            }
            return false;
        }
        private bool IsPawn(ChessPiece chessPiece)
        {
            if (chessPiece.Type == EnumChessPieceType.Pawn)
            {
                return true;
            }
            return false;
        }
        private bool IsQueen(ChessPiece chessPiece)
        {
            if (chessPiece.Type == EnumChessPieceType.Queen)
            {
                return true;
            }
            return false;
        }
        private bool IsRook(ChessPiece chessPiece)
        {
            if (chessPiece.Type == EnumChessPieceType.Rook)
            {
                return true;
            }
            return false;
        }
        private bool IsKing(ChessPiece chessPiece)
        {
            if (chessPiece.Type == EnumChessPieceType.King)
            {
                return true;
            }
            return false;
        }

        private Position ParsePosition(string position)
        {
            int y = position[0] - 'a';
            int x = position[1] - '1';

            return new Position(x, y);
        }
        private ChessPiece GetChessPieceAtPosition(Position position)
        {
            return chessBoard[position.x, position.y];
        }
        private ChessPiece GetChessPieceAtPosition(int x, int y)
        {
            return chessBoard[x, y];
        }
        private King GetCurrentKing()
        {
            if (currentPlayerColor == EnumPlayerTurn.WhitePlayer)
            {
                return whiteKing;
            }
            else
            {
                return blackKing;
            }

        }
        private void PopulateChessPieceMoves()
        {
            this.highlightChessPieceMoves = this.selectedChessPiece.PossibleMove(chessBoard);
        }
        //check king
        private bool IsKingCheckByKnight(King currentKing, Position currentKingPosition)
        {
            //check from a KNIGHT
            //1 - right up
            if (currentKingPosition.x + 1 < 8 && currentKingPosition.y + 2 < 8)
            {
                if (IsNotEmpty(currentKingPosition.x + 1, currentKingPosition.y + 2))
                {
                    // enemy knight
                    if (IsEnemy(GetChessPieceAtPosition(currentKingPosition.x + 1, currentKingPosition.y + 2), currentKing)
                        && IsKnight(GetChessPieceAtPosition(currentKingPosition.x + 1, currentKingPosition.y + 2)))
                    {
                        return true;
                    }
                }
            }
            //2 - up right
            if (currentKingPosition.x + 2 < 8 && currentKingPosition.y + 1 < 8)
            {
                if (IsNotEmpty(currentKingPosition.x + 2, currentKingPosition.y + 1))
                {
                    if (IsEnemy(GetChessPieceAtPosition(currentKingPosition.x + 2, currentKingPosition.y + 1), currentKing)
                        && IsKnight(GetChessPieceAtPosition(currentKingPosition.x + 2, currentKingPosition.y + 1)))
                    {
                        return true;
                    }
                }
            }
            //3 - up left
            if (currentKingPosition.x + 2 < 8 && currentKingPosition.y - 1 >= 0)
            {
                if (IsNotEmpty(currentKingPosition.x + 2, currentKingPosition.y - 1))
                {
                    if (IsEnemy(GetChessPieceAtPosition(currentKingPosition.x + 2, currentKingPosition.y - 1), currentKing)
                        && IsKnight(GetChessPieceAtPosition(currentKingPosition.x + 2, currentKingPosition.y - 1)))
                    {
                        return true;
                    }
                }
            }
            //4 - left up
            if (currentKingPosition.x + 1 < 8 && currentKingPosition.y - 2 >= 0)
            {
                if (IsNotEmpty(currentKingPosition.x + 1, currentKingPosition.y - 2))
                {
                    if (IsEnemy(GetChessPieceAtPosition(currentKingPosition.x + 1, currentKingPosition.y - 2), currentKing)
                        && IsKnight(GetChessPieceAtPosition(currentKingPosition.x + 1, currentKingPosition.y - 2)))
                    {
                        return true;
                    }
                }
            }
            //5 - left dowm
            if (currentKingPosition.x - 1 >= 0 && currentKingPosition.y - 2 >= 0)
            {
                if (IsNotEmpty(currentKingPosition.x - 1, currentKingPosition.y - 2))
                {
                    if (IsEnemy(GetChessPieceAtPosition(currentKingPosition.x - 1, currentKingPosition.y - 2), currentKing)
                        && IsKnight(GetChessPieceAtPosition(currentKingPosition.x - 1, currentKingPosition.y - 2)))
                    {
                        return true;
                    }
                }
            }
            //6 - down left
            if (currentKingPosition.x - 2 >= 0 && currentKingPosition.y - 1 >= 0)
            {
                if (IsNotEmpty(currentKingPosition.x - 2, currentKingPosition.y - 1))
                {
                    if (IsEnemy(GetChessPieceAtPosition(currentKingPosition.x - 2, currentKingPosition.y - 1), currentKing)
                        && IsKnight(GetChessPieceAtPosition(currentKingPosition.x - 2, currentKingPosition.y - 1)))
                    {
                        return true;
                    }
                }
            }
            // 7 - down right
            if (currentKingPosition.x - 2 >= 0 && currentKingPosition.y + 1 < 8)
            {
                if (IsNotEmpty(currentKingPosition.x - 2, currentKingPosition.y + 1))
                {
                    if (IsEnemy(GetChessPieceAtPosition(currentKingPosition.x - 2, currentKingPosition.y + 1), currentKing)
                        && IsKnight(GetChessPieceAtPosition(currentKingPosition.x - 2, currentKingPosition.y + 1)))
                    {
                        return true;
                    }
                }
            }
            // 8 - right down
            if (currentKingPosition.x - 1 >= 0 && currentKingPosition.y + 2 < 8)
            {
                if (IsNotEmpty(currentKingPosition.x - 1, currentKingPosition.y + 2))
                {
                    if (IsEnemy(GetChessPieceAtPosition(currentKingPosition.x - 1, currentKingPosition.y + 2), currentKing)
                        && IsKnight(GetChessPieceAtPosition(currentKingPosition.x - 1, currentKingPosition.y + 2)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        private bool IsKingCheckHorizontallyOrVertecally(King currentKing, Position currentKingPosition)
        {
            // QUEEN AND ROOK
            //right check by queen and rook
            for (int rightLine = currentKingPosition.y + 1; rightLine < 8; rightLine++)
            {
                if (IsNotEmpty(currentKingPosition.x, rightLine))
                {
                    if (IsEnemy(GetChessPieceAtPosition(currentKingPosition.x, rightLine), currentKing))
                    {
                        if (IsQueen(GetChessPieceAtPosition(currentKingPosition.x, rightLine))
                            || IsRook(GetChessPieceAtPosition(currentKingPosition.x, rightLine)))
                        {
                            return true;
                        }
                        else
                        {
                            break;// enemy piece found, but isn't queen/rook
                        }
                    }
                    else
                    {
                        break;// same color pieces as king
                    }
                }
            }
            //up check by queen and rook
            for (int upLine = currentKingPosition.x + 1; upLine < 8; upLine++)
            {
                if (IsNotEmpty(upLine, currentKingPosition.y))
                {
                    if (IsEnemy(GetChessPieceAtPosition(upLine, currentKingPosition.y), currentKing))
                    {
                        if (IsQueen(GetChessPieceAtPosition(upLine, currentKingPosition.y))
                            || IsRook(GetChessPieceAtPosition(upLine, currentKingPosition.y)))
                        {
                            return true;
                        }
                        else
                        {
                            break;// enemy piece found, but isn't queen/rook
                        }
                    }
                    else
                    {
                        break;// same color pieces as king
                    }
                }
            }
            //left check by queen and rook
            for (int leftLine = currentKingPosition.y - 1; leftLine >= 0; leftLine--)
            {
                if (IsNotEmpty(currentKingPosition.x, leftLine))
                {
                    if (IsEnemy(GetChessPieceAtPosition(currentKingPosition.x, leftLine), currentKing))
                    {
                        if (IsQueen(GetChessPieceAtPosition(currentKingPosition.x, leftLine))
                            || IsRook(GetChessPieceAtPosition(currentKingPosition.x, leftLine)))
                        {
                            return true;
                        }
                        else
                        {
                            break;// enemy piece found, but isn't queen/rook
                        }
                    }
                    else
                    {
                        break;// same color piece as king
                    }
                }
            }
            //down check by queen and rook
            for (int downLine = currentKingPosition.x - 1; downLine >= 0; downLine--)
            {
                if (IsNotEmpty(downLine, currentKingPosition.y))
                {
                    if (IsEnemy(GetChessPieceAtPosition(downLine, currentKingPosition.y), currentKing))
                    {
                        if (IsQueen(GetChessPieceAtPosition(downLine, currentKingPosition.y))
                            || IsRook(GetChessPieceAtPosition(downLine, currentKingPosition.y)))
                        {
                            return true;
                        }
                        else
                        {
                            break;// enemy piece found, but isn't queen/rook
                        }
                    }
                    else
                    {
                        break;// same color piece as king
                    }
                }
            }

            return false;
        }
        private bool IsKingCheckDiagonally(King currentKing, Position currentKingPosition)
        {
            //check by QUEEN and BISHOP
            //1 up right diagonal
            for (int x = currentKingPosition.x + 1, y = currentKingPosition.y + 1; x < 8 && y < 8; x++, y++)
            {
                if (IsNotEmpty(x, y))
                {
                    if (IsEnemy(GetChessPieceAtPosition(x, y), currentKing))
                    {
                        if (IsQueen(GetChessPieceAtPosition(x, y))
                            || IsBishop(GetChessPieceAtPosition(x, y)))
                        {
                            return true;
                        }
                        else
                        {
                            break;// enemy piece found, but isn't queen/bishop
                        }
                    }
                    else
                    {
                        break;// same color piece as king
                    }
                }
            }
            //2 up left diagonal
            for (int x = currentKingPosition.x + 1, y = currentKingPosition.y - 1;
                    x < 8 && y >= 0;
                        x++, y--)
            {
                if (IsNotEmpty(x, y))
                {
                    if (IsEnemy(GetChessPieceAtPosition(x, y), currentKing))
                    {
                        if (IsQueen(GetChessPieceAtPosition(x, y))
                            || IsBishop(GetChessPieceAtPosition(x, y)))
                        {
                            return true;
                        }
                        else
                        {
                            break;// enemy piece found, but isn't queen/bishop
                        }
                    }
                    else
                    {
                        break;// same color piece as king
                    }
                }
            }
            //3 down right diagonal
            for (int x = currentKingPosition.x - 1, y = currentKingPosition.y - 1; x >= 0 && y >= 0; x--, y--)
            {
                if (IsNotEmpty(x, y))
                {
                    if (IsEnemy(GetChessPieceAtPosition(x, y), currentKing))
                    {
                        if (IsQueen(GetChessPieceAtPosition(x, y))
                            || IsBishop(GetChessPieceAtPosition(x, y)))
                        {
                            return true;
                        }
                        else
                        {
                            break;// enemy piece found, but isn't queen/bishop
                        }
                    }
                    else
                    {
                        break;// same color piece as king
                    }
                }
            }
            //4 down left diagonal
            for (int x = currentKingPosition.x - 1, y = currentKingPosition.y + 1; x >= 0 && y < 8; x--, y++)
            {
                if (IsNotEmpty(x, y))
                {
                    if (IsEnemy(GetChessPieceAtPosition(x, y), currentKing))
                    {
                        if (IsQueen(GetChessPieceAtPosition(x, y))
                            || IsBishop(GetChessPieceAtPosition(x, y)))
                        {
                            return true;
                        }
                        else
                        {
                            break;// enemy piece found, but isn't queen/bishop
                        }
                    }
                    else
                    {
                        break;// same color piece as king
                    }
                }
            }

            return false;
        }
        private bool IsKingCheckByPawn(King currentKing, Position currentKingPositon)
        {

            //check by PAWN
            //1 right up diagonal
            if (currentKingPositon.x + 1 < 8 && currentKingPositon.y + 1 < 8)
            {
                if (IsNotEmpty(currentKingPositon.x + 1, currentKingPositon.y + 1))
                {
                    if (IsEnemy(GetChessPieceAtPosition(currentKingPositon.x + 1, currentKingPositon.y + 1), currentKing))
                    {
                        if (IsPawn(GetChessPieceAtPosition(currentKingPositon.x + 1, currentKingPositon.y + 1)))
                        {
                            return true;
                        }
                    }
                }
            }
            //2 left up diagonal
            if (currentKingPositon.x + 1 < 8 && currentKingPositon.y - 1 >= 0)
            {
                if (IsNotEmpty(currentKingPositon.x + 1, currentKingPositon.y - 1))
                {
                    if (IsEnemy(GetChessPieceAtPosition(currentKingPositon.x + 1, currentKingPositon.y - 1), currentKing))
                    {
                        if (IsPawn(GetChessPieceAtPosition(currentKingPositon.x + 1, currentKingPositon.y - 1)))
                        {
                            return true;
                        }
                    }
                }
            }
            //3 left down diagonal
            if (currentKingPositon.x - 1 >= 0 && currentKingPositon.y - 1 >= 0)
            {
                if (IsNotEmpty(currentKingPositon.x - 1, currentKingPositon.y - 1))
                {
                    if (IsEnemy(GetChessPieceAtPosition(currentKingPositon.x - 1, currentKingPositon.y - 1), currentKing))
                    {
                        if (IsPawn(GetChessPieceAtPosition(currentKingPositon.x - 1, currentKingPositon.y - 1)))
                        {
                            return true;
                        }
                    }
                }
            }
            //4 right down diagonal
            if (currentKingPositon.x - 1 >= 0 && currentKingPositon.y + 1 < 8)
            {
                if (IsNotEmpty(currentKingPositon.x - 1, currentKingPositon.y - 1))
                {
                    if (IsEnemy(GetChessPieceAtPosition(currentKingPositon.x - 1, currentKingPositon.y + 1), currentKing))
                    {
                        if (IsPawn(GetChessPieceAtPosition(currentKingPositon.x - 1, currentKingPositon.y + 1)))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool[,] GetHighlightedMoves()
        {
            return highlightChessPieceMoves;
        }
        public void ChangePlayerTurn()
        {
            if (currentPlayerColor == EnumPlayerTurn.WhitePlayer)
            {
                currentPlayerColor = EnumPlayerTurn.BlackPlayer;
            }
            else
            {
                currentPlayerColor = EnumPlayerTurn.WhitePlayer;
            }
        }
        public bool IsWhitePlayerCheckMate()
        {
            if (whiteKing.isCaptured == true)
            {
                return true;
            }
            return false;
        }
        public bool IsBlackPlayerCheckMate()
        {
            if (blackKing.isCaptured == true)
            {
                return true;
            }
            return false;
        }

        public EnumPlayerTurn GetPlayerTurn()
        {
            return currentPlayerColor;
        }
        public bool isValidMove(int x, int y)
        {
            if (highlightChessPieceMoves[x, y] == true)
            {
                return true;
            }

            return false;
        }


        public bool IsKingChecked()
        {
            King currentKing = GetCurrentKing();

            Position currentKingPosition = currentKing.GetPosition();

            if (IsKingCheckByKnight(currentKing, currentKingPosition))
            {
                return true;
            }

            if (IsKingCheckHorizontallyOrVertecally(currentKing, currentKingPosition))
            {
                return true;
            }

            if (IsKingCheckDiagonally(currentKing, currentKingPosition))
            {
                return true;
            }
            if(IsKingCheckByPawn(currentKing, currentKingPosition))
            {
                return true;
            }
            return false;
        }
        //public string GetCheckedKing()
        //{
        //    King currentKing = GetCurrentKing();

        //    string output = currentKing.CurrentX.ToString() + 'a' + currentKing.ToString() + '1';

        //    return output;
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position">pictureBox datafield</param>
        /// <returns> true/false if a chess piece has been selected </returns>
        public bool SelectChessPiece(string position)
        {
            Position selectedPosition = this.ParsePosition(position);

            if (this.IsChessPieceSelected(this.selectedChessPiece) && this.IsNotEmpty(selectedPosition))
            {
                return false;
            }
            else if (!this.IsChessPicesOwnedByCurrentPlayer(this.GetChessPieceAtPosition(selectedPosition)))
            {
                return false;
            }
            this.selectedChessPiece = this.GetChessPieceAtPosition(selectedPosition);
            this.PopulateChessPieceMoves();

            return true;
        }
        public bool MoveChessPiece(string position)
        {
            Position moveToPosition = this.ParsePosition(position);
            //temp 
            int x = moveToPosition.x;
            int y = moveToPosition.y;

            // chess piece is selected and is current player turn
            if (IsChessPieceSelected(selectedChessPiece) && IsChessPicesOwnedByCurrentPlayer(selectedChessPiece))
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
                    if (isValidMove(x,y))
                    {

                        //capture enemy piece
                        if (IsNotEmpty(x,y) && IsChessPicesOwnedByCurrentPlayer(selectedChessPiece))
                        {

                            capturedChessPieces.Add(chessBoard[x, y]);// add enemy piece to captured pieces List
                            activeChessPieces.Remove(chessBoard[x, y]);// remove enemy piece from activetChessPieces List
                            chessBoard[x, y].isCaptured = true;

                            chessBoard[selectedChessPiece.CurrentX, selectedChessPiece.CurrentY] = null; //clear board squar
                            chessBoard[x, y] = selectedChessPiece; //move
                            chessBoard[x, y].SetPosition(x, y);// set piece new coordinates

                            selectedChessPiece = null; //de-select
                            // next turn

                        }
                        //else just move piece
                        else
                        {
                            chessBoard[selectedChessPiece.CurrentX, selectedChessPiece.CurrentY] = null; //clear
                            chessBoard[x, y] = selectedChessPiece; //move
                            chessBoard[x, y].SetPosition(x, y);// set piece new coordinates

                            selectedChessPiece = null; //de-select
                            // next turn
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

        public void Run()
        {
            //TODO
        }
    }
}
