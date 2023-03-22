using CSChess.Board;
using CSChess.Board.Enums;
using CSChess.ChessPieces;
using CSChess.Exceptions;
using CSChess.Match;

namespace CSChess
{
    class Chess
    {
        static void Main(string[] args)
        {
            ChessMatch match = new();


            while (!match.IsFinished)
            {
                try
                {
                    Screen.PrintMatch(match);
                    Console.WriteLine("Posição de origem:");
                    Position origin = Screen.ReadChessPosition();
                    Piece SelectedPiece;
                    SelectedPiece = match.ValidateOriginPosition(origin);

                    Console.Clear();
                    Screen.PrintMatch(match, SelectedPiece.AvailableMoves());
                    Console.WriteLine($"Posição de origem: {origin}");
                    Console.WriteLine("Posição de destino:");
                    Position destiny = Screen.ReadChessPosition();
                    match.ValidateDestinyPosition(origin, destiny);

                    match.PerformMove(origin, destiny);

                    Console.Clear();
                }
                catch (BoardException e)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                    Console.WriteLine();
                    continue;
                }
                catch (Exception e)
                {
                    //Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                    Console.WriteLine();
                    continue;
                }
            }

            Console.Clear();
            Screen.PrintMatch(match);

        }
    }
}