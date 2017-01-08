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

        

        public override bool[,] PossibleMove(ChessPiece[,] currentBoard)
        {
            int bishopX = this.CurrentX;
            int bishopY = this.CurrentY;

            bool[,] bishopMoves = new bool[8, 8];
            ChessPieceColor BishopColor = this.Color;

            if (BishopColor == ChessPieceColor.White)
            {
                // left up diagonal

                bool exitCycle = false;

                for (int movesX = bishopX; movesX < 8; movesX--)
                {
                    for (int movesY = bishopY; movesY < 8; movesY++)
                    {
                        if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == ChessPieceColor.White)
                        {
                            bishopMoves[movesX, movesY] = false;
                            exitCycle = true;
                            break;
                        }
                        else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == ChessPieceColor.Black)
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
            }
            else
            {

            }


            ChessPieceColor PieceColor =  currentBoard[1, 1].Color;



            return bishopMoves;
        }
    }
}
