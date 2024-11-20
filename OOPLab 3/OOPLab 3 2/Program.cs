using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        int rows = 5, cols = 6;
        double[,] matrix = new double[rows, cols];

        
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                matrix[i, j] = Math.Round(rnd.NextDouble() * 69.0 - 15.62, 2);

        Console.WriteLine("Початкова матриця:");
        PrintMatrix(matrix);

        
        int noPositiveRows = 0;
        for (int i = 0; i < rows; i++)
        {
            if (Enumerable.Range(0, cols).All(j => matrix[i, j] <= 0))
                noPositiveRows++;
        }
        Console.WriteLine($"\nКількість рядків без додатних елементів: {noPositiveRows}");

        
        var columnOrder = Enumerable.Range(0, cols)
            .OrderByDescending(j => Enumerable.Range(0, rows)
                .Where(i => matrix[i, j] > 0)
                .Sum(i => Math.Abs(matrix[i, j])))
            .ToArray();

        double[,] newMatrix = new double[rows, cols];
        for (int j = 0; j < cols; j++)
            for (int i = 0; i < rows; i++)
                newMatrix[i, j] = matrix[i, columnOrder[j]];

        Console.WriteLine("\nМатриця після перестановки стовпців:");
        PrintMatrix(newMatrix);
    }

    static void PrintMatrix(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write($"{matrix[i, j],8:F2}");
            Console.WriteLine();
        }
    }
}
