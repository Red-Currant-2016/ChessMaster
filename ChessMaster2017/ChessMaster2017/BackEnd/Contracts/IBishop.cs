namespace ChessMaster2017.BackEnd.Contracts
{
    interface IBishop
    {
        bool[,] PossibleMove(IChessPiece[,] currentBoard);
    }
}
