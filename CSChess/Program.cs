using CSChess.Board;
using CSChess.Board.Enums;
using CSChess.ChessPieces;

namespace CSChess
{
    class Chess
    {
        static void Main(string[] args)
        {

            ChessBoard board = new();
            board.InsertPiece(new King(Color.Black, board), new Position(0, 3));
            board.InsertPiece(new Queen(Color.Black, board), new Position(0, 4));
            board.InsertPiece(new Rook(Color.Black, board), new Position(0, 0));
            board.InsertPiece(new Rook(Color.Black, board), new Position(0, 7));
            board.InsertPiece(new Knight(Color.Black, board), new Position(0, 1));
            board.InsertPiece(new Knight(Color.Black, board), new Position(0, 6));
            board.InsertPiece(new Bishop(Color.Black, board), new Position(0, 2));
            board.InsertPiece(new Bishop(Color.Black, board), new Position(0, 5));


            for (int i = 0; i < 8; i++)
            {
                board.InsertPiece(new Pawn(Color.Black, board), new Position(1, i));
            }

            board.InsertPiece(new King(Color.White, board), new Position(7, 3));
            board.InsertPiece(new Queen(Color.White, board), new Position(7, 4));
            board.InsertPiece(new Rook(Color.White, board), new Position(7, 0));
            board.InsertPiece(new Rook(Color.White, board), new Position(7, 7));
            board.InsertPiece(new Knight(Color.White, board), new Position(7, 1));
            board.InsertPiece(new Knight(Color.White, board), new Position(7, 6));
            board.InsertPiece(new Bishop(Color.White, board), new Position(7, 2));
            board.InsertPiece(new Bishop(Color.White, board), new Position(7, 5));


            for (int i = 0; i < 8; i++)
            {
                board.InsertPiece(new Pawn(Color.White, board), new Position(6, i));
            }

            Screen.PrintBoard(board);
        }
    }
}