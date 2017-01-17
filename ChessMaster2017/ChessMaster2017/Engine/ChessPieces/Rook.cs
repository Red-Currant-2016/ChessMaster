namespace ChessMaster2017.Engine
{
    using ChessMaster2017.Engine.Enums;
    using ChessMaster2017.Engine.Contracts;

    /// <summary>
    /// Logic is the same as Bishop ; Check Bishop Summery. 
    /// Special move is not included in the logic.
    /// Rook uses the same logic as Bishop but it can only move in a straight line.
    /// Rook + Bishop can create the Queen.
    /// </summary>
    /// /// <param name="currentBoard"></param>
    /// <returns> bool[,] rookMoves </returns>

    class Rook : ChessPiece, IRook
    {
        public Rook(int x, int y, EnumChessPieceColor color, EnumChessPieceType type) : base(x, y, color, type)
        {
        }

        public override bool[,] PossibleMove(IChessPiece[,] currentBoard)
        {
            int rookX = this.CurrentX;
            int rookY = this.CurrentY;

            bool[,] rookMoves = new bool[8, 8];
            EnumChessPieceColor rookColor = this.Color;

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