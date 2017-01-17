namespace ChessMaster2017.Engine
{
    class Pawn : ChessPiece
    {
        /// <summary>
        /// Pawn Logic + Start Position special move.
        /// 1st - Check if pawn is white or black with bool whitePawn
        /// 2nd - Check if pawn is at its starting position
        /// 3rd - if pawn is white it can move up or if it has a back figure on its
        /// diagonals it can move there too.
        /// 4th - code does the same with black pawn
        /// 
        /// at the end it returns a matrix bool [,] pawnMoves
        /// 
        /// </summary>

        public Pawn(int x, int y, EnumChessPieceColor color, EnumChessPieceType type) : base(x, y, color, type)
        {
        }

        public override bool[,] PossibleMove(ChessPiece[,] currentBoard)
        {
            int pawnX = this.CurrentX;
            int pawnY = this.CurrentY;

            bool[,] pawnMoves = new bool[8, 8];
            EnumChessPieceColor pawnColor = this.Color;

            bool whitePawn = false;

            if (this.Color == EnumChessPieceColor.White)
            {
                whitePawn = true;
            }


           
            //WHITE PAWN LOGIC
            // Top ^ Special move pawn - double forward move

            for (int movesX = pawnX + 2; pawnX==1 && whitePawn && movesX >= 0 && movesX < 8; )
            {
                int movesY = pawnY;

                if (currentBoard[movesX, movesY] != null)
                {
                    pawnMoves[movesX, movesY] = false;

                    break;
                }
                else
                {
                    pawnMoves[movesX, movesY] = true;

                    break;
                }

            }


            //TOP ^ if the pawn is white it can move upwards - no special exchange
            for (int movesX = pawnX + 1; whitePawn && movesX >= 0 && movesX < 8; )
            {
                int movesY = pawnY;

                if (currentBoard[movesX, movesY] != null)
                {
                    pawnMoves[movesX, movesY] = false;

                    break;
                }
                else
                {
                    pawnMoves[movesX, movesY] = true;

                    break;
                }

            }
            // Top Right diagonal
            for (int movesX = pawnX + 1, movesY = pawnY - 1; whitePawn && movesX < 8 && movesX >= 0 && movesY < 8 && movesY >= 0; )
            {

                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == pawnColor)
                {
                    pawnMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != pawnColor)
                {
                    pawnMoves[movesX, movesY] = true;
                    break;
                }
                else
                {
                    pawnMoves[movesX, movesY] = false;
                    break;
                }

            }

            // Top Left diagonal
            for (int movesX = pawnX + 1, movesY = pawnY + 1; whitePawn && movesX < 8 && movesX >= 0 && movesY < 8 && movesY >= 0; )
            {

                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == pawnColor)
                {
                    pawnMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != pawnColor)
                {
                    pawnMoves[movesX, movesY] = true;
                    break;
                }
                else
                {
                    pawnMoves[movesX, movesY] = false;
                    break;
                }

            }

            // BLACK PAWN LOGIC
            // Bottom ^ Special move pawn - double forward move

            for (int movesX = pawnX - 2; pawnX == 6 && !whitePawn && movesX >= 0 && movesX < 8; )
            {
                int movesY = pawnY;

                if (currentBoard[movesX, movesY] != null)
                {
                    pawnMoves[movesX, movesY] = false;

                    break;
                }
                else
                {
                    pawnMoves[movesX, movesY] = true;

                    break;
                }

            }


            //BOTTOM ^ if the pawn is white it can move upwards - no special exchange
            for (int movesX = pawnX - 1; !whitePawn && movesX >= 0 && movesX < 8; )
            {
                int movesY = pawnY;

                if (currentBoard[movesX, movesY] != null)
                {
                    pawnMoves[movesX, movesY] = false;

                    break;
                }
                else
                {
                    pawnMoves[movesX, movesY] = true;

                    break;
                }

            }
            // Bottom \ Right diagonal
            for (int movesX = pawnX - 1, movesY = pawnY + 1; !whitePawn && movesX < 8 && movesX >= 0 && movesY < 8 && movesY >= 0; )
            {

                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == pawnColor)
                {
                    pawnMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != pawnColor)
                {
                    pawnMoves[movesX, movesY] = true;
                    break;
                }
                else
                {
                    pawnMoves[movesX, movesY] = false;
                    break;
                }

            }

            // Bottom / Left diagonal
            for (int movesX = pawnX - 1, movesY = pawnY - 1; !whitePawn && movesX < 8 && movesX >= 0 && movesY < 8 && movesY >= 0; movesX--, movesY--)
            {

                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == pawnColor)
                {
                    pawnMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != pawnColor)
                {
                    pawnMoves[movesX, movesY] = true;
                    break;
                }
                else
                {
                    pawnMoves[movesX, movesY] = false;
                    break;
                }

            }

            return pawnMoves;
        }
    }
}
