namespace _02.MultidimensionalArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = dimension[0];
            int columns = dimension[1];

            char[,] board = new char[rows, columns];

            //A B B D
            for (int row = 0; row < board.GetLength(0); row++)
            {
                string[] input = Console.ReadLine() //"A B B D"
                    .Split(); //["A", "B", "B", "D"]

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col]= input[col][0]; //["A"][0] -> 'A' 
                }
            }

            int equalSquares = 0;

            for (int row = 0; row < board.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < board.GetLength(1) - 1; col++)
                {
                    bool areEqual =
                        board[row, col] == board[row + 1, col]
                     && board[row, col + 1] == board[row + 1, col + 1]
                     && board[row, col] == board[row + 1, col + 1];

                    if (areEqual)
                    {
                        equalSquares++;
                    }
                }
            }

            Console.WriteLine(equalSquares);
        }
    }
}
