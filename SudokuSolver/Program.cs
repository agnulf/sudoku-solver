// C# port of the python sudoku solver by Computerphile
// https://www.youtube.com/watch?v=G_UYXzGuqvM

using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = { { 3, 0, 0, 6, 0, 0, 0, 0, 4 },
                            { 4, 0, 9, 8, 0, 1, 0, 0, 7 },
                            { 0, 0, 7, 0, 4, 9, 6, 0, 0 },
                            { 9, 4, 6, 1, 5, 7, 8, 0, 2 },
                            { 0, 2, 0, 3, 0, 0, 7, 4, 5 },
                            { 0, 7, 0, 2, 8, 0, 0, 0, 0 },
                            { 0, 0, 0, 4, 0, 0, 0, 0, 0 },
                            { 8, 0, 5, 0, 6, 0, 0, 2, 0 },
                            { 7, 3, 4, 0, 0, 8, 5, 0, 0 } };

            Console.WriteLine("UNSOLVED");
            PrintGrid(grid);

            Console.WriteLine();

            Console.WriteLine("SOLVED");
            Solve(grid);
        }
        private static bool Possible(int[,] grid, int row, int col, int number)
        {
            for (int rowPosition = 0; rowPosition < 9; rowPosition++)
            {
                if (grid[row, rowPosition] == number)
                {
                    return false;
                }
            }

            for (int colPosition = 0; colPosition < 9; colPosition++)
            {
                if (grid[colPosition, col] == number)
                {
                    return false;
                }
            }

            int squareRowOrigin = (row / 3) * 3;
            int squareColOrigin = (col / 3) * 3;

            for (int rowPosition = 0; rowPosition < 3; rowPosition++)
            {
                for (int colPosition = 0; colPosition < 3; colPosition++)
                {
                    if (grid[squareRowOrigin + rowPosition, squareColOrigin + colPosition] == number)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        private static void Solve(int[,] grid)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (grid[row, col] == 0)
                    {
                        for (int number = 1; number < 10; number++)
                        {
                            if (Possible(grid, row, col, number))
                            {
                                grid[row, col] = number;
                                Solve(grid);
                                grid[row, col] = 0;
                            }
                        }
                        return;
                    }
                }
            }
            PrintGrid(grid);
            Console.Write("\nPress any key to exit ");
            Console.ReadKey();
        }
        private static void PrintGrid(int[,] grid)
        {
            for (int row = 0; row < 9; row++)
            {   
                Console.Write("[");
                for (int col = 0; col < 9; col++)
                {
                    if (col == 8)
                    {
                        Console.Write($"{grid[row, col]}]\n");
                    }
                    else
                    {
                        Console.Write($"{grid[row, col]} ");
                    }                               
                }
            }
        }
    }
}
