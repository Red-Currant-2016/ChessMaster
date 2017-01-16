namespace ChessMaster2017.BackEnd.Contracts
{
    using ChessMaster2017.BackEnd.Enums;

    interface IBoardManger
    {
        void changePlayerTurn();

        bool SelectChessPiece(int x, int y);

        bool[,] GetHighlightedMoves();

        bool isKingCheck();

        bool isValidMove(int x, int y);

        bool isPlayerCheckmate();

        bool MoveChessPiece(int x, int y);

        EnumColor GetPlayerTurn();
    }
}
