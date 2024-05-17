using System.Data;

namespace _07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[,] board = new char[rows, rows];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = input[col];
                }
            }

            int removedKnights = 0;

            while (true)
            {
                int maxAttacks = 0;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        int currentAttacks = 0;

                        if (board[row, col] != 'K')
                        {
                            continue;
                        }

                        int[] positions =
                        {
                            -2, -1,
                            -2, 1,
                            2, -1,
                            2, 1,
                            -1, 2,
                            1, 2,
                            -1, -2,
                            1, -2
                        };

                        for (int i = 0; i < positions.Length; i += 2)
                        {
                            int nextRow = row + positions[i];
                            int nextCol = col + positions[i + 1];

                            if (IsInside(board, nextRow, nextCol)
                                && board[nextRow, nextCol] == 'K')
                            {
                                currentAttacks++;
                            }
                        }

                        if (currentAttacks > maxAttacks)
                        {
                            maxAttacks = currentAttacks;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    board[knightRow, knightCol] = '0';
                    removedKnights++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(removedKnights);
        }

        public static bool IsInside(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0)
                && col >= 0 && col < board.GetLength(1);
        }
    }
}
