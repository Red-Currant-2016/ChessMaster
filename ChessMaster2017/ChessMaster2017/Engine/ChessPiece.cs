using System;
using System.Collections.Generic;
namespace ChessMaster2017.Engine
{
    /// <summary>
    /// Serves as a base class for all the different pieces. 
    /// </summary>
    public abstract class ChessPiece
    {
        private Position currentPosition;

        public int CurrentX
        {
            get
            {
                return currentPosition.x;
            }
        }
        public int CurrentY
        {
            get
            {
                return currentPosition.y;
            }
        }

        public EnumChessPieceColor Color { get; private set; }
        public EnumChessPieceType Type { get; private set; }
        public bool isCaptured { get; set; }


        public ChessPiece(int x, int y, EnumChessPieceColor color, EnumChessPieceType type)
        {
            SetPosition(x, y);

            Color = color;
            Type = type;
            isCaptured = false;
        }

        public Position GetPosition()
        {
            return currentPosition;
        }

        public void SetPosition(int x, int y)
        {
            currentPosition.x = x;
            currentPosition.y = y;
        }

        public virtual bool[,] PossibleMove(ChessPiece[,] currentBoard)
        {
            return new bool[8, 8];
        }
    }
}
