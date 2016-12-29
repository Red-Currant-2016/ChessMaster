using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster2017.BackEnd
{
    /// <summary>
    /// Basic pieceses functionalities
    /// </summary>
    interface Pieces
    {

        void MoveVector(); // calculates piece move/attack vector (* different for pawn)
        void Move(Pieces piece);
        bool IsOnBoard(Pieces piece);
    }
}
