namespace ChessMaster2017.Engine
{
    using ChessMaster2017.Engine.Enums;
    using ChessMaster2017.Engine.Contracts;

    class Bishop : ChessPiece, IBishop
    {
        public Bishop(int x, int y, EnumColor color, EnumType type) : base(x, y, color, type)
        {
        }

        /// <summary>
        /// The method Possible Moves takes "CurrentBoard" to see which squares are available and it applies logic to define
        /// the possible squares for moves as true of false.
        /// 
        /// The logic
        /// 
        /// Lets assume that bishop is white ( EnumColor BishopColor = this.Color; ). 
        /// The Bishop can only move to its diagonals. The logic is the same for all four.
        /// Diagonal 1 up left diagonal - x increases and y increases
        /// we have 3 conditions :
        /// 1 - the space is taken by a figure with the same color - then this space is market as false, the cycle breaks and
        /// the logic starts checking the other 3 diagonals for possible moves.
        /// 
        /// 2-the space is taken but the figure is from the oppossite color - then only an attack is possible, the space is marked
        /// as true and the cycle breaks.
        /// 
        /// 3-the space is free, the cycle will continue to mark spots as free unless it meets condition 1 or 2.
        ///
        /// 
        /// </summary>
        /// <param name="currentBoard"></param>
        /// <returns> bool[,] bishopMoves </returns>
        
        public override bool[,] PossibleMove(IChessPiece[,] currentBoard)
        {
            int bishopX = this.CurrentX;
            int bishopY = this.CurrentY;

            bool[,] bishopMoves = new bool[8, 8];
            EnumColor BishopColor = this.Color;


            // bottom right diagonal
            for (int movesX = bishopX - 1, movesY = bishopY + 1; movesX < 8 && movesX >= 0 && movesY < 8 && movesY >= 0; movesX--, movesY++)
            {
                
                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == BishopColor)
                {
                    bishopMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != BishopColor)
                {
                    bishopMoves[movesX, movesY] = true;
                    break;
                }
                else
                {
                    bishopMoves[movesX, movesY] = true;
                }
                
            }

            // top right
            for (int movesX = bishopX + 1, movesY = bishopY + 1; movesX < 8 && movesX >= 0 && movesY < 8 && movesY >= 0; movesX++, movesY++)
            {
                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == BishopColor)
                {
                    bishopMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != BishopColor)
                {
                    bishopMoves[movesX, movesY] = true;
                    break;
                }
                else
                {
                    bishopMoves[movesX, movesY] = true;
                }
            }

            // Top Left
            for (int movesX = bishopX + 1, movesY = bishopY - 1; movesX < 8 && movesX >= 0 && movesY < 8 && movesY >= 0; movesX++, movesY--)
            {
                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == BishopColor)
                {
                    bishopMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != BishopColor)
                {
                    bishopMoves[movesX, movesY] = true;
                    break;
                }

                else
                {
                    bishopMoves[movesX, movesY] = true;
                }
            }

            // bottom right
            for (int movesX = bishopX - 1, movesY = bishopY - 1; movesX < 8 && movesX >= 0 && movesY < 8 && movesY >= 0; movesX--, movesY--)
            {
                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == BishopColor)
                {
                    bishopMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != BishopColor)
                {
                    bishopMoves[movesX, movesY] = true;
                    break;
                }
                else
                {
                    bishopMoves[movesX, movesY] = true;
                }
            }

            //return bool bishopMoves matrix
            return bishopMoves;
        }
    }
}
