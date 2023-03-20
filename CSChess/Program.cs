using CSChess.Board;
using CSChess.Board.Enums;
using CSChess.ChessPieces;
using CSChess.Match;

namespace CSChess
{
    class Chess
    {
        static void Main(string[] args)
        {
            ChessMatch match = new();

            Screen.PrintBoard(match.MatchBoard);

            ChessPosition cpos = new('b', 3);
            Console.WriteLine(cpos.ToPosition());
            Console.WriteLine('d' - 'a');

            while (!match.IsFinished)
            {
                Console.WriteLine($"Vez do jogador {match.CurrentPlayer}");
                Console.WriteLine("Posição de origem:");
                Position origin = Screen.ReadChessPosition();
                Console.WriteLine("Posição de destino:");
                Position destiny = Screen.ReadChessPosition();

                match.MovePiece(origin, destiny);
                Screen.PrintBoard(match.MatchBoard);
            }
        }
    }
}