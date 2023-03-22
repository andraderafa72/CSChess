using CSChess.Exceptions;
using System.Data.Common;

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
            ValidatePosition(new Position(line, column));

            return Pieces[line, column];
        }

        public Piece GetPieceByPosition(Position pos)
        {
            ValidatePosition(pos);
            return Pieces[pos.line, pos.column];
        }

        public bool HasPieceAtPosition(Position pos)
        {
            ValidatePosition(pos);
            return Pieces[pos.line, pos.column] != null;
        }

        public void InsertPiece(Piece piece, Position pos)
        {
            ValidatePosition(pos);
            if (HasPieceAtPosition(pos)) throw new BoardException("Já existe uma peça nessa posição");

            Pieces[pos.line, pos.column] = piece;
            piece.Position = pos;
        }

        public Piece RemovePieceByPosition(Position pos)
        {
            Piece piece = GetPieceByPosition(pos);
            if (piece == null) return null;

            piece.Position = null;
            Pieces[pos.line, pos.column] = null;

            return piece;
        }

        public bool IsPositionValid(Position pos)
        {
            bool IsLineValid = pos.line < Lines && pos.line >= 0;
            if (!IsLineValid) return false;
            bool IsColumnValid = pos.column < Columns && pos.column >= 0;
            if (!IsColumnValid) return false;

            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!IsPositionValid(pos)) throw new BoardException("Invalid Position.");
        }
    }
}
