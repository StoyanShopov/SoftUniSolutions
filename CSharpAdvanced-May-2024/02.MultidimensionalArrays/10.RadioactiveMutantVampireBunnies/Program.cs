namespace _10.RadioactiveMutantVampireBunnies
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

            char[,] board = new char[rows, cols];

            int playerRow = 0;
            int playerCol = 0;

            List<int> bunnies = new List<int>();

            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray(); //.......B

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = input[col];

                    if (board[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    if (board[row, col] == 'B')
                    {
                        bunnies.Add(row);
                        bunnies.Add(col);
                    }
                }
            }

            string directions = Console.ReadLine();

            bool playerWon = false;
            bool playerDied = false;

            foreach (var direction in directions)
            {
                board[playerRow, playerCol] = '.';

                if (direction == 'L' && IsInside(board, playerRow, playerCol - 1))
                {
                    playerCol--;
                }
                else if (direction == 'R' && IsInside(board, playerRow, playerCol + 1))
                {
                    playerCol++;
                }
                else if (direction == 'U' && IsInside(board, playerRow - 1, playerCol))
                {
                    playerRow--;
                }
                else if (direction == 'D' && IsInside(board, playerRow + 1, playerCol))
                {
                    playerRow++;
                }
                else
                {
                    playerWon = true;
                }

                if (board[playerRow, playerCol] == 'B')
                {
                    playerDied = true;
                }
                else if (!playerWon)
                {
                    board[playerRow, playerCol] = 'P';
                }

                for (int i = 0; i < bunnies.Count - 1; i += 2)
                {
                    int bunnyRow = bunnies[i];
                    int bunnyCol = bunnies[i + 1];

                    int[] positions =
                    {
                        -1, 0,
                        1, 0,
                        0, 1,
                        0,-1
                    };

                    for (int p = 0; p < positions.Length - 1; p += 2)
                    {
                        int nextRow = bunnyRow + positions[p];
                        int nextCol = bunnyCol + positions[p + 1];

                        if (IsInside(board, nextRow, nextCol))
                        {
                            if (board[nextRow, nextCol] == 'P')
                            {
                                playerDied = true;
                            }

                            board[nextRow, nextCol] = 'B';
                        }
                    }
                }

                if (playerDied || playerWon)
                {
                    break;
                }

                //update positions
                bunnies = new List<int>();
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (board[row, col] == 'B')
                        {
                            bunnies.Add(row);
                            bunnies.Add(col);
                        }
                    }
                }
            }


            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col]);
                }
                Console.WriteLine();
            }

            Console.WriteLine($"{(playerWon ? "won" : "dead")}: {playerRow} {playerCol}");
        }

        private static bool IsInside(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0)
                && col >= 0 && col < board.GetLength(1);
        }
    }
}
