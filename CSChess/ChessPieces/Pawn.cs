using CSChess.Board;
using CSChess.Board.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSChess.ChessPieces
{
    internal class Pawn : Piece
    {
        public Pawn(Color color, ChessBoard board) : base(color, board)
        {
        }

        public override bool[,] AvailableMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            int lineAux = this.Color == Color.White ? -1 : 1 ;

            // Move Foward
            pos.UpdatePosition(Position.line + lineAux, Position.column);
            if(Board.IsPositionValid(pos) && CanMove(pos))
            {
                if(this.QttMoves == 0) mat[pos.line + lineAux, pos.column] = true;
                mat[pos.line, pos.column] = true;
            }

            // Capture Piece Left
            pos.UpdatePosition(Position.line + lineAux, Position.column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // Capture Piece Right
            pos.UpdatePosition(Position.line + lineAux, Position.column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // Capture Piece Left
            pos.UpdatePosition(Position.line + lineAux, Position.column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            return mat;
        }

        protected override bool CanMove(Position pos)
        {
            Piece p = Board.GetPieceByPosition(pos);
            if(Position.column != pos.column)
            {
                return p != null && p.Color != Color;
            }
            return p == null || p.Color != Color;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
