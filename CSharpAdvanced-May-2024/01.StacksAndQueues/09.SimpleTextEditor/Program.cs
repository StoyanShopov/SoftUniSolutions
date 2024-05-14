namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> state = new Stack<string>();

            int n = int.Parse(Console.ReadLine());

            string text = string.Empty; //Replace with StringBuilder

            for (int i = 0; i < n; i++)
            {
                string[] commandInfo = Console.ReadLine().Split();

                if (commandInfo[0] == "1") //1 abc
                {
                    state.Push(text);
                    text += commandInfo[1];
                }
                else if (commandInfo[0] == "2") //2 3
                {
                    state.Push(text);
                    int valueToErase = int.Parse(commandInfo[1]);
                    text = text.Substring(0, text.Length - valueToErase);
                }
                else if (commandInfo[0] == "3")
                {
                    int indexToPrint = int.Parse(commandInfo[1]);
                    Console.WriteLine(text[indexToPrint - 1]);
                }
                else if (commandInfo[0] == "4")
                {
                    text = state.Pop();
                }
            }
        }
    }
}
