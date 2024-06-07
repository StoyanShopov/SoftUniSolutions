namespace _01.CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i + 1);
            }

            Console.WriteLine($"Test 1: {list.Count == 10}");
            Console.WriteLine($"Test 2: {list[0] == 1}");
            Console.WriteLine($"Test 3: {list[5] == 6}");
            Console.WriteLine($"Test 4: {list[list.Count - 1] == 10}");

            list[0] = 30;
            list[3] = 20;
            list[list.Count - 1] = 5;

            Console.WriteLine($"Test 5: {list[0] == 30}");
            Console.WriteLine($"Test 6: {list[3] == 20}");
            Console.WriteLine($"Test 7: {list[list.Count - 1] == 5}");

            list.RemoveAt(0);

            Console.WriteLine($"Test 8: {list.Count == 9}");
            Console.WriteLine($"Test 9: {list[0] == 2}");

            list.RemoveAt(0);
            list.RemoveAt(list.Count - 1);

            Console.WriteLine($"Test 10: {list[0] == 3}");
            Console.WriteLine($"Test 11: {list[list.Count - 1] == 9}");

            Console.WriteLine($"Test 12: {list.Contains(5)}");
            Console.WriteLine($"Test 13: {list.Contains(10) == false}");
            Console.WriteLine($"Test 14: {list.Contains(1) == false}");


            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();

            list.Swap(0, 1);

            Console.WriteLine($"Test 15: {list[0] == 20}");
            Console.WriteLine($"Test 16: {list[1] == 3}");

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();

            //20 3 5 6 7 8 9
            //20 3 5 100 6 7 8 9

            list.Insert(3, 100);

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
