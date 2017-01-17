namespace ChessMaster2017.Engine
{
    using ChessMaster2017.Engine.Enums;
    using ChessMaster2017.Engine.Contracts;

    class Queen : ChessPiece, IQueen
    {
        public Queen(int x, int y, EnumColor color, EnumType type) : base(x, y, color, type)
        {
        }

        public override bool[,] PossibleMove(IChessPiece[,] currentBoard)
        {
            int queenX = this.CurrentX;
            int queenY = this.CurrentY;

            bool[,] queenMoves = new bool[8, 8];
            EnumColor queenColor = this.Color;

            // Bottom right diagonal.
            for (int movesX = queenX - 1, movesY = queenY + 1; movesX < 8 && movesX >= 0 && movesY < 8 && movesY >= 0; movesX--, movesY++)
            {
                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == queenColor)
                {
                    queenMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != queenColor)
                {
                    queenMoves[movesX, movesY] = true;
                    break;
                }
                else
                {
                    queenMoves[movesX, movesY] = true;
                }
            }

            // Top right.
            for (int movesX = queenX + 1, movesY = queenY + 1; movesX < 8 && movesX >= 0 && movesY < 8 && movesY >= 0; movesX++, movesY++)
            {
                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == queenColor)
                {
                    queenMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != queenColor)
                {
                    queenMoves[movesX, movesY] = true;
                    break;
                }
                else
                {
                    queenMoves[movesX, movesY] = true;
                }
            }

            // Top left.
            for (int movesX = queenX + 1, movesY = queenY - 1; movesX < 8 && movesX >= 0 && movesY < 8 && movesY >= 0; movesX++, movesY--)
            {
                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == queenColor)
                {
                    queenMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != queenColor)
                {
                    queenMoves[movesX, movesY] = true;
                    break;
                }
                else
                {
                    queenMoves[movesX, movesY] = true;
                }
            }

            // Bottom right.
            for (int movesX = queenX - 1, movesY = queenY - 1; movesX < 8 && movesX >= 0 && movesY < 8 && movesY >= 0; movesX--, movesY--)
            {
                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == queenColor)
                {
                    queenMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != queenColor)
                {
                    queenMoves[movesX, movesY] = true;
                    break;
                }
                else
                {
                    queenMoves[movesX, movesY] = true;
                }
            }

            // Right.
            for (int movesY = queenY + 1; movesY >= 0 && movesY < 8; movesY++)
            {
                int movesX = queenX;

                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == queenColor)
                {
                    queenMoves[movesX, movesY] = false;

                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != queenColor)
                {
                    queenMoves[movesX, movesY] = true;
                    break;
                }
                else
                {
                    queenMoves[movesX, movesY] = true;
                }
            }

            // Bottom.
            for (int movesX = queenX - 1; movesX >= 0 && movesX < 8; movesX--)
            {
                int movesY = queenY;

                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == queenColor)
                {
                    queenMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != queenColor)
                {
                    queenMoves[movesX, movesY] = true;
                    break;
                }
                else
                {
                    queenMoves[movesX, movesY] = true;
                }
            }

            // Left.
            for (int movesY = queenY - 1; movesY >= 0 && movesY < 8; movesY--)
            {
                int movesX = queenX;

                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == queenColor)
                {
                    queenMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != queenColor)
                {
                    queenMoves[movesX, movesY] = true;
                    break;
                }

                else
                {
                    queenMoves[movesX, movesY] = true;
                }
            }

            // Top.
            for (int movesX = queenX + 1; movesX >= 0 && movesX < 8; movesX++)
            {
                int movesY = queenY;

                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == queenColor)
                {
                    queenMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != queenColor)
                {
                    queenMoves[movesX, movesY] = true;
                    break;
                }
                else
                {
                    queenMoves[movesX, movesY] = true;
                }
            }
            return queenMoves;
        }
    }
}