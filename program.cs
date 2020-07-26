using Algorithms.Sudoku;

namespace SudokuAlgorithmTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board = new int[,]
            {
                {7, 0, 5, 2, 0, 6, 0, 0, 0},
                {0, 8, 9, 5, 0, 7, 2, 0, 0},
                {0, 0, 0, 0, 4, 0, 0, 0, 0},
                {0, 5, 0, 0, 0, 0, 0, 0, 4},
                {0, 9, 0, 6, 0, 4, 0, 1, 0},
                {1, 0, 0, 0, 0, 0, 0, 5, 0},
                {0, 0, 0, 0, 8, 0, 0, 0, 0},
                {0, 0, 8, 9, 0, 1, 6, 7, 0},
                {0, 0, 0, 4, 0, 5, 1, 0, 2}
            };

            new SudokuAlgorithm(board).Solve();
            Console.ReadKey();
        }
    }
}
