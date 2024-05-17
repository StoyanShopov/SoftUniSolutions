using System.Runtime.InteropServices;

namespace _09.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine().Split();

            char[,] board = new char[rows, rows];

            int totalCoals = 0;
            int minorRow = 0;
            int minorCol = 0;
            int coals = 0;
            bool isGameOver = false;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = input[col][0];

                    if (board[row, col] == 'c')
                    {
                        totalCoals++;
                    }

                    if (board[row, col] == 's')
                    {
                        minorRow = row;
                        minorCol = col;
                    }
                }
            }

            foreach (var direction in directions)
            {
                if (direction == "left"
                    && IsInside(board, minorRow, minorCol - 1))
                {
                    minorCol--;
                }
                else if (direction == "right"
                    && IsInside(board, minorRow, minorCol + 1))
                {
                    minorCol++;
                }
                else if (direction == "up"
                    && IsInside(board, minorRow - 1, minorCol))
                {
                    minorRow--;
                }
                else if (direction == "down"
                    && IsInside(board, minorRow + 1, minorCol))
                {
                    minorRow++;
                }
                else
                {
                    continue;
                }

                if (board[minorRow, minorCol] == 'e')
                {
                    isGameOver = true;
                    break;
                }
                else if (board[minorRow, minorCol] == 'c')
                {
                    board[minorRow, minorCol] = '*';
                    coals++;
                }

                if (totalCoals == coals)
                {
                    break;
                }
            }

            if (totalCoals == coals)
            {
                Console.WriteLine($"You collected all coals! ({minorRow}, {minorCol})");
            }
            else if (isGameOver)
            {
                Console.WriteLine($"Game over! ({minorRow}, {minorCol})");
            }
            else
            {
                Console.WriteLine($"{totalCoals - coals} coals left. ({minorRow}, {minorCol})");
            }
        }

        private static bool IsInside(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0)
                && col >= 0 && col < board.GetLength(1);
        }
    }
}
