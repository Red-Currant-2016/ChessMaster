namespace ChessMaster2017.Engine.Contracts
{
    interface IPawn
    {
        bool[,] PossibleMove(IChessPiece[,] currentBoard);
    }
}
