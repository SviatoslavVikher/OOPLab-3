using System;
using System.Linq;
using System.Windows;

namespace ArrayApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnProcessArray(object sender, RoutedEventArgs e)
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

            
            string result = $"Масив: {string.Join(", ", array)}\n" +
                            $"Мінімальний: {array[minIndex]} (індекс {minIndex})\n" +
                            $"Максимальний: {array[maxIndex]} (індекс {maxIndex})\n" +
                            $"Добуток індексів: {productOfIndices}\n" +
                            $"Відсортовані елементи між мін і макс: {string.Join(", ", sortedElements)}";

            
            OutputTextBox.Text = result;
        }
    }
}
