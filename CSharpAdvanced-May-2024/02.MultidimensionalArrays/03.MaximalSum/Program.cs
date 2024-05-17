namespace _03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimension[0];
            int cols = dimension[1];

            int[,] board = new int[rows, cols];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries) //Beware!!!
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = input[col];
                }
            }

            int maxSum = int.MinValue;
            int targetRow = 0;
            int targetCol = 0;

            for (int row = 0; row < board.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < board.GetLength(1) - 2; col++)
                {
                    int currentSum = 0;

                    for (int i = row; i < row + 3; i++)
                    {
                        for (int j = col; j < col + 3; j++)
                        {
                            currentSum += board[i, j];
                        }
                    }

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        targetRow = row;
                        targetCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = targetRow; row < targetRow + 3; row++)
            {
                for (int col = targetCol; col < targetCol + 3; col++)
                {
                    Console.Write(board[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
