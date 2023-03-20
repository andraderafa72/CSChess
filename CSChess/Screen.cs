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
                Console.Write((i + 1) + "|");
                for (int j = 0; j < 8; j++)
                {
                    Piece piece = board.GetPieceByPosition(i, j);

                    if (piece != null)
                    {
                        if (piece.Color == Color.White)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        Console.Write($" {piece} ");
                        Console.ResetColor();
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
    }
}
