namespace _01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] board = new int[n][];
            //int[,] board = new int[n, n];

            //for (int row = 0; row < board.GetLength(0); row++)
            for (int row = 0; row < board.Length; row++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                board[row] = input;

                //    for (int col = 0; col < board.GetLength(1); col++)
                //    {
                //        board[row, col] = input[col];
                //    }
            }

            int leftSum = 0;
            int rightSum = 0;

            //left-right NxX
            for (int row = 0; row < board[0].Length; row++)
            {
                leftSum += board[row][row];
                //leftSum += board[row, row];
            }

            //right-left
            //int colDiag = board.GetLength(1) - 1; //0
            int colDiag = board[0].Length - 1; //0
            for (int row = 0; row < board.GetLength(0); row++)
            {
                rightSum += board[row][colDiag--];
                //rightSum += board[row, colDiag--];
            }

            Console.WriteLine(Math.Abs(leftSum - rightSum));
        }
    }
}
