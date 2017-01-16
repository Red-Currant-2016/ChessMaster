namespace ChessMaster2017.BackEnd.Contracts
{
    interface IQueen
    {
        bool[,] PossibleMove(IChessPiece[,] currentBoard);
    }
}
