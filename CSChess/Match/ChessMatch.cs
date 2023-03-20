using CSChess.Board;
using CSChess.Board.Enums;
using CSChess.ChessPieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSChess.Match
{
    internal class ChessMatch
    {
        public ChessBoard MatchBoard { get; private set; }
        private int Turn;
        public Color CurrentPlayer { get; private set; }
        public bool IsFinished { get; set; }

        public ChessMatch()
        {
            MatchBoard = new ChessBoard();
            Turn = 1;
            CurrentPlayer = Color.White;
            IsFinished = false;
            InsertInitialPieces();
        }

        private void InsertInitialPieces()
        {
            // Black pieces
            MatchBoard.InsertPiece(new King(Color.Black, MatchBoard), new Position(0, 3));
            MatchBoard.InsertPiece(new Queen(Color.Black, MatchBoard), new Position(0, 4));
            MatchBoard.InsertPiece(new Rook(Color.Black, MatchBoard), new Position(0, 0));
            MatchBoard.InsertPiece(new Rook(Color.Black, MatchBoard), new Position(0, 7));
            MatchBoard.InsertPiece(new Knight(Color.Black, MatchBoard), new Position(0, 1));
            MatchBoard.InsertPiece(new Knight(Color.Black, MatchBoard), new Position(0, 6));
            MatchBoard.InsertPiece(new Bishop(Color.Black, MatchBoard), new Position(0, 2));
            MatchBoard.InsertPiece(new Bishop(Color.Black, MatchBoard), new Position(0, 5));


            for (int i = 0; i < 8; i++)
            {
                MatchBoard.InsertPiece(new Pawn(Color.Black, MatchBoard), new Position(1, i));
            }

            MatchBoard.InsertPiece(new King(Color.White, MatchBoard), new Position(7, 3));
            MatchBoard.InsertPiece(new Queen(Color.White, MatchBoard), new Position(7, 4));
            MatchBoard.InsertPiece(new Rook(Color.White, MatchBoard), new Position(7, 0));
            MatchBoard.InsertPiece(new Rook(Color.White, MatchBoard), new Position(7, 7));
            MatchBoard.InsertPiece(new Knight(Color.White, MatchBoard), new Position(7, 1));
            MatchBoard.InsertPiece(new Knight(Color.White, MatchBoard), new Position(7, 6));
            MatchBoard.InsertPiece(new Bishop(Color.White, MatchBoard), new Position(7, 2));
            MatchBoard.InsertPiece(new Bishop(Color.White, MatchBoard), new Position(7, 5));


            for (int i = 0; i < 8; i++)
            {
                MatchBoard.InsertPiece(new Pawn(Color.White, MatchBoard), new Position(6, i));
            }

        }

        public void MovePiece(Position origin, Position destiny)
        {
            Piece piece = MatchBoard.RemovePieceByPosition(origin) ?? throw new Exception($"Não há nenhuma peça do jogador {CurrentPlayer} nessa posição.");
            if (piece.Color != CurrentPlayer) throw new Exception($"Essa peça não pertence ao jogador {CurrentPlayer}");
            piece.IncrementMoves(); 

            Piece capturedPiece = MatchBoard.RemovePieceByPosition(destiny);
            MatchBoard.InsertPiece(piece, destiny);

            ChangeTurn();
        }

        private void ChangeTurn()
        {
            Turn++;
            CurrentPlayer = CurrentPlayer == Color.White ? Color.Black : Color.White;
        }
    }
}
