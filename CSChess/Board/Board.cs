namespace CSChess.Board
{
    class ChessBoard
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public ChessBoard()
        {
            Lines = 8;
            Columns = 8;
            Pieces = new Piece[8, 8];
        }

        public Piece GetPieceByPosition(int line, int column)
        {
            return Pieces[line, column];
        }

        public void InsertPiece(Piece piece, Position pos)
        {
            Pieces[pos.line, pos.column] = piece;
            piece.Position = pos;
        }
    }
}
