using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster2017.BackEnd
{
    class Pawn : ChessPiece
    {

        private bool hasMoved;

        public Pawn(int x, int y, ChessPieceColor color, ChessPieceType type) : base(x, y, color, type)
        {
            this.hasMoved = true;
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
            


         // //TOP ^
         // for (int movesX = pawnX + 1; whitePawn && movesX >= 0 && movesX < 8; movesX++)
         // {
         //     int movesY = pawnY;
         //
         //     if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == pawnColor)
         //     {
         //         pawnMoves[movesX, movesY] = false;
         //
         //         break;
         //     }
         //     else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != pawnColor)
         //     {
         //         pawnMoves[movesX, movesY] = true;
         //
         //         break;
         //     }
         //
         // }

                return pawnMoves;
        }
    }
}
