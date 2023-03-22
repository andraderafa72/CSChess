using CSChess.Board.Enums;


namespace CSChess.Board
{
    internal abstract class Piece
    {
        public Position? Position { get; set; }
        public Color Color { get; protected set; }
        public int QttMoves { get; protected set; }
        public ChessBoard Board { get; protected set; }

        public Piece(Color color, ChessBoard board)
        {
            Position = null;
            Color = color;
            Board = board;
            QttMoves = 0;
        }

        public void IncrementMoves() {
            QttMoves++;
        }
        public void DecrementMoves()
        {
            QttMoves--;
        }


        protected virtual bool CanMove(Position pos)
        {
            Piece p = Board.GetPieceByPosition(pos);
            return p == null || p.Color != Color;
        }

        public bool HasAvailableMoves()
        {
            bool[,] mat = AvailableMoves();

            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j]) return true;
                }
            }

            return false;
        }

        public bool CanMoveTo(Position pos)
        {
            return AvailableMoves()[pos.line, pos.column];
        }

        public abstract bool[,] AvailableMoves();
    }
}
