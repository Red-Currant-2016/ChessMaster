namespace ChessMaster2017.Engine
{
    using ChessMaster2017.Engine.Enums;
    using ChessMaster2017.Engine.Contracts;

    class Knight : ChessPiece, IKnight
    {
             //    -8-1-
             //    7---2
             //    --k--
             //    6---3
             //    -5-4-

        public Knight(int x, int y, EnumColor color, EnumType type) : base(x, y, color, type)
        {
        }

        public override bool[,] PossibleMove(IChessPiece[,] currentBoard)
        {
            int knightX = this.CurrentX;
            int knightY = this.CurrentY;

            bool[,] knightMoves = new bool[8, 8];
            EnumColor knightColor = this.Color;

            // 8 = top left.
            if (knightX + 2 < 8 && knightX + 2 >= 0 && knightY - 1 >= 0 && knightY - 1 < 8)
            {
                if (currentBoard[knightX + 2, knightY - 1] != null && currentBoard[knightX + 2, knightY - 1].Color == knightColor)
                {
                    knightMoves[knightX + 2, knightY - 1] = false;
                }
                else if (currentBoard[knightX + 2, knightY - 1] != null && currentBoard[knightX + 2, knightY - 1].Color != knightColor)
                {
                    knightMoves[knightX + 2, knightY - 1] = true;
                }
                else
                {
                    knightMoves[knightX + 2, knightY - 1] = true;
                }
            }

            // 7 = left top.
            if (knightX + 1 < 8 && knightX + 1 >= 0 && knightY - 2 >= 0 && knightY - 2 < 8)
            {
                if (currentBoard[knightX + 1, knightY - 2] != null && currentBoard[knightX +1, knightY - 2].Color == knightColor)
                {
                    knightMoves[knightX + 1, knightY - 2] = false;
                }
                else if (currentBoard[knightX + 1, knightY - 2] != null && currentBoard[knightX + 1, knightY - 2].Color != knightColor)
                {
                    knightMoves[knightX + 1, knightY - 2] = true;
                }
                else
                {
                    knightMoves[knightX + 1, knightY - 2] = true;
                }
            }

            // 6 = left bottom.
            if (knightX - 1 < 8 && knightX - 1 >= 0 && knightY - 2 >= 0 && knightY - 2 < 8)
            {
                if (currentBoard[knightX - 1, knightY - 2] != null && currentBoard[knightX - 1, knightY - 2].Color == knightColor)
                {
                    knightMoves[knightX - 1, knightY - 2] = false;
                }
                else if (currentBoard[knightX - 1, knightY - 2] != null && currentBoard[knightX - 1, knightY - 2].Color != knightColor)
                {
                    knightMoves[knightX - 1, knightY - 2] = true;
                }
                else
                {
                    knightMoves[knightX - 1, knightY - 2] = true;
                }
            }

            // 5 = bottom left.
            if (knightX - 2 < 8 && knightX - 2 >= 0 && knightY - 1 >= 0 && knightY - 1 < 8)
            {
                if (currentBoard[knightX - 2, knightY - 1] != null && currentBoard[knightX - 2, knightY - 1].Color == knightColor)
                {
                    knightMoves[knightX - 2, knightY - 1] = false;
                }
                else if (currentBoard[knightX - 2, knightY - 1] != null && currentBoard[knightX - 2, knightY - 1].Color != knightColor)
                {
                    knightMoves[knightX - 2, knightY - 1] = true;
                }
                else
                {
                    knightMoves[knightX - 2, knightY - 1] = true;
                }
            }

            // 4 = bottom right.
            if (knightX - 2 < 8 && knightX - 2 >= 0 && knightY + 1 >= 0 && knightY + 1 < 8)
            {
                if (currentBoard[knightX - 2, knightY + 1] != null && currentBoard[knightX - 2, knightY + 1].Color == knightColor)
                {
                    knightMoves[knightX - 2, knightY + 1] = false;
                }
                else if (currentBoard[knightX - 2, knightY + 1] != null && currentBoard[knightX - 2, knightY + 1].Color != knightColor)
                {
                    knightMoves[knightX - 2, knightY + 1] = true;
                }
                else
                {
                    knightMoves[knightX - 2, knightY + 1] = true;
                }
            }

            // 3 = right bottom.
            if (knightX - 1 < 8 && knightX - 1 >= 0 && knightY + 2 >= 0 && knightY + 2 < 8)
            {
                if (currentBoard[knightX - 1, knightY + 2] != null && currentBoard[knightX - 1, knightY + 2].Color == knightColor)
                {
                    knightMoves[knightX - 1, knightY + 2] = false;
                }
                else if (currentBoard[knightX - 1, knightY + 2] != null && currentBoard[knightX - 1, knightY + 2].Color != knightColor)
                {
                    knightMoves[knightX - 1, knightY + 2] = true;
                }
                else
                {
                    knightMoves[knightX - 1, knightY + 2] = true;
                }
            }

            // 2 = right top.
            if (knightX + 1 < 8 && knightX + 1 >= 0 && knightY + 2 >= 0 && knightY + 2 < 8)
            {
                if (currentBoard[knightX + 1, knightY + 2] != null && currentBoard[knightX + 1, knightY + 2].Color == knightColor)
                {
                    knightMoves[knightX + 1, knightY + 2] = false;
                }
                else if (currentBoard[knightX + 1, knightY + 2] != null && currentBoard[knightX + 1, knightY + 2].Color != knightColor)
                {
                    knightMoves[knightX + 1, knightY + 2] = true;
                }
                else
                {
                    knightMoves[knightX + 1, knightY + 2] = true;
                }
            }

            // 1 = top right.
            if (knightX + 2 < 8 && knightX + 2 >= 0 && knightY + 1 >= 0 && knightY + 1 < 8)
            {
                if (currentBoard[knightX + 2, knightY + 1] != null && currentBoard[knightX + 2, knightY + 1].Color == knightColor)
                {
                    knightMoves[knightX + 2, knightY + 1] = false;
                }
                else if (currentBoard[knightX + 2, knightY + 1] != null && currentBoard[knightX + 2, knightY + 1].Color != knightColor)
                {
                    knightMoves[knightX + 2, knightY + 1] = true;
                }
                else
                {
                    knightMoves[knightX + 2, knightY + 1] = true;
                }
            }

            return knightMoves;
        }
    }
}