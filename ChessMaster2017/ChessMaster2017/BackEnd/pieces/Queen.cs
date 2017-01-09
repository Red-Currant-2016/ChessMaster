using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster2017.BackEnd
{
    class Queen : ChessPiece
    {
        public Queen(int x, int y, ChessPieceColor color, ChessPieceType type) : base(x, y, color, type)
        {
        }
        public override bool[,] PossibleMove(ChessPiece[,] currentBoard)
        {
            int queenX = this.CurrentX;
            int queenY = this.CurrentY;

            bool[,] queenMoves = new bool[8, 8];
            ChessPieceColor queenColor = this.Color;

            // bottom right diagonal
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

            // top right
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

            // Top Left
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

            // bottom right
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

            // right
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

            // bottom

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

            // left

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



            // top

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
