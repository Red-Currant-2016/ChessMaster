namespace ChessMaster2017.Engine.Contracts
{
    interface IKnight
    {
        bool[,] PossibleMove(IChessPiece[,] currentBoard);
    }
}
