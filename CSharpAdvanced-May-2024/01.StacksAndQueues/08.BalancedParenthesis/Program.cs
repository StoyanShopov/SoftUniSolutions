namespace _08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //{[()]}
            //{[(])}
            Stack<char> stack = new Stack<char>();

            string input = Console.ReadLine();

            bool isBalanced = true;

            foreach (var item in input)
            {
                if (item is '(' or '[' or '{')
                {
                    stack.Push(item);
                    continue;
                }

                bool canPop = stack.TryPeek(out char currentChat);

                if (canPop && ((currentChat == '(' && item == ')')
                        || (currentChat == '[' && item == ']')
                        || (currentChat == '{' && item == '}')))
                {
                    stack.Pop();
                }
                else
                {
                    isBalanced = false;
                    break;
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
