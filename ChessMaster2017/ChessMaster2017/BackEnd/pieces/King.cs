using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster2017.BackEnd
{
    class King : ChessPiece
    {
        public bool isCheck { get; set; }

        public King(int x, int y, ChessPieceColor color, ChessPieceType type) : base(x, y, color, type)
        {
            this.isCheck = false;
        }

        /// <summary>
        /// If King is checked possible moves will be calculated normaly.
        /// </summary>
        /// <param name="currentBoard"></param>
        /// <returns></returns>
        public override bool[,] PossibleMove(ChessPiece[,] currentBoard)
        {
            int kingX = this.CurrentX;
            int kingY = this.CurrentY;

            bool[,] kingMoves = new bool[8, 8];
            ChessPieceColor kingColor = this.Color;

            //top
            if (kingX + 1 < 8)
            {
                if (currentBoard[kingX + 1, kingY] != null && currentBoard[kingX + 1, kingY].Color == kingColor)
                {
                    kingMoves[kingX + 1, kingY] = false;
                }
                else if (currentBoard[kingX + 1, kingY] != null && currentBoard[kingX + 1, kingY].Color != kingColor)
                {
                    kingMoves[kingX + 1, kingY] = true;
                }
                else
                {
                    kingMoves[kingX + 1, kingY] = true;
                }
            }

            // top left

            if (kingX + 1 < 8 && kingY - 1 >= 0)
            {
                if (currentBoard[kingX + 1, kingY - 1] != null && currentBoard[kingX + 1, kingY - 1].Color == kingColor)
                {
                    kingMoves[kingX + 1, kingY - 1] = false;
                }
                else if (currentBoard[kingX + 1, kingY -1 ] != null && currentBoard[kingX + 1, kingY - 1].Color != kingColor)
                {
                    kingMoves[kingX + 1, kingY - 1] = true;
                }
                else
                {
                    kingMoves[kingX + 1, kingY - 1] = true;
                }
            }

            //left

            if (kingY - 1 >= 0)
            {
                if (currentBoard[kingX, kingY - 1] != null && currentBoard[kingX, kingY - 1].Color == kingColor)
                {
                    kingMoves[kingX, kingY - 1] = false;
                }
                else if (currentBoard[kingX, kingY - 1] != null && currentBoard[kingX, kingY - 1].Color != kingColor)
                {
                    kingMoves[kingX, kingY - 1] = true;
                }
                else
                {
                    kingMoves[kingX, kingY - 1] = true;
                }
            }

            //bottom left

            if (kingX - 1 >= 0 && kingY - 1 >= 0)
            {
                if (currentBoard[kingX - 1, kingY - 1] != null && currentBoard[kingX - 1, kingY - 1].Color == kingColor)
                {
                    kingMoves[kingX - 1, kingY - 1] = false;
                }
                else if (currentBoard[kingX - 1, kingY - 1] != null && currentBoard[kingX - 1, kingY - 1].Color != kingColor)
                {
                    kingMoves[kingX - 1, kingY - 1] = true;
                }
                else
                {
                    kingMoves[kingX - 1, kingY - 1] = true;
                }
            }

            //bottom

            if (kingX - 1 >= 0)
            {
                if (currentBoard[kingX - 1, kingY] != null && currentBoard[kingX - 1, kingY].Color == kingColor)
                {
                    kingMoves[kingX - 1, kingY] = false;
                }
                else if (currentBoard[kingX - 1, kingY] != null && currentBoard[kingX - 1, kingY].Color != kingColor)
                {
                    kingMoves[kingX - 1, kingY] = true;
                }
                else
                {
                    kingMoves[kingX  - 1, kingY] = true;
                }
            }

            //bottom right

            if (kingX - 1 >= 0 && kingY + 1 < 8)
            {
                if (currentBoard[kingX - 1, kingY + 1] != null && currentBoard[kingX - 1, kingY + 1].Color == kingColor)
                {
                    kingMoves[kingX - 1, kingY + 1] = false;
                }
                else if (currentBoard[kingX - 1, kingY + 1] != null && currentBoard[kingX - 1, kingY + 1].Color != kingColor)
                {
                    kingMoves[kingX - 1, kingY + 1] = true;
                }
                else
                {
                    kingMoves[kingX - 1, kingY + 1] = true;
                }
            }

            //right

            if (kingY + 1 < 8)
            {
                if (currentBoard[kingX, kingY + 1] != null && currentBoard[kingX, kingY + 1].Color == kingColor)
                {
                    kingMoves[kingX, kingY + 1] = false;
                }
                else if (currentBoard[kingX, kingY + 1] != null && currentBoard[kingX, kingY + 1].Color != kingColor)
                {
                    kingMoves[kingX, kingY + 1] = true;
                }
                else
                {
                    kingMoves[kingX, kingY + 1] = true;
                }
            }

            //top right

            if (kingX + 1 < 8 && kingY + 1 < 8)
            {
                if (currentBoard[kingX + 1, kingY + 1] != null && currentBoard[kingX + 1, kingY + 1].Color == kingColor)
                {
                    kingMoves[kingX + 1, kingY + 1] = false;
                }
                else if (currentBoard[kingX + 1, kingY + 1] != null && currentBoard[kingX + 1, kingY + 1].Color != kingColor)
                {
                    kingMoves[kingX + 1, kingY + 1] = true;
                }
                else
                {
                    kingMoves[kingX + 1, kingY + 1] = true;
                }
            }

            


            return kingMoves;
        }
    }
}
