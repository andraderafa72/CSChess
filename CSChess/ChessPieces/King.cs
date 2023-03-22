using CSChess.Board;
using CSChess.Board.Enums;

namespace CSChess.ChessPieces
{
    internal class King : Piece
    {
        public King(Color color, ChessBoard board) : base(color, board)
        {
        }

        public override bool[,] AvailableMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            // Move Up
            pos.UpdatePosition(Position.line - 1, Position.column);
            if (Board.IsPositionValid(pos) && CanMove(pos))
                mat[pos.line, pos.column] = true;

            // Move Down
            pos.UpdatePosition(Position.line + 1, Position.column);
            if (Board.IsPositionValid(pos) && CanMove(pos))
                mat[pos.line, pos.column] = true;

            // Move Left
            pos.UpdatePosition(Position.line, Position.column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
                mat[pos.line, pos.column] = true;

            // Move Right
            pos.UpdatePosition(Position.line, Position.column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
                mat[pos.line, pos.column] = true;

            // Move Up-Left
            pos.UpdatePosition(Position.line - 1, Position.column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
                mat[pos.line, pos.column] = true;

            // Move Up-Right
            pos.UpdatePosition(Position.line - 1, Position.column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
                mat[pos.line, pos.column] = true;

            // Move Down-Left
            pos.UpdatePosition(Position.line + 1, Position.column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
                mat[pos.line, pos.column] = true;

            // Move Down-Right
            pos.UpdatePosition(Position.line + 1, Position.column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
                mat[pos.line, pos.column] = true;


            return mat;
        }

        public override string ToString()
        {
            return "K"; 
        }
    }
}
