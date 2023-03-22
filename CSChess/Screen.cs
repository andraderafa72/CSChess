using CSChess.Board;
using CSChess.Board.Enums;

namespace CSChess
{
    internal class Screen
    {
        public static void PrintBoard(ChessBoard board)
        {
            for (int i = 0; i < 8; i++)
            {
                Console.Write((8 - i) + "|");
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
            Console.WriteLine("   ______________________");
            Console.WriteLine("   a  b  c  d  e  f  g  h ");
        }

        public static void PrintBoard(ChessBoard board, bool[,] availableMoves)
        {
            for (int i = 0; i < 8; i++)
            {
                Console.Write((8 - i) + "|");
                for (int j = 0; j < 8; j++)
                {
                    Piece piece = board.GetPieceByPosition(i, j);
                    PrintPiece(piece, availableMoves[i, j]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("   ______________________");
            Console.WriteLine("   a  b  c  d  e  f  g  h ");
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.Black) Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($" {piece} ");
            Console.ResetColor();
        }

        public static void PrintPiece(Piece piece, bool canMove)
        {
            if (canMove) Console.BackgroundColor = ConsoleColor.DarkGray;
            if (piece != null)
            {
                if (piece.Color == Color.Black) Console.ForegroundColor = ConsoleColor.Red;
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
            Console.WriteLine(p);

            return p;
        }
    }
}
