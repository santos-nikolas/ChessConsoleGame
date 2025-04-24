using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsoleGame
{
    public class Board
    {
        // Propriedades para o tamanho do tabuleiro
        public int Rows { get; init; } // Só pode ser definido aqui dentro (no construtor)
        public int Columns { get; init; } // Só pode ser definido aqui dentro

        // Matriz privada para guardar as peças. Só o Board mexe diretamente nela.
        private Piece[,] pieces;

        // Construtor: Inicializa o tabuleiro
        public Board()
        {
            Rows = 8;
            Columns = 8;
            pieces = new Piece[Rows, Columns]; // Cria a matriz 8x8, inicialmente vazia (null)
        }

        // Método para obter a peça em uma dada posição
        public Piece GetPiece(Position position)
        {
            // Opcional: Validar posição antes de acessar
            if (!IsValidPosition(position))
            {
                return null; // Ou lançar exceção: throw new ArgumentOutOfRangeException(nameof(position), "Posição inválida.");
            }
            return pieces[position.Row, position.Column];
        }

        // Método para obter a peça usando índices diretamente (pode ser útil)
        public Piece GetPiece(int row, int column)
        {
            return GetPiece(new Position(row, column)); // Reutiliza o método acima
                                                        // Ou acessa diretamente após validação:
                                                        // if (!IsValidPosition(row, column)) { return null; }
                                                        // return pieces[row, column];
        }


        // Método para colocar uma peça no tabuleiro
        public void PlacePiece(Piece piece, Position position)
        {
            // Opcional: Validar posição
            if (!IsValidPosition(position))
            {
                // Lançar exceção ou tratar o erro
                Console.WriteLine($"Erro: Posição {position} inválida para colocar peça.");
                return;
            }
            // Opcional: verificar se já existe peça? Por enquanto sobrescreve.
            pieces[position.Row, position.Column] = piece;
            if (piece != null) // Se estamos colocando uma peça (e não limpando a casa)
            {
                piece.Position = position; // Atualiza a posição na própria peça
            }
        }

        // Método auxiliar privado para verificar se a posição está dentro dos limites
        public bool IsValidPosition(Position position)
        {
            if (position == null) return false;
            return position.Row >= 0 && position.Row < Rows &&
                   position.Column >= 0 && position.Column < Columns;
        }

        // Sobrecarga do método auxiliar para índices (opcional)
        private bool IsValidPosition(int row, int column)
        {
            return row >= 0 && row < Rows &&
                   column >= 0 && column < Columns;
        }

        // Método para imprimir o tabuleiro no console
        public void PrintBoard() // Método agora pertence ao Board
        {
            Console.WriteLine(); // Linha em branco para espaçamento
            Console.WriteLine("   A B C D E F G H"); // Cabeçalho das colunas
            Console.WriteLine("  -----------------"); // Separador

            // Itera pelas linhas na ordem inversa para imprimir 8, 7, ..., 1
            for (int i = 0; i < Rows; i++) // Linha da matriz (0 a 7)
            {
                int rowLabel = 8 - i; // Rótulo da linha (8 a 1)
                Console.Write($"{rowLabel} |"); // Imprime rótulo e separador |

                for (int j = 0; j < Columns; j++) // Coluna da matriz (0 a 7)
                {
                    Piece piece = pieces[i, j]; // Acesso direto à matriz interna

                    if (piece == null)
                    {
                        Console.Write(". "); // Casa vazia
                    }
                    else
                    {
                        // --- PONTO PARA MELHORIA FUTURA ---
                        // Precisamos de uma forma padronizada de obter a representação da peça.
                        // Por enquanto, vamos usar a primeira letra do tipo e a cor.
                        char pieceChar = GetPieceCharRepresentation(piece);
                        Console.Write($"{pieceChar} ");
                        // -----------------------------------
                    }
                }
                Console.WriteLine($"| {rowLabel}"); // Imprime separador | e rótulo no final da linha
            }
            Console.WriteLine("  -----------------");
            Console.WriteLine("   A B C D E F G H");
            Console.WriteLine(); // Linha em branco
        }

        // Método auxiliar PRIVADO para obter a representação da peça (simplificado por enquanto)
        private char GetPieceCharRepresentation(Piece piece)
        {
            if (piece == null) return '.'; // Segurança extra
            char baseChar = piece.GetType().Name[0]; // Pega a primeira letra (Pawn, Rook, Knight...)
            //if (piece is Knight) baseChar = 'N'; // Possível verificação para knight

            // Diferencia por cor (Ex: Branca = Maiúscula, Preta = Minúscula)
            return piece.Color == Color.White ? char.ToUpper(baseChar) : char.ToLower(baseChar);

            // --- PROBLEMA: Knight começa com K! ---
            // Precisaremos de uma lógica melhor quando tivermos as classes das peças.
            // Ex: if (piece is Knight) return piece.Color == Color.White ? 'N' : 'n';
            //     else if (piece is Pawn) return piece.Color == Color.White ? 'P' : 'p'; ... etc.
        }
        public void SetupInitialPieces()
        {
            // Exemplo de configuração inicial (apenas para teste)
            //PlacePiece(new DummyPiece(Color.White, this), new Position(6, 4));
            //PlacePiece(new DummyPiece(Color.Black, this), new Position(1, 3));
            for (int i = 0; i < Columns; i++) { 
                PlacePiece(new Pawn(Color.White, this), new Position(6, i));
                PlacePiece(new Pawn(Color.Black, this), new Position(1, i));
            }

        }
    }
}
