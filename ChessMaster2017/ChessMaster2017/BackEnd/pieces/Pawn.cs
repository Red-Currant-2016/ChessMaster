using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster2017.BackEnd
{
    class Pawn : ChessPiece
    {
        
       

        public Pawn(int x, int y, ChessPieceColor color, ChessPieceType type) : base(x, y, color, type)
        {
          
        }
        public override bool[,] PossibleMove(ChessPiece[,] currentBoard)
        {
            int pawnX = this.CurrentX;
            int pawnY = this.CurrentY;

            

            bool[,] pawnMoves = new bool[8, 8];
            ChessPieceColor pawnColor = this.Color;

            bool whitePawn = false;

            if (this.Color == ChessPieceColor.White)
            {
                whitePawn = true;
            }


           

            // Top ^ Special move pawn - double forward move

            for (int movesX = pawnX + 2; pawnX==1 && whitePawn && movesX >= 0 && movesX < 8; movesX++)
            {
                int movesY = pawnY;

                if (currentBoard[movesX, movesY] != null)
                {
                    pawnMoves[movesX, movesY] = false;

                    break;
                }
                else
                {
                    pawnMoves[movesX, movesY] = true;

                    break;
                }

            }


            //TOP ^ if the pawn is white it can move upwards - no special exchange
            for (int movesX = pawnX + 1; whitePawn && movesX >= 0 && movesX < 8; movesX++)
            {
                int movesY = pawnY;

                if (currentBoard[movesX, movesY] != null)
                {
                    pawnMoves[movesX, movesY] = false;

                    break;
                }
                else
                {
                    pawnMoves[movesX, movesY] = true;

                    break;
                }

            }
            // Top Right diagonal
            for (int movesX = pawnX + 1, movesY = pawnY - 1; whitePawn && movesX < 8 && movesX >= 0 && movesY < 8 && movesY >= 0; movesX++, movesY--)
            {

                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == pawnColor)
                {
                    pawnMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != pawnColor)
                {
                    pawnMoves[movesX, movesY] = true;
                    break;
                }
                else
                {
                    pawnMoves[movesX, movesY] = false;
                    break;
                }

            }

            // Top Left diagonal
            for (int movesX = pawnX + 1, movesY = pawnY + 1; whitePawn && movesX < 8 && movesX >= 0 && movesY < 8 && movesY >= 0; movesX++, movesY++)
            {

                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == pawnColor)
                {
                    pawnMoves[movesX, movesY] = false;
                    break;
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != pawnColor)
                {
                    pawnMoves[movesX, movesY] = true;
                    break;
                }
                else
                {
                    pawnMoves[movesX, movesY] = false;
                    break;
                }

            }
            
            return pawnMoves;
        }
    }
}
