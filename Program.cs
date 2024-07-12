using System;
using System.Linq;

namespace SchellingModel
{
    class Program
    {
        static int[,] grid = new int[40, 40];
        static Random random = new Random();

        static void Main(string[] args)
        {
            InitializeGrid();

            bool stable = false;
            int counter = 0;
            while (!stable)
            {
                stable = true;
                Console.WriteLine($"Iteration #:{counter++}");
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        if (grid[i, j] != 0 && !IsHappy(i, j))
                        {
                            int newI, newJ;
                            do
                            {
                                newI = random.Next(grid.GetLength(0));
                                newJ = random.Next(grid.GetLength(1));
                            } while (grid[newI, newJ] != 0);

                            grid[newI, newJ] = grid[i, j];
                            grid[i, j] = 0;
                            stable = false;
                        }
                    }
                }
                PrintGrid();
            }

            
        }

        static void InitializeGrid()
        {

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = random.Next(3);
                }
            }
        }

        static bool IsHappy(int i, int j)
        {
            int same = 0;
            int different = 0;

            for (int di = -1; di <= 1; di++)
            {
                for (int dj = -1; dj <= 1; dj++)
                {
                    if (di == 0 && dj == 0) continue;

                    int ni = i + di;
                    int nj = j + dj;

                    if (ni >= 0 && nj >= 0 && ni < grid.GetLength(0) && nj < grid.GetLength(1))
                    {
                        if (grid[ni, nj] == grid[i, j]) same++;
                        else if (grid[ni, nj] != 0) different++;
                    }
                }
            }

            return same >= 4;
        }

        static void PrintGrid()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    switch (grid[i, j])
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                    }
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }

            // Reset console color
            Console.ResetColor();
        }

    }
}
