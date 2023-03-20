using CSChess.Board;
using CSChess.Board.Enums;

namespace CSChess.ChessPieces
{
    internal class King : Piece
    {
        public King(Color color, ChessBoard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "K"; 
        }
    }
}
