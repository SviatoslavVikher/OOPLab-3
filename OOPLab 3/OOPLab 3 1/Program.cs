using System;
using System.Linq;

class Program
{
    static void Main()
    {
        double[] array = new double[20];
        Random rnd = new Random();

        
        for (int i = 0; i < array.Length; i++)
            array[i] = Math.Round(rnd.NextDouble() * (60.3 - (-2.9)) + (-2.9), 1);

        
        int minIndex = Array.IndexOf(array, array.Min());
        int maxIndex = Array.IndexOf(array, array.Max());

        
        int start = Math.Min(minIndex, maxIndex);
        int end = Math.Max(minIndex, maxIndex);

        
        long productOfIndices = 1;
        if (start + 1 < end)
        {
            for (int i = start + 1; i < end; i++)
                productOfIndices *= i;
        }
        else
        {
            productOfIndices = 0; 
        }

        
        var sortedElements = array.Skip(start + 1).Take(end - start - 1).OrderByDescending(x => x).ToArray();

        
        Console.WriteLine("Масив: " + string.Join(", ", array));
        Console.WriteLine($"Мінімальний: {array[minIndex]} (індекс {minIndex})");
        Console.WriteLine($"Максимальний: {array[maxIndex]} (індекс {maxIndex})");
        Console.WriteLine("Добуток індексів: " + productOfIndices);
        Console.WriteLine("Відсортовані елементи між мін і макс: " + string.Join(", ", sortedElements));
    }
}
