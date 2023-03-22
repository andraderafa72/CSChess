using CSChess.Board;
using CSChess.Board.Enums;
using CSChess.Match;

namespace CSChess.ChessPieces
{
    internal class King : Piece
    {
        private ChessMatch Match;

        public King(Color color, ChessBoard board, ChessMatch match) : base(color, board)
        {
            Match = match;
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

            Console.WriteLine(this.Color);
            // SPECIAL PLAYS
            if (QttMoves == 0 && !Match.IsCheck)
            {
                // Castle Kingside
                Position rookPositionK = new Position(this.Position.line, this.Position.column + 3);
                if (IsRookAvailableForCastle(rookPositionK))
                {
                    Piece p1 = Board.GetPieceByPosition(new Position(this.Position.line, this.Position.column + 1));
                    Piece p2 = Board.GetPieceByPosition(new Position(this.Position.line, this.Position.column + 2));

                    if (p1 == null & p2 == null)
                    {
                        mat[this.Position.line, this.Position.column + 2] = true;
                    }
                }

                // Castle Queenside
                Position rookPositionQ = new Position(this.Position.line, this.Position.column - 4);
                if (IsRookAvailableForCastle(rookPositionQ))
                {
                    Piece p1 = Board.GetPieceByPosition(new Position(this.Position.line, this.Position.column - 1));
                    Piece p2 = Board.GetPieceByPosition(new Position(this.Position.line, this.Position.column - 2));
                    Piece p3 = Board.GetPieceByPosition(new Position(this.Position.line, this.Position.column - 3));

                    if (p1 == null & p2 == null && p3 == null)
                    {
                        mat[this.Position.line, this.Position.column - 2] = true;
                    }
                }
            }

            return mat;
        }

        public bool IsRookAvailableForCastle(Position pos)
        {
            Piece p = Board.GetPieceByPosition(pos);
            return p != null && p is Rook && p.QttMoves == 0 && p.Color == this.Color;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
