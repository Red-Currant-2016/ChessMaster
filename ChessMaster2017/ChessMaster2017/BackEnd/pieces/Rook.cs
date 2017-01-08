using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster2017.BackEnd
{
    /// <summary>
    /// Logic is the same as Bishop ; Check Bishop Summery. 
    /// </summary>

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


            // left

            

            for (int movesX = rockX; movesX < 8; movesX--)
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



            // right
            for (int movesX = rockX; movesX < 8; movesX++)
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



            // top



            for (int movesY = rockY; movesY < 8; movesY--)
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



            for (int movesY = rockY; movesY < 8; movesY--)
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



            return rockMoves;
        }
    }
}
