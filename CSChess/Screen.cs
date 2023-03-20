using CSChess.Board;

namespace CSChess
{
    internal class Screen
    {
        public static void PrintBoard(ChessBoard board)
        {
            for (int i = 0; i < 8; i++)
            {
                Console.Write(i + 1);
                for (int j = 0; j < 8; j++)
                {
                    Piece piece = board.GetPieceByPosition(i, j);

                    if(piece != null) {
                    Console.Write($" {piece} ");
                    } else
                    {
                        Console.Write(" - ");
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine(" a  b  c  d  e  f  g  h ");
        }
    }
}
