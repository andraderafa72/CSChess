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

        public override bool[,] AvailableMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            // Move Up
            pos.UpdatePosition(Position.line, Position.column - 1);
            bool HasPieceFoward = false;
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
                Piece p = Board.GetPieceByPosition(pos);
                if (p != null && p.Color != Color) break;
                pos.UpdatePosition(pos.line - 1, pos.column);
            }

            // Move Down
            pos.UpdatePosition(Position.line, Position.column + 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
                Piece p = Board.GetPieceByPosition(pos);
                if (p != null && p.Color != Color) break;
                pos.UpdatePosition(pos.line + 1, pos.column);
            }

            // Move Left
            pos.UpdatePosition(Position.line - 1, Position.column);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
                Piece p = Board.GetPieceByPosition(pos);
                if (p != null && p.Color != Color) break;
                pos.UpdatePosition(pos.line, pos.column - 1);
            }

            // Move Right
            pos.UpdatePosition(Position.line + 1, Position.column);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
                Piece p = Board.GetPieceByPosition(pos);
                if (p != null && p.Color != Color) break;
                pos.UpdatePosition(pos.line, pos.column + 1);
            }

            // Move Up-Left
            pos.UpdatePosition(Position.line - 1, Position.column - 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
                Piece p = Board.GetPieceByPosition(pos);
                if (p != null && p.Color != Color) break;
                pos.UpdatePosition(pos.line - 1, pos.column - 1);
            }

            // Move Down-Left
            pos.UpdatePosition(Position.line, Position.column + 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
                Piece p = Board.GetPieceByPosition(pos);
                if (p != null && p.Color != Color) break;
                pos.UpdatePosition(pos.line + 1, pos.column - 1);
            }
            // Move Up-Right
            pos.UpdatePosition(Position.line - 1, Position.column - 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
                Piece p = Board.GetPieceByPosition(pos);
                if (p != null && p.Color != Color) break;
                pos.UpdatePosition(pos.line + 1, pos.column - 1);
            }

            // Move Down-Right
            pos.UpdatePosition(Position.line, Position.column + 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
                Piece p = Board.GetPieceByPosition(pos);
                if (p != null && p.Color != Color) break;
                pos.UpdatePosition(pos.line + 1, pos.column + 1);
            }

            return mat;
        }
        public override string ToString()
        {
            return "Q";
        }
    }
}
