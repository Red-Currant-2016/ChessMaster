namespace ChessMaster2017.BackEnd
{
    using ChessMaster2017.BackEnd.Enums;
    using ChessMaster2017.BackEnd.Contracts;

    /// <summary>
    /// Logic is the same as Bishop ; Check Bishop Summery. 
    /// Special move is not included in the logic.
    /// </summary>
    /// /// <param name="currentBoard"></param>
    /// <returns> bool[,] rookMoves </returns>

    class Rook : ChessPiece, IRook
    {
        public Rook(int x, int y, EnumColor color, EnumType type) : base(x, y, color, type)
        {
        }

        public override bool[,] PossibleMove(IChessPiece[,] currentBoard)
        {
            int rookX = this.CurrentX;
            int rookY = this.CurrentY;

            bool[,] rookMoves = new bool[8, 8];
            EnumColor rookColor = this.Color;

            // Right.
            for (int movesY = rookY + 1; movesY >= 0 && movesY < 8; movesY++)
            {
                int movesX = rookX;

                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == rookColor)
                {
                    rookMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != rookColor)
                {
                    rookMoves[movesX, movesY] = true;
                    break;
                }
                else
                {
                    rookMoves[movesX, movesY] = true;
                }
            }

            // Bottom.
            for (int movesX = rookX - 1; movesX>=0 && movesX < 8; movesX--)
            {
                int movesY = rookY;

                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == rookColor)
                {
                    rookMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != rookColor)
                {
                    rookMoves[movesX, movesY] = true;
                    break;
                }
                else
                {
                    rookMoves[movesX, movesY] = true;
                }
            }

            // Left.
            for (int movesY = rookY-1; movesY>=0 && movesY < 8; movesY--)
            {
                int movesX = rookX;
                
                    if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == rookColor)
                    {
                        rookMoves[movesX, movesY] = false;                       
                        break;
                    }
                    else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != rookColor)
                    {
                        rookMoves[movesX, movesY] = true;                       
                        break;
                    }

                    else
                    {
                        rookMoves[movesX, movesY] = true;
                    }
                }

            // Top.            
            for (int movesX = rookX+1; movesX>=0 && movesX < 8; movesX++)
            {
                int movesY = rookY;

                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == rookColor)
                {
                    rookMoves[movesX, movesY] = false;                    
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != rookColor)
                {
                    rookMoves[movesX, movesY] = true;                
                    break;
                }

                else
                {
                    rookMoves[movesX, movesY] = true;
                }
            }

            return rookMoves; // Return bool rookMoves matrix.
        }
    }
}