namespace ChessMaster2017.Engine
{
    using ChessMaster2017.Engine.Enums;
    using ChessMaster2017.Engine.Contracts;

    /// <summary>
    /// Serves as a base class for all the different pieces. 
    /// </summary>
    public abstract class ChessPiece : IChessPiece
    {
        private int currentX;
        private int currentY;
        private bool isCaptured;
        private EnumChessPieceType type;
        private EnumChessPieceColor color;

        public ChessPiece(int x, int y, EnumChessPieceColor color, EnumChessPieceType type)
        {
            SetPosition(x, y);
            this.Color = color;
            this.Type = type;
            this.IsCaptured = false;
        }

        public int CurrentX
        {
            get { return this.currentX; }
            private set { this.currentX = value; }
        }
        public int CurrentY
        {
            get { return this.currentY; }
            private set { this.currentY = value; }
        }

        public EnumChessPieceColor Color
        {
            get { return this.color; }
            private set { this.color = value; }
        }

        public EnumChessPieceType Type
        {
            get { return this.type; }
            private set { this.type = value; }
        }

        public bool IsCaptured
        {
            get { return this.isCaptured; }
            set { this.isCaptured = value; }
        }

        public void SetPosition(int x, int y)
        {
            CurrentX = x;
            CurrentY = y;
        }

        public virtual bool[,] PossibleMove(IChessPiece[,] currentBoard)
        {
            return new bool[8, 8];
        }
    }
}
