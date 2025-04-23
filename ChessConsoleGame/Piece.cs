using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsoleGame
{
    public abstract class Piece
    {
        public Color Color { get; init; }
        public Position Position { get; set; }
        protected Board Board { get; init; }

        protected Piece(Color color, Board board) {
            Color = color;
            Board = board;
            Position = null;
        }

        public abstract List<Position> GetPossibleMoves();

    }
}
