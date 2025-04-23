// Dentro do Main em Program.cs
using ChessConsoleGame;

Console.WriteLine("Testing Position Class:"); // Mensagem em inglês

Position pos1 = new Position(0, 0); // Usa a classe Position
Position pos2 = new Position(4, 3);

Console.WriteLine($"Position 1: {pos1}"); // (0, 0)
Console.WriteLine($"Position 2: {pos2}"); // (4, 3)

Console.WriteLine($"Row of Position 2: {pos2.Row}"); // Usa a propriedade Row
Console.WriteLine($"Column of Position 2: {pos2.Column}"); // Usa a propriedade Column

Console.WriteLine("\nEnd of Position test.");