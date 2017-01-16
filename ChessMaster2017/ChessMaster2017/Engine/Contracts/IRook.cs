namespace ChessMaster2017.Engine.Contracts
{
    interface IRook
    {
        bool[,] PossibleMove(IChessPiece[,] currentBoard);
    }
}