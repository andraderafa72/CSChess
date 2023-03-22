using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSChess.Board
{
    internal class ChessPosition
    {
        public char column { get; set; }
        public int line { get; set; }

        public ChessPosition(char column, int line)
        {
            this.column = column;
            this.line = line;
        }

        public Position ToPosition()
        {
            int posLine, posColumn;
            posLine = 8 - line;
            posColumn = column - 'a';

            return new Position(posLine, posColumn);
        }

        public override string ToString()
        {
            return "" + column + line;
        }
    }
}
