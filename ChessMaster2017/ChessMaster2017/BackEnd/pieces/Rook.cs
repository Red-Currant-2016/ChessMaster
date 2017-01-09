using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster2017.BackEnd
{
    /// <summary>
    /// Logic is the same as Bishop ; Check Bishop Summery. 
    /// Special move is not included in the logic.
    /// </summary>
    /// /// <param name="currentBoard"></param>
    /// <returns> bool[,] rookMoves </returns>

    class Rook : ChessPiece
    {
        public Rook(int x, int y, ChessPieceColor color, ChessPieceType type) : base(x, y, color, type)
        {

        }
        public override bool[,] PossibleMove(ChessPiece[,] currentBoard)
        {
            int rookX = this.CurrentX;
            int rookY = this.CurrentY;

            bool[,] rookMoves = new bool[8, 8];
            ChessPieceColor rookColor = this.Color;


            // right
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

            // bottom

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

            // left

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

            

            // top
            
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




            //return bool rookMoves matrix
            return rookMoves;
        }
    }
}
