namespace _04.MatrixShuffling
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

            string[,] board = new string[rows, cols];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = input[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                //["swap", "0"... 0 1 1]
                string[] commandInfo = command.Split();

                if (commandInfo.Length != 5
                    || commandInfo[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }

                int firstRow = int.Parse(commandInfo[1]); //TryParse
                int firstCol = int.Parse(commandInfo[2]);

                int secondRow = int.Parse(commandInfo[3]);
                int secondCol = int.Parse(commandInfo[4]);

                if (!IsInside(board, firstRow, firstCol)
                    || !IsInside(board, secondRow, secondCol))
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }

                string tempValue = board[firstRow, firstCol];
                board[firstRow, firstCol] = board[secondRow, secondCol];
                board[secondRow,secondCol] = tempValue;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        Console.Write(board[row,col] + " ");
                    }
                    Console.WriteLine();
                }

                command = Console.ReadLine();
            }
        }

        private static bool IsInside(string[,] board, int firstRow, int firstCol)
        {
            return firstRow >= 0 && firstRow < board.GetLength(0)
                                && firstCol >= 0 && firstCol < board.GetLength(1);
        }
    }
}
