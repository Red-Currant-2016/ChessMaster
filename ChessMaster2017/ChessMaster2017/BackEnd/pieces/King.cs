using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster2017.BackEnd
{
    class King : ChessPiece
    {
        public bool isCheck { get; set; }

        public King(int x, int y, ChessPieceColor color, ChessPieceType type) : base(x, y, color, type)
        {
            this.isCheck = false;
        }

        /// <summary>
        /// If King is checked possible moves will be calculated normaly.
        /// </summary>
        /// <param name="currentBoard"></param>
        /// <returns></returns>
        public override bool[,] PossibleMove(ChessPiece[,] currentBoard)
        {
            int kingX = this.CurrentX;
            int kingY = this.CurrentY;

            bool[,] kingMoves = new bool[8, 8];
            ChessPieceColor kingColor = this.Color;

            //TODO king posible move logic


            return kingMoves;
        }
    }
}
