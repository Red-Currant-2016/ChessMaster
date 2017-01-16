namespace ChessMaster2017.BackEnd.Contracts
{
    interface IKnight
    {
        bool[,] PossibleMove(IChessPiece[,] currentBoard);
    }
}
