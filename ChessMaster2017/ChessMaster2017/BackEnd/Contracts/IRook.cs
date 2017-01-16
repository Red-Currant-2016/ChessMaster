namespace ChessMaster2017.BackEnd.Contracts
{
    interface IRook
    {
        bool[,] PossibleMove(IChessPiece[,] currentBoard);
    }
}