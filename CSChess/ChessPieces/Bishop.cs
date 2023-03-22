using CSChess.Board;
using CSChess.Board.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSChess.ChessPieces
{
    internal class Bishop : Piece
    {
        public Bishop(Color color, ChessBoard board) : base(color, board)
        {
        }

        public override bool[,] AvailableMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

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
            pos.UpdatePosition(Position.line + 1, Position.column - 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
                Piece p = Board.GetPieceByPosition(pos);
                if (p != null && p.Color != Color) break;
                pos.UpdatePosition(pos.line + 1, pos.column - 1);
            }

            // Move Up-Right
            pos.UpdatePosition(Position.line - 1, Position.column + 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
                Piece p = Board.GetPieceByPosition(pos);
                if (p != null && p.Color != Color) break;
                pos.UpdatePosition(pos.line - 1, pos.column + 1);
            }

            // Move Down-Right
            pos.UpdatePosition(Position.line + 1, Position.column + 1);
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
            return "B";
        }
    }
}
