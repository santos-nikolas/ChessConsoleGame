// Garanta que você tem o using para acessar as classes do seu jogo
using ChessConsoleGame;

// Código dentro do método Main
Console.WriteLine("Starting Chess Console Game!");

// 1. Criar uma instância do Tabuleiro
Board chessBoard = new Board(); // Isso chama o construtor do Board, que inicializa a matriz 8x8

// 2. Chamar o método PrintBoard() NO OBJETO tabuleiro que você criou
Console.WriteLine("Initial empty board:");
chessBoard.PrintBoard(); // Chama o método que está DENTRO da classe Board

// --- Opcional: Colocar uma peça manualmente para teste (antes de termos as classes reais) ---
// Isso vai dar erro AGORA porque não temos classes como Pawn ainda.
// Descomente e adapte quando tivermos as classes das peças na Fase 2.
/*
Console.WriteLine("\nPlacing a test piece (requires Piece subclasses)...");
// Exemplo (vai precisar da classe Pawn e que ela herde de Piece):
// Pawn testPawn = new Pawn(Color.White, chessBoard);
// Position testPosition = new Position(6, 4); // Ex: E2 (lembrando que a matriz é 0-7)
// chessBoard.PlacePiece(testPawn, testPosition);
// chessBoard.PrintBoard(); // Imprime o tabuleiro com a peça de teste
*/
// -----------------------------------------------------------------------------------------

Console.WriteLine("\nEnd of Program.");