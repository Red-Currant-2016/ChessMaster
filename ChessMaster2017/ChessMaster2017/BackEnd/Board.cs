using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster2017.BackEnd
{
    class Board
    {
        private const int BOARD_SIZE = 8;
        private const int TOTAL_CHESS_PIECE_COUNT = 32;

        private ChessPieceColor playerTurn;

        private ChessPiece[,] chessBoard;
        private ChessPiece selectedChessPiece;// contains a copy of a single chessBoard cell

        public List<ChessPiece> chessPiecePrefab;

        private List<ChessPiece> activeChessPieces;
        private List<ChessPiece> capturedChessPieces;

        private bool[,] availableMoves = new bool[BOARD_SIZE, BOARD_SIZE];

        public Board()
        {
            chessBoard = new ChessPiece[BOARD_SIZE, BOARD_SIZE];
            chessPiecePrefab = new List<ChessPiece>(TOTAL_CHESS_PIECE_COUNT);

            InitializeChessPieces();

            SpawnAllChessPieces();

            playerTurn = ChessPieceColor.White;
            selectedChessPiece = null;
        }

        /// <summary>
        /// list of all the chess piece objects
        /// 0-White Rook; 1-White Rook; 2-White Knight; 3-White Knight; 4-White Bishop; 5-White Bishop; 6-White Queen; 7-White King;            8-15 White Pawns;
        /// 16-Black Rook; 17-Black Rook; 18-Black Knight; 19-Black Knight; 20-Black Bishop; 21-Black Bishop; 22-Black King; 23-Black Queen;    24-32 Black Pawns;
        /// </summary>
        private void InitializeChessPieces()
        {
            //WHITE PLAYER
            //Rooks
            chessPiecePrefab.Add(new Rook(0, 0, ChessPieceColor.White, ChessPieceType.Rook));
            chessPiecePrefab.Add(new Rook(0, 7, ChessPieceColor.White, ChessPieceType.Rook));
            //Knights
            chessPiecePrefab.Add(new Knight(0, 1, ChessPieceColor.White, ChessPieceType.Knight));
            chessPiecePrefab.Add(new Knight(0, 6, ChessPieceColor.White, ChessPieceType.Knight));
            //Bishops
            chessPiecePrefab.Add(new Bishop(0, 2, ChessPieceColor.White, ChessPieceType.Bishop));
            chessPiecePrefab.Add(new Bishop(0, 5, ChessPieceColor.White, ChessPieceType.Bishop));
            //Queen
            chessPiecePrefab.Add(new Queen(0, 3, ChessPieceColor.White, ChessPieceType.Queen));// white queen => white squar
            //King
            chessPiecePrefab.Add(new King(0, 4, ChessPieceColor.White, ChessPieceType.King));
            //Pawns
            for(int y = 0; y < 8; y++)
            {
                chessPiecePrefab.Add(new Pawn(1, y, ChessPieceColor.White, ChessPieceType.Pawn));
            }

            //BLACK PLAYER
            //Rooks
            chessPiecePrefab.Add(new Rook(7, 0, ChessPieceColor.Black, ChessPieceType.Rook));
            chessPiecePrefab.Add(new Rook(7, 7, ChessPieceColor.Black, ChessPieceType.Rook));
            //Knights
            chessPiecePrefab.Add(new Knight(7, 1, ChessPieceColor.Black, ChessPieceType.Knight));
            chessPiecePrefab.Add(new Knight(7, 6, ChessPieceColor.Black, ChessPieceType.Knight));
            //Bishops
            chessPiecePrefab.Add(new Bishop(7, 2, ChessPieceColor.Black, ChessPieceType.Bishop));
            chessPiecePrefab.Add(new Bishop(7, 5, ChessPieceColor.Black, ChessPieceType.Bishop));
            //King
            chessPiecePrefab.Add(new King(7, 3, ChessPieceColor.Black, ChessPieceType.King));
            //Queen
            chessPiecePrefab.Add(new Queen(7, 4, ChessPieceColor.Black, ChessPieceType.Queen));// black queen => black squar
            
            //Pawns
            for (int y = 0; y < 8; y++)
            {
                chessPiecePrefab.Add(new Pawn(7, y, ChessPieceColor.Black, ChessPieceType.Pawn));
            }
        }

        /// <summary>
        /// Spawn a chess piece on chessBoard from chessPiecePrefab List
        /// </summary>
        /// <param name="chessPieceIndex">the index of the chess piece in chessPiecePrefab List.</param>
        /// <param name="x"> X coordinate in chessBoard matrix.</param>
        /// <param name="y"> Y coordinate in chessBoard matrix.</param>
        private void SpawnChessPiece(int chessPieceIndex, int x, int y)
        {
            chessBoard[x, y] = chessPiecePrefab[chessPieceIndex];
        }

        /// <summary>
        /// When starting a new game place all chess pieces on chessBoard using SpawnChessPiece()
        /// All of the chess pieces get moved to activeChessPieces List;
        /// </summary>
        private void SpawnAllChessPieces()
        {
            for (int i = 0; i < TOTAL_CHESS_PIECE_COUNT; i++)
            {
                SpawnChessPiece(i, chessPiecePrefab[i].CurrentX, chessPiecePrefab[i].CurrentY);
            }

            activeChessPieces = new List<ChessPiece>(chessPiecePrefab);
        }

        private void SelectChessPiece(int x, int y)
        {
            if(chessBoard[x,y] != null)
            {
                if(playerTurn == chessBoard[x,y].Color)
                {
                    selectedChessPiece = chessBoard[x, y];
                    availableMoves =  selectedChessPiece.PosibleMove();// get available moves
                }
            }
        }

        private void MoveSelectedChessPiece(int x, int y)
        {
            if(selectedChessPiece != null && selectedChessPiece.Color == playerTurn)
            {
                if(availableMoves[x,y] == true)
                {
                    //move chess piece to new cell
                }
                else
                {
                    selectedChessPiece = null;// deselect chess piece
                }
            }
        }

    }
}
