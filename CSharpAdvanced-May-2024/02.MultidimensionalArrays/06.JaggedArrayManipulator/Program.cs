namespace _06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[i] = input;
            }

            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }

                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                //Add 0 10 10
                //Subtract 3 0 10
                string[] commandInfo = command.Split();

                int targetRow = int.Parse(commandInfo[1]);
                int targetCol = int.Parse(commandInfo[2]);
                int value = int.Parse(commandInfo[3]);

                if (IsInside(jaggedArray, targetRow, targetCol))
                {
                    if (commandInfo[0] == "Add")
                    {
                        jaggedArray[targetRow][targetCol] += value;
                    }
                    else if (commandInfo[0] == "Subtract")
                    {
                        jaggedArray[targetRow][targetCol] -= value;
                    }
                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[row]));
            }
        }

        public static bool IsInside(int[][] array, int row, int col)
        {
            return row >= 0 && row < array.Length
                && col >= 0 && col < array[row].Length;
        }
    }
}
