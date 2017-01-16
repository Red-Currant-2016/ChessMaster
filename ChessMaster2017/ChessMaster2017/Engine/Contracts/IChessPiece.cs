namespace ChessMaster2017.BackEnd.Contracts
{
    using ChessMaster2017.BackEnd.Enums;

    public interface IChessPiece
    {
        int CurrentX { get; }
        int CurrentY { get; }

        bool IsCaptured { get; set; }

        void SetPosition(int x, int y);

        bool[,] PossibleMove(IChessPiece[,] currentBoard);

        EnumColor Color { get; }
        EnumType Type { get; }
    }
}
