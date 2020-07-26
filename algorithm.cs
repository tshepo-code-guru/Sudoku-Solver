using System;
using System.Collections.Generic;

namespace Algorithms.Sudoku
{
    public class SudokuAlgorithm
    {
        protected int[,] Board { get; set; }

        public SudokuAlgorithm() { }
        public SudokuAlgorithm(int[,] board)
        {
            Board = board;
        }

        public int[,] Solve(int[,] board = null)
        {
            Console.WriteLine("Solving. . .");
            Console.WriteLine("This may take more than a minute depending on the complexity of the puzzle. . .\n");

            if (board != null)
                Board = board;

            Process();
            Print();

            Console.WriteLine("\nProcess Complete.");
            return Board;
        }

        protected bool IsSafe(int[,] board, int row, int col, int num)
        {
            for (int d = 0; d < board.GetLength(0); d++)
                if (board[row, d] == num)
                    return false;

            for (int r = 0; r < board.GetLength(0); r++)
                if (board[r, col] == num)
                    return false;

            int sqrt = (int)Math.Sqrt(board.GetLength(0));
            int boxRowStart = row - row % sqrt;
            int boxColStart = col - col % sqrt;

            for (int r = boxRowStart; r < boxRowStart + sqrt; r++)
                for (int d = boxColStart; d < boxColStart + sqrt; d++)
                    if (board[r, d] == num)
                        return false;

            return true;
        }

        protected bool Process()
        {
            int row = -1;
            int col = -1;
            bool isEmpty = true;
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(0); j++)
                {
                    if (Board[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        isEmpty = false;
                        break;
                    }
                }

                if (!isEmpty)
                    break;
            }

            if (isEmpty)
                return true;

            for (int num = 1; num <= Board.GetLength(0); num++)
            {
                if (IsSafe(Board, row, col, num))
                {
                    Board[row, col] = num;
                    if (Process())
                        return true;
                    else
                        Board[row, col] = 0;
                }
            }
            return false;
        }

        public void Print()
        {
            for (int r = 0; r < Board.GetLength(0); r++)
            {
                for (int d = 0; d < Board.GetLength(0); d++)
                {
                    Console.Write(Board[r, d]);
                    Console.Write(" ");
                }

                Console.Write("\n");

                if ((r + 1) % (int)Math.Sqrt(Board.GetLength(0)) == 0)
                    Console.Write("");
            }
        }
    }
}
