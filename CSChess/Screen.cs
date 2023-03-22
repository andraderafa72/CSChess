using CSChess.Board;
using CSChess.Board.Enums;
using CSChess.Match;

namespace CSChess
{
    internal class Screen
    {
        public static void PrintBoard(ChessBoard board)
        {
            for (int i = 0; i < 8; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write((8 - i) + "|");
                Console.ResetColor();
                for (int j = 0; j < 8; j++)
                {
                    Piece piece = board.GetPieceByPosition(i, j);

                    if (piece != null)
                    {
                        PrintPiece(piece);
                    }
                    else
                    {
                        Console.Write(" - ");
                    }
                }
                Console.WriteLine("");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   ______________________");
            Console.WriteLine("   a  b  c  d  e  f  g  h ");
            Console.ResetColor();
        }

        public static void PrintBoard(ChessBoard board, bool[,] availableMoves)
        {
            for (int i = 0; i < 8; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write((8 - i) + "|");
                Console.ResetColor();
                for (int j = 0; j < 8; j++)
                {
                    Piece piece = board.GetPieceByPosition(i, j);
                    PrintPiece(piece, availableMoves[i, j]);
                }
                Console.WriteLine("");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   ______________________");
            Console.WriteLine("   a  b  c  d  e  f  g  h ");
            Console.ResetColor();
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.Black) Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($" {piece} ");
            Console.ResetColor();
        }

        public static void PrintPiece(Piece piece, bool canMove)
        {
            if (canMove) Console.BackgroundColor = ConsoleColor.DarkGray;
            if (piece != null)
            {
                if (piece.Color == Color.Black) Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($" {piece} ");
            }
            else
            {
                Console.Write(" - ");
            }
            Console.ResetColor();
        }

        public static Position ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            Position p = (new ChessPosition(column, line)).ToPosition();
            return p;
        }

        public static void PrintMatch(ChessMatch match)
        {
            PrintBoard(match.MatchBoard);
            Console.WriteLine();
            Console.WriteLine($"Turn: {match.Turn}");
            Console.WriteLine($"Player: {match.CurrentPlayer}");
            Console.WriteLine("---------------");
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("---------------");
            if (!match.IsFinished)
            {
            if (match.IsCheck) Console.WriteLine("You're in CHECK");
            }else
            {
                Console.WriteLine("CHECKMATE");
                Console.WriteLine($"Winner: {match.CurrentPlayer}");
            }
        }

        public static void PrintMatch(ChessMatch match, bool[,] availableMoves)
        {
            PrintBoard(match.MatchBoard, availableMoves);
            PrintCapturedPieces(match);
            Console.WriteLine();
        }

        public static void PrintCapturedPieces(ChessMatch match)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(" Peças capturadas ");
            Console.ResetColor();
            Console.Write(" Brancas: ");
            PrintSet(match.GetCapturedPieces(Color.White));

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" Pretas: ");
            PrintSet(match.GetCapturedPieces(Color.Black));
            Console.ResetColor();
        }

        public static void PrintSet(HashSet<Piece> pieces)
        {
            Console.Write("[");
            foreach (Piece piece in pieces)
            {
                Console.Write(" " + piece + ", ");
            }
            Console.Write("]");
        }
    }
}
