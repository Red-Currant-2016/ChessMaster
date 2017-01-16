namespace ChessMaster2017.Engine
{
    using ChessMaster2017.Engine.Enums;
    using ChessMaster2017.Engine.Contracts;

    class King : ChessPiece, IKing
    {
        private bool hasMoved;

        public King(int x, int y, EnumColor color, EnumType type) : base(x, y, color, type)
        {
            this.HasMoved = false;
        }

        public bool HasMoved
        {
            get { return this.hasMoved; }
            set { this.hasMoved = value; }
        }

        public bool isKingChecked(IChessPiece[,] currentBoard)
        {
            int currentX = this.CurrentX;
            int currentY = this.CurrentY;

            // Check from a KNIGHT.
            // 1 - right up.
            if (currentX + 1 < 8 && currentY + 2 < 8)
            {
                if (currentBoard[currentX + 1, currentY + 2] != null)
                {
                    // Enemy knight.
                    if (currentBoard[currentX + 1, currentY + 2].Color != this.Color && currentBoard[currentX + 1, currentY + 2].Type == EnumType.Knight)
                    {
                        return true;
                    }
                }
            }
            // 2 - up right.
            if (currentX + 2 < 8 && currentY + 1 < 8)
            {
                if (currentBoard[currentX + 2, currentY + 1] != null)
                {
                    if (currentBoard[currentX + 2, currentY + 1].Color != this.Color && currentBoard[currentX + 2, currentY + 1].Type == EnumType.Knight)
                    {
                        return true;
                    }
                }
            }
            // 3 - up left.
            if (currentX + 2 < 8 && currentY - 1 >= 0)
            {
                if (currentBoard[currentX + 2, currentY - 1] != null)
                {
                    if (currentBoard[currentX + 2, currentY - 1].Color != this.Color && currentBoard[currentX + 2, currentY - 1].Type == EnumType.Knight)
                    {
                        return true;
                    }
                }
            }
            // 4 - left up.
            if (currentX + 1 < 8 && currentY - 2 >= 0)
            {
                if (currentBoard[currentX + 1, currentY - 2] != null)
                {
                    if (currentBoard[currentX + 1, currentY - 2].Color != this.Color && currentBoard[currentX + 1, currentY - 2].Type == EnumType.Knight)
                    {
                        return true;
                    }
                }
            }
            // 5 - left dowm.
            if (currentX - 1 >= 0 && currentY - 2 >= 0)
            {
                if (currentBoard[currentX - 1, currentY - 2] != null)
                {
                    if (currentBoard[currentX - 1, currentY - 2].Color != this.Color && currentBoard[currentX - 1, currentY - 2].Type == EnumType.Knight)
                    {
                        return true;
                    }
                }
            }
            // 6 - down left.
            if (currentX - 2 >= 0 && currentY - 1 >= 0)
            {
                if (currentBoard[currentX - 2, currentY - 1] != null)
                {
                    if (currentBoard[currentX - 2, currentY - 1].Color != this.Color && currentBoard[currentX - 2, currentY - 1].Type == EnumType.Knight)
                    {
                        return true;
                    }
                }
            }
            // 7 - down right.
            if (currentX - 2 >= 0 && currentY + 1 < 8)
            {
                if (currentBoard[currentX - 2, currentY + 1] != null)
                {
                    if (currentBoard[currentX - 2, currentY + 1].Color != this.Color && currentBoard[currentX - 2, currentY + 1].Type == EnumType.Knight)
                    {
                        return true;
                    }
                }
            }
            // 8 - right down.
            if (currentX - 1 >= 0 && currentY + 2 < 8)
            {
                if (currentBoard[currentX - 1, currentY + 2] != null)
                {
                    if (currentBoard[currentX - 1, currentY + 2].Color != this.Color && currentBoard[currentX - 1, currentY + 2].Type == EnumType.Knight)
                    {
                        return true;
                    }
                }
            }

            // QUEEN AND ROOK
            // Right check by queen and rook.
            for (int rightLine = currentY + 1; rightLine < 8; rightLine++)
            {
                if (currentBoard[currentX, rightLine] != null)
                {
                    if (currentBoard[currentX, rightLine].Color != this.Color)
                    {
                        if (currentBoard[currentX, rightLine].Type == EnumType.Queen || currentBoard[currentX, rightLine].Type == EnumType.Rook)
                        {
                            return true;
                        }
                        else
                        {
                            break; // Enemy piece found, but isn't queen/rook.
                        }
                    }
                    else
                    {
                        break; // Same color pieces as king.
                    }
                }
            }
            // Up check by queen and rook.
            for (int upLine = currentX + 1; upLine < 8; upLine++)
            {
                if (currentBoard[upLine, currentY] != null)
                {
                    if (currentBoard[upLine, currentY].Color != this.Color)
                    {
                        if (currentBoard[upLine, currentY].Type == EnumType.Queen || currentBoard[upLine, currentY].Type == EnumType.Rook)
                        {
                            return true;
                        }
                        else
                        {
                            break; // Enemy piece found, but isn't queen/rook.
                        }
                    }
                    else
                    {
                        break; // Same color pieces as king.
                    }
                }
            }
            // Left check by queen and rook.
            for (int leftLine = currentY - 1; leftLine >= 0; leftLine--)
            {
                if (currentBoard[currentX, leftLine] != null)
                {
                    if (currentBoard[currentX, leftLine].Color != this.Color)
                    {
                        if (currentBoard[currentX, leftLine].Type == EnumType.Queen || currentBoard[currentX, leftLine].Type == EnumType.Rook)
                        {
                            return true;
                        }
                        else
                        {
                            break; // Enemy piece found, but isn't queen/rook.
                        }
                    }
                    else
                    {
                        break; // Same color piece as king.
                    }
                }
            }
            // Down check by queen and rook.
            for (int downLine = currentX - 1; currentX >= 0; downLine--)
            {
                if (currentBoard[downLine, currentY] != null)
                {
                    if (currentBoard[downLine, currentY].Color != this.Color)
                    {
                        if (currentBoard[downLine, currentY].Type == EnumType.Queen || currentBoard[downLine, currentY].Type == EnumType.Rook)
                        {
                            return true;
                        }
                        else
                        {
                            break; // Enemy piece found, but isn't queen/rook.
                        }
                    }
                    else
                    {
                        break; // Same color piece as king.
                    }
                }
            }

            // Check by QUEEN and BISHOP.
            // 1 up right diagonal.
            for (int x = currentX + 1, y = currentY + 1; x < 8 && y < 8; x++, y++)
            {
                if (currentBoard[x, y] != null)
                {
                    if (currentBoard[x, y].Color != this.Color)
                    {
                        if (currentBoard[x, y].Type == EnumType.Queen || currentBoard[x, y].Type == EnumType.Bishop)
                        {
                            return true;
                        }
                        else
                        {
                            break; // Enemy piece found, but isn't queen/bishop.
                        }
                    }
                    else
                    {
                        break; // Same color piece as king.
                    }
                }
            }
            // 2 up left diagonal.
            for (int x = currentX + 1, y = currentY - 1; x < 8 && y >= 0; x++, y--)
            {
                if (currentBoard[x, y] != null)
                {
                    if (currentBoard[x, y].Color != this.Color)
                    {
                        if (currentBoard[x, y].Type == EnumType.Queen || currentBoard[x, y].Type == EnumType.Bishop)
                        {
                            return true;
                        }
                        else
                        {
                            break; // Enemy piece found, but isn't queen/bishop.
                        }
                    }
                    else
                    {
                        break; // Same color piece as king.
                    }
                }
            }
            // 3 down right diagonal.
            for (int x = currentX - 1, y = currentY - 1; x >= 0 && y >= 0; x--, y--)
            {
                if (currentBoard[x, y] != null)
                {
                    if (currentBoard[x, y].Color != this.Color)
                    {
                        if (currentBoard[x, y].Type == EnumType.Queen || currentBoard[x, y].Type == EnumType.Bishop)
                        {
                            return true;
                        }
                        else
                        {
                            break; // Enemy piece found, but isn't queen/bishop.
                        }
                    }
                    else
                    {
                        break; // Same color piece as king.
                    }
                }
            }
            // 4 down left diagonal.
            for (int x = currentX - 1, y = currentY + 1; x >= 0 && y < 8; x--, y++)
            {
                if (currentBoard[x, y] != null)
                {
                    if (currentBoard[x, y].Color != this.Color)
                    {
                        if (currentBoard[x, y].Type == EnumType.Queen || currentBoard[x, y].Type == EnumType.Bishop)
                        {
                            return true;
                        }
                        else
                        {
                            break; // Enemy piece found, but isn't queen/bishop.
                        }
                    }
                    else
                    {
                        break; // Same color piece as king.
                    }
                }
            }

            // Check by PAWN.
            // 1 right up diagonal.
            if (currentX + 1 < 8 && currentY + 1 < 8)
            {
                if (currentBoard[currentX + 1, currentY + 1] != null)
                {
                    if (currentBoard[currentX + 1, currentY + 1].Color != this.Color)
                    {
                        if (currentBoard[currentX + 1, currentY + 1].Type == EnumType.Pawn)
                        {
                            return true;
                        }
                    }
                }
            }
            // 2 left up diagonal.
            if (currentX + 1 < 8 && currentY - 1 >= 0)
            {
                if (currentBoard[currentX + 1, currentY - 1] != null)
                {
                    if (currentBoard[currentX + 1, currentY - 1].Color != this.Color)
                    {
                        if (currentBoard[currentX + 1, currentY - 1].Type == EnumType.Pawn)
                        {
                            return true;
                        }
                    }
                }
            }
            // 3 left down diagonal.
            if (currentX - 1 >= 0 && currentY - 1 >= 0)
            {
                if (currentBoard[currentX - 1, currentY - 1] != null)
                {
                    if (currentBoard[currentX - 1, currentY - 1].Color != this.Color)
                    {
                        if (currentBoard[currentX - 1, currentY - 1].Type == EnumType.Pawn)
                        {
                            return true;
                        }
                    }
                }
            }
            // 4 right down diagonal.
            if (currentX - 1 >= 0 && currentY + 1 < 8)
            {
                if (currentBoard[currentX - 1, currentY + 1] != null)
                {
                    if (currentBoard[currentX - 1, currentY + 1].Color != this.Color)
                    {
                        if (currentBoard[currentX - 1, currentY + 1].Type == EnumType.Pawn)
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
        public override bool[,] PossibleMove(IChessPiece[,] currentBoard)
        {
            int kingX = this.CurrentX;
            int kingY = this.CurrentY;
            bool[,] kingMoves = new bool[8, 8];
            EnumColor kingColor = this.Color;

            // Top.
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

            // Top left.
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

            // Left.
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

            // Bottom left.
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

            // Bottom.
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

            // Bottom right.
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

            // Right.
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

            // Top right.
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
