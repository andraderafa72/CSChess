using CSChess.Board.Enums;


namespace CSChess.Board
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QttMoves { get; protected set; }
        public ChessBoard Board { get; protected set; }

        public Piece(Position position, Color color, ChessBoard board)
        {
            Position = position;
            Color = color;
            Board = board;
            QttMoves = 0;
        }
    }
}
