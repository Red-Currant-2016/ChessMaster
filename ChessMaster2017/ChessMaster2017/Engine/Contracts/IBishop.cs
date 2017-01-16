namespace ChessMaster2017.Engine.Contracts
{
    interface IBishop
    {
        bool[,] PossibleMove(IChessPiece[,] currentBoard);
    }
}
