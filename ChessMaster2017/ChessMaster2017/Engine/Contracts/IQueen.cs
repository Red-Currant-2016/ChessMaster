namespace ChessMaster2017.Engine.Contracts
{
    interface IQueen
    {
        bool[,] PossibleMove(IChessPiece[,] currentBoard);
    }
}
