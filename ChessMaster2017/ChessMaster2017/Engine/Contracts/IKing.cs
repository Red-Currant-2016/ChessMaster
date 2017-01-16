namespace ChessMaster2017.Engine.Contracts
{
    interface IKing
    {
        bool HasMoved { get; }

        bool isKingChecked(IChessPiece[,] currentBoard);
        bool[,] PossibleMove(IChessPiece[,] currentBoard);
    }
}
