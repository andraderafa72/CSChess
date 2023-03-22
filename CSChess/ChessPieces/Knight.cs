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
        public override bool[,] AvailableMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            // Move Up-Left
            pos.UpdatePosition(Position.line - 2, Position.column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // Move Up-Right
            pos.UpdatePosition(Position.line - 2, Position.column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // Move Left-Up
            pos.UpdatePosition(Position.line - 1, Position.column - 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // Move Right-Up
            pos.UpdatePosition(Position.line - 1, Position.column + 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // Move Down-Left
            pos.UpdatePosition(Position.line + 2, Position.column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // Move Down-Right
            pos.UpdatePosition(Position.line + 2, Position.column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // Move Left-Down
            pos.UpdatePosition(Position.line + 1, Position.column - 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // Move Right-Down
            pos.UpdatePosition(Position.line + 1, Position.column + 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "C"; // pt-BR
        }
    }
}
