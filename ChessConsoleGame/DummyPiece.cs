using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsoleGame
{
    public class DummyPiece : Piece
    {
        public DummyPiece(Color color, Board board) : base(color, board)
        {
            
        }
        public override List<Position> GetPossibleMoves()
        {
            // Retorna uma lista vazia, pois é uma peça dummy
            return new List<Position>();
        }
    }
}
