using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster2017.BackEnd
{
    class King : ChessPiece
    {
        public bool hasMoved { get; set; }

        public King(int x, int y, ChessPieceColor color, ChessPieceType type) : base(x, y, color, type)
        {
            this.hasMoved = false;
        }

        public bool isKingChecked(ChessPiece[,] currentBoard)
        {
            int currentX = this.CurrentX;
            int currentY = this.CurrentY;

            //check from a KNIGHT
            //1 - right up
            if (currentX + 1 < 8 && currentY + 2 < 8)
            {
                if (currentBoard[currentX + 1, currentY + 2] != null)
                {
                    // enemy knight
                    if (currentBoard[currentX + 1, currentY + 2].Color != this.Color && currentBoard[currentX + 1, currentY + 2].Type == ChessPieceType.Knight)
                    {
                        return true;
                    }
                }
            }
            //2 - up right
            if (currentX + 2 < 8 && currentY + 1 < 8)
            {
                if (currentBoard[currentX + 2, currentY + 1] != null)
                {
                    if (currentBoard[currentX + 2, currentY + 1].Color != this.Color && currentBoard[currentX + 2, currentY + 1].Type == ChessPieceType.Knight)
                    {
                        return true;
                    }
                }
            }
            //3 - up left
            if (currentX + 2 < 8 && currentY - 1 >= 0)
            {
                if (currentBoard[currentX + 2, currentY - 1] != null)
                {
                    if (currentBoard[currentX + 2, currentY - 1].Color != this.Color && currentBoard[currentX + 2, currentY - 1].Type == ChessPieceType.Knight)
                    {
                        return true;
                    }
                }
            }
            //4 - left up
            if (currentX + 1 < 8 && currentY - 2 >= 0)
            {
                if (currentBoard[currentX + 1, currentY - 2] != null)
                {
                    if (currentBoard[currentX + 1, currentY - 2].Color != this.Color && currentBoard[currentX + 1, currentY - 2].Type == ChessPieceType.Knight)
                    {
                        return true;
                    }
                }
            }
            //5 - left dowm
            if (currentX - 1 >= 0 && currentY - 2 >= 0)
            {
                if (currentBoard[currentX - 1, currentY - 2] != null)
                {
                    if (currentBoard[currentX - 1, currentY - 2].Color != this.Color && currentBoard[currentX - 1, currentY - 2].Type == ChessPieceType.Knight)
                    {
                        return true;
                    }
                }
            }
            //6 - down left
            if (currentX - 2 >= 0 && currentY - 1 >= 0)
            {
                if (currentBoard[currentX - 2, currentY - 1] != null)
                {
                    if (currentBoard[currentX - 2, currentY - 1].Color != this.Color && currentBoard[currentX - 2, currentY - 1].Type == ChessPieceType.Knight)
                    {
                        return true;
                    }
                }
            }
            // 7 - down right
            if (currentX - 2 >= 0 && currentY + 1 < 8)
            {
                if (currentBoard[currentX - 2, currentY + 1] != null)
                {
                    if (currentBoard[currentX - 2, currentY + 1].Color != this.Color && currentBoard[currentX - 2, currentY + 1].Type == ChessPieceType.Knight)
                    {
                        return true;
                    }
                }
            }
            // 8 - right down
            if (currentX - 1 >= 0 && currentY + 2 < 8)
            {
                if (currentBoard[currentX - 1, currentY + 2] != null)
                {
                    if (currentBoard[currentX - 1, currentY + 2].Color != this.Color && currentBoard[currentX - 1, currentY + 2].Type == ChessPieceType.Knight)
                    {
                        return true;
                    }
                }
            }

            // QUEEN AND ROOK
            //right check by queen and rook
            for (int rightLine = currentY + 1; rightLine < 8; rightLine++)
            {
                if (currentBoard[currentX, rightLine] != null)
                {
                    if (currentBoard[currentX, rightLine].Color != this.Color)
                    {
                        if (currentBoard[currentX, rightLine].Type == ChessPieceType.Queen || currentBoard[currentX, rightLine].Type == ChessPieceType.Rook)
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
            for (int upLine = currentX + 1; upLine < 8; upLine++)
            {
                if (currentBoard[upLine, currentY] != null)
                {
                    if (currentBoard[upLine, currentY].Color != this.Color)
                    {
                        if (currentBoard[upLine, currentY].Type == ChessPieceType.Queen || currentBoard[upLine, currentY].Type == ChessPieceType.Rook)
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
            for (int leftLine = currentY - 1; leftLine >= 0; leftLine--)
            {
                if (currentBoard[currentX, leftLine] != null)
                {
                    if (currentBoard[currentX, leftLine].Color != this.Color)
                    {
                        if (currentBoard[currentX, leftLine].Type == ChessPieceType.Queen || currentBoard[currentX, leftLine].Type == ChessPieceType.Rook)
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
            for (int downLine = currentX - 1; currentX >= 0; downLine--)
            {
                if (currentBoard[downLine, currentY] != null)
                {
                    if (currentBoard[downLine, currentY].Color != this.Color)
                    {
                        if (currentBoard[downLine, currentY].Type == ChessPieceType.Queen || currentBoard[downLine, currentY].Type == ChessPieceType.Rook)
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

            //check by QUEEN and BISHOP
            //1 up right diagonal
            for (int x = currentX + 1, y = currentY + 1; x < 8 && y < 8; x++, y++)
            {
                if(currentBoard[x,y] != null)
                {
                    if(currentBoard[x,y].Color != this.Color)
                    {
                        if(currentBoard[x,y].Type == ChessPieceType.Queen || currentBoard[x,y].Type == ChessPieceType.Bishop)
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
            for (int x = currentX + 1, y = currentY - 1; x < 8 && y >= 0; x++, y--)
            {
                if (currentBoard[x, y] != null)
                {
                    if (currentBoard[x, y].Color != this.Color)
                    {
                        if (currentBoard[x, y].Type == ChessPieceType.Queen || currentBoard[x, y].Type == ChessPieceType.Bishop)
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
            for (int x = currentX - 1, y = currentY - 1; x >= 0 && y >= 0; x--, y--)
            {
                if (currentBoard[x, y] != null)
                {
                    if (currentBoard[x, y].Color != this.Color)
                    {
                        if (currentBoard[x, y].Type == ChessPieceType.Queen || currentBoard[x, y].Type == ChessPieceType.Bishop)
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
            for (int x = currentX - 1, y = currentY + 1; x >= 0 && y < 8; x--, y++)
            {
                if (currentBoard[x, y] != null)
                {
                    if (currentBoard[x, y].Color != this.Color)
                    {
                        if (currentBoard[x, y].Type == ChessPieceType.Queen || currentBoard[x, y].Type == ChessPieceType.Bishop)
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
            


            //check by PAWN
            //1 right up diagonal
            if (currentX + 1 < 8 && currentY + 1 < 8)
            {
                if (currentBoard[currentX + 1, currentY + 1] != null)
                {
                    if (currentBoard[currentX + 1, currentY + 1].Color != this.Color)
                    {
                        if (currentBoard[currentX + 1, currentY + 1].Type == ChessPieceType.Pawn)
                        {
                            return true;
                        }
                    }
                }
            }
            //2 left up diagonal
            if (currentX + 1 < 8 && currentY - 1 >= 0)
            {
                if (currentBoard[currentX + 1, currentY - 1] != null)
                {
                    if (currentBoard[currentX + 1, currentY - 1].Color != this.Color)
                    {
                        if (currentBoard[currentX + 1, currentY - 1].Type == ChessPieceType.Pawn)
                        {
                            return true;
                        }
                    }
                }
            }
            //3 left down diagonal
            if (currentX - 1 >= 0 && currentY - 1 >= 0)
            {
                if (currentBoard[currentX - 1, currentY - 1] != null)
                {
                    if (currentBoard[currentX - 1, currentY - 1].Color != this.Color)
                    {
                        if (currentBoard[currentX - 1, currentY - 1].Type == ChessPieceType.Pawn)
                        {
                            return true;
                        }
                    }
                }
            }
            //4 right down diagonal
            if (currentX - 1 >= 0 && currentY + 1 < 8)
            {
                if (currentBoard[currentX - 1, currentY + 1] != null)
                {
                    if (currentBoard[currentX - 1, currentY + 1].Color != this.Color)
                    {
                        if (currentBoard[currentX - 1, currentY + 1].Type == ChessPieceType.Pawn)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
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
                else if (currentBoard[kingX + 1, kingY - 1] != null && currentBoard[kingX + 1, kingY - 1].Color != kingColor)
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
                    kingMoves[kingX - 1, kingY] = true;
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
