using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsoleGame
{
    public class Board
    {
        public int numRows;
        public int numCols;
        private Piece[,] pieces;
        public Board()
        {
            numRows = 8;
            numCols = 8;
            pieces = new Piece[numRows, numCols];
        }
        public Piece getPiece(Position position)
        {
            return pieces[position.Row, position.Column];
        }
        public void PlacePiece(Piece piece, Position position)
        {

        }
    }
}
