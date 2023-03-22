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


            Screen.PrintBoard(match.MatchBoard);
            while (!match.IsFinished)
            {
                try
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Turn: {match.Turn}");
                    Console.WriteLine($"Player: {match.CurrentPlayer}");
                    Console.WriteLine("Posição de origem:");
                    Position origin = Screen.ReadChessPosition();
                    Piece SelectedPiece;
                    SelectedPiece = match.ValidateOriginPosition(origin);

                    Screen.PrintBoard(match.MatchBoard, SelectedPiece.AvailableMoves());

                    Console.WriteLine("Posição de destino:");
                    Position destiny = Screen.ReadChessPosition();
                    match.ValidateDestinyPosition(origin, destiny);

                    match.MovePiece(origin, destiny);

                    Console.Clear();
                    Screen.PrintBoard(match.MatchBoard);
                }
                catch (BoardException e)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.MatchBoard);
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }
    }
}