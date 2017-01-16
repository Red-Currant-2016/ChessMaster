namespace ChessMaster2017.BackEnd.Contracts
{
    interface IPawn
    {
        bool[,] PossibleMove(IChessPiece[,] currentBoard);
    }
}
