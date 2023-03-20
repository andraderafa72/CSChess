using CSChess.Board;
using CSChess.Board.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSChess.ChessPieces
{
    internal class Rook : Piece
    {
        public Rook(Color color, ChessBoard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "T"; // pt-BR
        }
    }
}
