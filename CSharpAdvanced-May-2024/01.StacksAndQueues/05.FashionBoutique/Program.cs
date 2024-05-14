namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputSongs = Console.ReadLine()
                .Split(", ");

            Queue<string> songsQueue = new Queue<string>(inputSongs);

            while (true)
            {
                string[] commandInfo = Console.ReadLine().Split();

                if (commandInfo[0] == "Play")
                {
                    songsQueue.Dequeue();

                    if (songsQueue.Count == 0)
                    {
                        Console.WriteLine("No more songs!");
                        break;
                    }
                }
                else if (commandInfo[0] == "Add")
                {
                    string songName = string.Join(" ", commandInfo.Skip(1));

                    if (songsQueue.Contains(songName))
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                    else
                    {
                        songsQueue.Enqueue(songName);
                    }
                }
                else if (commandInfo[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
            }
        }
    }
}
