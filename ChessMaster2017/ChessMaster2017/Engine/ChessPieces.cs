using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster2017.Engine
{
    /// <summary>
    /// Serves as a base class for all the different pieces. 
    /// </summary>
    public abstract class ChessPiece
    {
        public int CurrentX { get; private set; }
        public int CurrentY { get; private set; }

        public EnumColor Color { get; private set; }
        public EnumType Type { get; private set; }
        public bool isCaptured { get; set; }

        public ChessPiece(int x, int y, EnumColor color, EnumType type)
        {
            SetPosition(x, y);

            Color = color;
            Type = type;
            isCaptured = false;
        }

        public void SetPosition(int x, int y)
        {
            CurrentX = x;
            CurrentY = y;
        }

        public virtual bool[,] PossibleMove(ChessPiece[,] currentBoard)
        {
            return new bool[8, 8];
        }
    }
}
