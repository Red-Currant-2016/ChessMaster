namespace ChessMaster2017.Engine
{
    using ChessMaster2017.Engine.Enums;
    using ChessMaster2017.Engine.Contracts;

    class Pawn : ChessPiece, IPawn
    {
        /// <summary>
        /// Pawn Logic + Start Position special move.
        /// 1st - Check if pawn is white or black with bool whitePawn
        /// 2nd - Check if pawn is at its starting position
        /// 3rd - if pawn is white it can move up or if it has a back figure on its
        /// diagonals it can move there too.
        /// 4th - code does the same with black pawn
        /// 
        /// at the end it returns a matrix bool [,] pawnMoves
        /// 
        /// </summary>

        public Pawn(int x, int y, EnumChessPieceColor color, EnumChessPieceType type) : base(x, y, color, type)
        {

        }

        public override bool[,] PossibleMove(IChessPiece[,] currentBoard)
        {
            int pawnX = this.CurrentX;
            int pawnY = this.CurrentY;

            bool[,] pawnMoves = new bool[8, 8];
            EnumChessPieceColor pawnColor = this.Color;

            bool whitePawn = false;

            if (this.Color == EnumChessPieceColor.White)
            {
                whitePawn = true;
            }

            // WHITE PAWN LOGIC:
            // Top ^ Special move pawn - double forward move.
            int movesX = pawnX + 2;
            int movesY = pawnY;
            if ( pawnX == 1 && whitePawn && movesX >= 0 && movesX < 8)
            {
                

                if (currentBoard[movesX, movesY] != null)
                {
                    pawnMoves[movesX, movesY] = false;
                    
                }
                else
                {
                    pawnMoves[movesX, movesY] = true;
                    
                }
            }

            // Top ^ if the pawn is white it can move upwards - no special exchange.
            movesX = pawnX + 1;
            movesY = pawnY;
            if (whitePawn && movesX >= 0 && movesX < 8)
            {
                

                if (currentBoard[movesX, movesY] != null)
                {
                    pawnMoves[movesX, movesY] = false;
                    
                }
                else
                {
                    pawnMoves[movesX, movesY] = true;
                    
                }
            }

            // Top Right diagonal.
            movesX = pawnX + 1;
            movesY = pawnY - 1;
            if (  whitePawn && movesX < 8 && movesX >= 0 && movesY < 8 && movesY >= 0)
            {
                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == pawnColor)
                {
                    pawnMoves[movesX, movesY] = false;
                    
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != pawnColor)
                {
                    pawnMoves[movesX, movesY] = true;
                    
                }
                else
                {
                    pawnMoves[movesX, movesY] = false;
                    
                }
            }

            // Top Left diagonal.
            movesX = pawnX + 1;
            movesY = pawnY + 1;
            if (whitePawn && movesX < 8 && movesX >= 0 && movesY < 8 && movesY >= 0)
            {
                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == pawnColor)
                {
                    pawnMoves[movesX, movesY] = false;
                    
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != pawnColor)
                {
                    pawnMoves[movesX, movesY] = true;
                    
                }
                else
                {
                    pawnMoves[movesX, movesY] = false;
                    
                }
            }

            // BLACK PAWN LOGIC:
            // Bottom ^ Special move pawn - double forward move.
            movesX = pawnX - 2;
            if (pawnX == 6 && !whitePawn && movesX >= 0 && movesX < 8)
            {
                movesY = pawnY;

                if (currentBoard[movesX, movesY] != null)
                {
                    pawnMoves[movesX, movesY] = false;
                   
                }
                else
                {
                    pawnMoves[movesX, movesY] = true;
                    
                }
            }

            // Bottom ^ if the pawn is white it can move upwards - no special exchange.
            movesX = pawnX - 1;
            movesY = pawnY;
            if ( !whitePawn && movesX >= 0 && movesX < 8)
            {
                 

                if (currentBoard[movesX, movesY] != null)
                {
                    pawnMoves[movesX, movesY] = false;
                    
                }
                else
                {
                    pawnMoves[movesX, movesY] = true;
                    
                }
            }

            // Bottom Right diagonal.
            movesX = pawnX - 1;
            movesY = pawnY + 1;
            if (!whitePawn && movesX < 8 && movesX >= 0 && movesY < 8 && movesY >= 0)
            {
                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == pawnColor)
                {
                    pawnMoves[movesX, movesY] = false;
                    
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != pawnColor)
                {
                    pawnMoves[movesX, movesY] = true;
                   
                }
                else
                {
                    pawnMoves[movesX, movesY] = false;
                    
                }
            }

            // Bottom Left diagonal.
            movesX = pawnX - 1;
            movesY = pawnY - 1;
            if (!whitePawn && movesX < 8 && movesX >= 0 && movesY < 8 && movesY >= 0)
            {
                if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color == pawnColor)
                {
                    pawnMoves[movesX, movesY] = false;
                    
                }
                else if (currentBoard[movesX, movesY] != null && currentBoard[movesX, movesY].Color != pawnColor)
                {
                    pawnMoves[movesX, movesY] = true;
                    
                }
                else
                {
                    pawnMoves[movesX, movesY] = false;
                    
                }
            }

            return pawnMoves;
        }
    }
}
