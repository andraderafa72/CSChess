using CSChess.Board;

namespace CSChess
{
    class Chess
    {
        static void Main(string[] args)
        {
            
            ChessBoard board = new();

            Screen.PrintBoard(board);
        }
    }
}