using CSChess.Board;
using CSChess.Board.Enums;
using CSChess.ChessPieces;
using CSChess.Exceptions;

namespace CSChess.Match
{
    internal class ChessMatch
    {
        public ChessBoard MatchBoard { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool IsFinished { get; set; }
        public bool IsCheck { get; set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;

        public ChessMatch()
        {
            MatchBoard = new ChessBoard();
            Turn = 1;
            CurrentPlayer = Color.White;
            IsFinished = false;
            IsCheck = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            InsertInitialPieces();
        }

        public void InsertNewPiece(char column, int line, Piece piece)
        {
            MatchBoard.InsertPiece(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }
        public void InsertNewPiece(int column, int line, Piece piece)
        {
            MatchBoard.InsertPiece(piece, new Position(line, column));
            Pieces.Add(piece);
        }

        public HashSet<Piece> GetCapturedPieces(Color color)
        {
            HashSet<Piece> result = new HashSet<Piece>();
            foreach (Piece piece in CapturedPieces)
                if (piece.Color == color) result.Add(piece);

            return result;
        }

        public HashSet<Piece> GetInGamePieces(Color color)
        {
            HashSet<Piece> result = new HashSet<Piece>();
            foreach (Piece piece in Pieces)
                if (piece.Color == color) result.Add(piece);

            result.ExceptWith(GetCapturedPieces(color));
            return result;
        }

        private void InsertInitialPieces()
        {
            // Black pieces
            InsertNewPiece('a', 8, new Rook(Color.Black, MatchBoard));
            InsertNewPiece('b', 8, new Knight(Color.Black, MatchBoard));
            InsertNewPiece('c', 8, new Bishop(Color.Black, MatchBoard));
            InsertNewPiece('d', 8, new King(Color.Black, MatchBoard));
            InsertNewPiece('e', 8, new Queen(Color.Black, MatchBoard));
            InsertNewPiece('f', 8, new Bishop(Color.Black, MatchBoard));
            InsertNewPiece('g', 8, new Knight(Color.Black, MatchBoard));
            InsertNewPiece('h', 8, new Rook(Color.Black, MatchBoard));

            for (int i = 0; i < 8; i++)
            {
                InsertNewPiece(i, 1, new Pawn(Color.Black, MatchBoard));
            }

            // WHITE PIECES
            InsertNewPiece('a', 1, new Rook(Color.White, MatchBoard));
            InsertNewPiece('b', 1, new Knight(Color.White, MatchBoard));
            InsertNewPiece('c', 1, new Bishop(Color.White, MatchBoard));
            InsertNewPiece('d', 1, new King(Color.White, MatchBoard));
            InsertNewPiece('e', 1, new Queen(Color.White, MatchBoard));
            InsertNewPiece('f', 1, new Bishop(Color.White, MatchBoard));
            InsertNewPiece('g', 1, new Knight(Color.White, MatchBoard));
            InsertNewPiece('h', 1, new Rook(Color.White, MatchBoard));

            for (int i = 0; i < 8; i++)
            {
                InsertNewPiece(i, 6, new Pawn(Color.White, MatchBoard));
            }

        }

        private Piece MovePiece(Position origin, Position destiny)
        {
            Piece piece = MatchBoard.RemovePieceByPosition(origin) ?? throw new Exception($"Não há nenhuma peça do jogador {CurrentPlayer} nessa posição.");
            piece.IncrementMoves();

            Piece capturedPiece = MatchBoard.RemovePieceByPosition(destiny);
            if (capturedPiece != null) CapturedPieces.Add(capturedPiece);

            MatchBoard.InsertPiece(piece, destiny);


            return capturedPiece;
        }

        public void UndoMove(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = MatchBoard.RemovePieceByPosition(destiny);
            MatchBoard.InsertPiece(p, origin);
            if (capturedPiece != null)
            {
                MatchBoard.InsertPiece(capturedPiece, destiny);
                CapturedPieces.Remove(capturedPiece);
            }
            p.DecrementMoves();
        }

        public void PerformMove(Position origin, Position destiny)
        {
            Piece capturedPiece = MovePiece(origin, destiny);

            if (IsPlayerOnCheck(CurrentPlayer))
            {
                UndoMove(origin, destiny, capturedPiece);
                throw new BoardException("You can't get yourself in Check.");
            }

            if (IsPlayerOnCheck(Opponent(CurrentPlayer)))
            {
                IsCheck = true;
            }
            else
            {
                IsCheck = false;
            }


            if (capturedPiece != null && capturedPiece is King)
            {
                UndoMove(origin, destiny, capturedPiece);
                throw new BoardException("You can't capture the king");
            }

            if (IsCheckmate(Opponent(CurrentPlayer)))
            {
                Console.WriteLine("CHECKMATE");
                IsFinished = true;
            }
            else
            {
                ChangeTurn();
            }
        }

        public Piece ValidateOriginPosition(Position origin)
        {
            Piece p = MatchBoard.GetPieceByPosition(origin);
            if (p == null) throw new BoardException("Invalid origin position.");
            if (!p.HasAvailableMoves()) throw new BoardException("This piece has no available moves.");
            if (p.Color != CurrentPlayer) throw new BoardException("That's not your piece.");
            return p;
        }

        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!MatchBoard.GetPieceByPosition(origin).CanMoveTo(destiny))
                throw new BoardException("Invalid destiny position.");
        }

        public bool IsPlayerOnCheck(Color color)
        {
            Piece king = King(color) ?? throw new BoardException("Where's the King???");

            foreach (Piece piece in GetInGamePieces(Opponent(color)))
            {
                bool[,] mat = piece.AvailableMoves();

                if (mat[king.Position.line, king.Position.column])
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsCheckmate(Color color)
        {
            if (!IsPlayerOnCheck(color)) return false;
            foreach (Piece piece in GetInGamePieces(color))
            {
                bool[,] mat = piece.AvailableMoves();

                for (int i = 0; i < MatchBoard.Lines; i++)
                {
                    for (int j = 0; j < MatchBoard.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = piece.Position;
                            Position destiny = new(i, j);
                            Piece capturedPiece = MovePiece(origin, destiny);
                            bool x = IsPlayerOnCheck(color);
                            UndoMove(origin, destiny, capturedPiece);
                            if (!x)
                            {
                                return false;
                            }
                        }
                    }
                }

            }

            return true;

        }
        private void ChangeTurn()
        {
            Turn++;
            CurrentPlayer = CurrentPlayer == Color.White ? Color.Black : Color.White;
        }

        private Color Opponent(Color color)
        {
            return color == Color.White ? Color.Black : Color.White;
        }

        private Piece King(Color color)
        {
            foreach (Piece piece in GetInGamePieces(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }

            return null;
        }
    }
}
