namespace _05.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            string snake = Console.ReadLine();

            char[,] board = new char[rows, cols];

            int counter = 0;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (row % 2 == 0)
                    {
                        board[row, col] = snake[counter++];

                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                    }
                    else
                    {
                        board[row, board.GetLength(1) - 1 - col] = snake[counter++];

                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                    }
                }
            }

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
