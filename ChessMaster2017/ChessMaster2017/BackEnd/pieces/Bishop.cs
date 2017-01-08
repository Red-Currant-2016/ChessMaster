using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster2017.BackEnd
{
    class Bishop : ChessPiece
    {
        public Bishop(int x, int y, ChessPieceColor color, ChessPieceType type) : base(x, y, color, type)
        {
        }

        /// <summary>
        /// The method Possible Moves takes "CurrentBoard" to see which squares are available and it applies logic to define
        /// the possible squares for moves as true of false.
        /// 
        /// The logic
        /// 
        /// Lets assume that bishop is white ( ChessPieceColor BishopColor = this.Color; ). 
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
        /// <returns></returns>


        public override bool[,] PossibleMove(ChessPiece[,] currentBoard)
        {
            int bishopX = this.CurrentX;
            int bishopY = this.CurrentY;

            bool[,] bishopMoves = new bool[8, 8];
            ChessPieceColor BishopColor = this.Color;

            
                // left up diagonal

                bool exitCycle = false;

                for (int movesX = bishopX; movesX < 8; movesX--)
                {
                    for (int movesY = bishopY; movesY < 8; movesY++)
                    {
                        if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == BishopColor)
                        {
                            bishopMoves[movesX, movesY] = false;
                            exitCycle = true;
                            break;
                        }
                        else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != BishopColor)
                        {
                            bishopMoves[movesX, movesY] = true;
                            exitCycle = true;
                            break;
                        }

                        else
                        {
                            bishopMoves[movesX, movesY] = true;
                        }
                        
                    }
                    if (exitCycle)
                    {
                        exitCycle = false;
                        break;
                        
                    }
                }

            // right up diagonal
            for (int movesX = bishopX; movesX < 8; movesX++)
            {
                for (int movesY = bishopY; movesY < 8; movesY++)
                {
                    if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == BishopColor)
                    {
                        bishopMoves[movesX, movesY] = false;
                        exitCycle = true;
                        break;
                    }
                    else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != BishopColor)
                    {
                        bishopMoves[movesX, movesY] = true;
                        exitCycle = true;
                        break;
                    }

                    else
                    {
                        bishopMoves[movesX, movesY] = true;
                    }

                }
                if (exitCycle)
                {
                    exitCycle = false;
                    break;

                }
            }



            // left bottom diagonal

            

            for (int movesX = bishopX; movesX < 8; movesX++)
            {
                for (int movesY = bishopY; movesY < 8; movesY--)
                {
                    if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == BishopColor)
                    {
                        bishopMoves[movesX, movesY] = false;
                        exitCycle = true;
                        break;
                    }
                    else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != BishopColor)
                    {
                        bishopMoves[movesX, movesY] = true;
                        exitCycle = true;
                        break;
                    }

                    else
                    {
                        bishopMoves[movesX, movesY] = true;
                    }

                }
                if (exitCycle)
                {
                    exitCycle = false;
                    break;

                }
            }

            // right bottom diagonal

           

            for (int movesX = bishopX; movesX < 8; movesX--)
            {
                for (int movesY = bishopY; movesY < 8; movesY--)
                {
                    if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == BishopColor)
                    {
                        bishopMoves[movesX, movesY] = false;
                        exitCycle = true;
                        break;
                    }
                    else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != BishopColor)
                    {
                        bishopMoves[movesX, movesY] = true;
                        exitCycle = true;
                        break;
                    }

                    else
                    {
                        bishopMoves[movesX, movesY] = true;
                    }

                }
                if (exitCycle)
                {
                    exitCycle = false;
                    break;

                }
            }



            return bishopMoves;
        }
    }
}
