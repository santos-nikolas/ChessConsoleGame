using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsoleGame
{
    public class Pawn : Piece // extends Piece
    {
        // Construtor chama o construtor da classe base Piece
        public Pawn(Color color, Board board) : base(color, board)
        {
        }

        // Implementação específica de movimentos para o Peão
        public override List<Position> GetPossibleMoves()
        {
            List<Position> moves = new List<Position>();
            int direction = (Color == Color.White) ? -1 : 1; // Branco: linha diminui (-1), Preto: linha aumenta (+1)
            int currentRow = Position.Row;
            int currentCol = Position.Column;

            // 1. Movimento Simples para Frente
            Position oneStepForward = new Position(currentRow + direction, currentCol);
            if (Board.IsValidPosition(oneStepForward) && Board.GetPiece(oneStepForward) == null)
            {
                moves.Add(oneStepForward);

                // 2. Primeiro Movimento Duplo (adicionaremos depois, se este movimento simples for possível)
                bool isFirstMove = (Color == Color.White && currentRow == 6) || (Color == Color.Black && currentRow == 1);
                if (isFirstMove)
                {
                    Position twoStepForward = new Position(currentRow + (direction * 2), currentCol);
                    if (Board.IsValidPosition(twoStepForward) && Board.GetPiece(twoStepForward) == null)
                    {
                        moves.Add(twoStepForward);
                    }
                }
            }

            // 3. Captura Diagonal Esquerda
            Position diagLeft = new Position(currentRow + direction, currentCol - 1);
            if (Board.IsValidPosition(diagLeft))
            {
                Piece targetPiece = Board.GetPiece(diagLeft);
                if (targetPiece != null && targetPiece.Color != this.Color)
                {
                    moves.Add(diagLeft);
                }
            }

            // 4. Captura Diagonal Direita
            Position diagRight = new Position(currentRow + direction, currentCol + 1);
            if (Board.IsValidPosition(diagRight))
            {
                Piece targetPiece = Board.GetPiece(diagRight);
                if (targetPiece != null && targetPiece.Color != this.Color)
                {
                    moves.Add(diagRight);
                }
            }

            // Lógica para En Passant e Promoção viria aqui depois.

            return moves;
        }

        // Opcional, mas recomendado: Sobrescrever a representação textual
        // public override char GetCharRepresentation()
        // {
        //     return 'P';
        // }

        // O ToString() padrão ainda retornaria "ChessConsoleGame.Pawn"
        // Poderíamos sobrescrevê-lo também se quiséssemos algo mais descritivo
        public override string ToString()
        {
            return $"Pawn({Color}) at {Position}";
        }
    }
}
