namespace Sudoku
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = new int[9, 9];
            Dictionary<int, List<int>> columnValues = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> boxValues = new Dictionary<int, List<int>>();

            for (int i = 0; i < 9; i++)
            {
                columnValues[i] = new List<int>();
                boxValues[i] = new List<int>();
            }

            System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();

            s.Start();

            for (int i = 0; i < 9; i++)
            {
                var rowValues = AssignRow(columnValues, boxValues, i);
                for (int j = 0; j < 9; j++)
                {
                    grid[i, j] = rowValues[j];
                    columnValues[j].Add(rowValues[j]);
                    boxValues[GetBoxNumber(i, j)].Add(rowValues[j]);
                }
            }

            s.Stop();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write($"{grid[i, j]} ");
                }
                Console.WriteLine(Environment.NewLine);
            }

            Console.WriteLine(s.ElapsedMilliseconds);

            Console.ReadLine();
        }

        private static List<int> AssignRow(Dictionary<int, List<int>> columnValues, Dictionary<int, List<int>> boxValues, int column)
        {
            Random r = new Random();
            List<int> newValues = new List<int>();
            bool assigned = false;

            while (!assigned)
            {
                newValues.Clear();
                var rowNumbers = Enumerable.Range(1, 9).OrderBy(f => r.Next(100)).ToList();

                try
                {
                    for (int j = 0; j < 9; j++)
                    {
                        int k;
                        for (k = 0; columnValues[j].Contains(rowNumbers.Skip(k).Take(1).First()) || boxValues[GetBoxNumber(column, j)].Contains(rowNumbers.Skip(k).Take(1).First()); k++) { }
                        int newValue = rowNumbers.Skip(k).Take(1).First();
                        newValues.Add(newValue);
                        rowNumbers.Remove(newValue);
                    }

                    assigned = true;
                }
                catch (System.InvalidOperationException)
                {

                }
            }

            return newValues;
        }

        private static int GetBoxNumber(int column, int row)
        {
            if (column <= 2 && row <= 2) return 0;
            if (column >= 3 && column <= 5 && row <= 2) return 1;
            if (column >= 6 && row <= 2) return 2;
            if (column <= 2 && row >= 3 && row <= 5) return 3;
            if (column >= 3 && column <= 5 && row >= 3 && row <= 5) return 4;
            if (column >= 6 && row >= 3 && row <= 5) return 5;
            if (column <= 2 && row >= 6) return 6;
            if (column >= 3 && column <= 5 && row >= 6) return 7;
            return 8;
        }
    }
}
