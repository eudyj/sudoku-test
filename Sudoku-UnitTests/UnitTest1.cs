using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace Sudoku_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetBoxNumber_Test()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    int box = Program.GetBoxNumber(col, row);
                    if (col <= 2 && row <= 2) Assert.AreEqual(0, box);
                    else if (col >= 3 && col <= 5 && row <= 2) Assert.AreEqual(1, box);
                    else if (col >= 6 && row <= 2) Assert.AreEqual(2, box);
                    else if (col <= 2 && row >= 3 && row <= 5) Assert.AreEqual(3, box);
                    else if (col >= 3 && col <= 5 && row >= 3 && row <= 5) Assert.AreEqual(4, box);
                    else if (col >= 6 && row >= 3 && row <= 5) Assert.AreEqual(5, box);
                    else if (col <= 2 && row >= 6) Assert.AreEqual(6, box);
                    else if (col >= 3 && col <= 5 && row >= 6) Assert.AreEqual(7, box);
                    else Assert.AreEqual(8, box);
                }
            }
        }
    }
}
