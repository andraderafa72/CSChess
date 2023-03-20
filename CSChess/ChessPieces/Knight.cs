using CSChess.Board;
using CSChess.Board.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSChess.ChessPieces
{
    internal class Knight : Piece
    {
        public Knight(Color color, ChessBoard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "C"; // pt-BR
        }
    }
}
