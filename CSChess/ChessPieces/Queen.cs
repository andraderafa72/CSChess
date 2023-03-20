using CSChess.Board;
using CSChess.Board.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSChess.ChessPieces
{
    internal class Queen : Piece
    {
        public Queen(Color color, ChessBoard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
