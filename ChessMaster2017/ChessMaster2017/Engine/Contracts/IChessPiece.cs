namespace ChessMaster2017.Engine.Contracts
{
    using ChessMaster2017.Engine.Enums;

    public interface IChessPiece
    {
        int CurrentX { get; }
        int CurrentY { get; }

        bool IsCaptured { get; set; }

        void SetPosition(int x, int y);

        bool[,] PossibleMove(IChessPiece[,] currentBoard);

        EnumChessPieceColor Color { get; }
        EnumChessPieceType Type { get; }
    }
}
