namespace ChessMaster2017.BackEnd.Contracts
{
    interface IKing
    {
        bool HasMoved { get; }

        bool isKingChecked(IChessPiece[,] currentBoard);
        bool[,] PossibleMove(IChessPiece[,] currentBoard);
    }
}
