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
    /// <returns> bool[,] rockMoves </returns>

    class Rook : ChessPiece
    {
        public Rook(int x, int y, ChessPieceColor color, ChessPieceType type) : base(x, y, color, type)
        {

        }
        public override bool[,] PossibleMove(ChessPiece[,] currentBoard)
        {
            int rockX = this.CurrentX;
            int rockY = this.CurrentY;

            bool[,] rockMoves = new bool[8, 8];
            ChessPieceColor rockColor = this.Color;


            // right
            for (int movesY = rockY + 1; movesY >= 0 && movesY < 8; movesY++)
            {
                int movesX = rockX;

                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == rockColor)
                {
                    rockMoves[movesX, movesY] = false;

                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != rockColor)
                {
                    rockMoves[movesX, movesY] = true;

                    break;
                }

                else
                {
                    rockMoves[movesX, movesY] = true;
                }

            }

            // bottom

            for (int movesX = rockX - 1; movesX>=0 && movesX < 8; movesX--)
            {
                int movesY = rockY;

                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == rockColor)
                {
                    rockMoves[movesX, movesY] = false;

                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != rockColor)
                {
                    rockMoves[movesX, movesY] = true;

                    break;
                }

                else
                {
                    rockMoves[movesX, movesY] = true;
                }

            }

            // left

            for (int movesY = rockY-1; movesY>=0 && movesY < 8; movesY--)
            {
                int movesX = rockX;
                
                    if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == rockColor)
                    {
                        rockMoves[movesX, movesY] = false;
                        
                        break;
                    }
                    else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != rockColor)
                    {
                        rockMoves[movesX, movesY] = true;
                        
                        break;
                    }

                    else
                    {
                        rockMoves[movesX, movesY] = true;
                    }

                }

            

            // top
            
            for (int movesX = rockX+1; movesX>=0 && movesX < 8; movesX--)
            {
                int movesY = rockY;

                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == rockColor)
                {
                    rockMoves[movesX, movesY] = false;
                    
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != rockColor)
                {
                    rockMoves[movesX, movesY] = true;
                    
                    break;
                }

                else
                {
                    rockMoves[movesX, movesY] = true;
                }

            }




            //return bool rockMoves matrix
            return rockMoves;
        }
    }
}
