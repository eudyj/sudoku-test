namespace Sudoku
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            SudokuGrid grid;
            System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();

            s.Start();

            grid = SudokuGrid.Random();

            s.Stop();

            Console.WriteLine(grid.ToString());

            Console.WriteLine(s.ElapsedMilliseconds);

            Console.ReadLine();
        }

    }
}
