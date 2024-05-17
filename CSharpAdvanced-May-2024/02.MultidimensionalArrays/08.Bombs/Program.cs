
using System.Text;

namespace _08.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] board = new int[n, n];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = input[col];
                }
            }

            //1,2 2,1 2,0
            int[] bombs = Console.ReadLine()
                .Split(' ', ',')
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < bombs.Length - 1; i+=2)
            {
                int targetRow = bombs[i];
                int targetCol = bombs[i + 1];
                int value = board[targetRow, targetCol];

                if (board[targetRow, targetCol] <= 0)
                {
                    continue;
                }

                for (int row  = targetRow - 1; row <= targetRow + 1; row++)
                {
                    for (int col = targetCol - 1; col <= targetCol + 1; col++)
                    {
                        if (IsInside(board, row, col)
                            && board[row, col] > 0)
                        {
                            board[row, col] -= value;
                        }
                    }
                }
            }

            int aliveCells = 0;
            int cellsSum = 0;
            StringBuilder stringBuilder = new StringBuilder();

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for(int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] > 0)
                    {
                        aliveCells++;
                        cellsSum += board[row, col];
                    }
                    stringBuilder.Append(board[row, col] + " ");
                }
                stringBuilder.AppendLine();
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {cellsSum}");
            Console.WriteLine(stringBuilder);
        }

        private static bool IsInside(int[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0)
                && col >= 0 && col < board.GetLength(1);
        }
    }
}
