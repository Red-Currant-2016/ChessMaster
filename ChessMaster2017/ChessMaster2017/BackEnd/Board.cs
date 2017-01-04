using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster2017.BackEnd
{
    class Board
    {
        private Pieces[,] board;

        public Board()
        {
            board = new Pieces[8, 8]; // 0 - 7 indexses
            //implement new game setup board
            board[0, 0] = new Rook();
            board[0, 1] = new Knight();
            //gjhgkgj

            board[1, 1] = board[0, 1];//movement example
            board[0, 1] = null;
        }



        
    }
}
