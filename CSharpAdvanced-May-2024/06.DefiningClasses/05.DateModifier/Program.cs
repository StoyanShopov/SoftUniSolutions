namespace _05.DateModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1992 05 31
            //1992 05 31
            string firstDateAsString = Console.ReadLine();
            string secondDateAsString = Console.ReadLine();

            DateTime firstDate = DateTime.Parse(firstDateAsString);
            DateTime secondDate = DateTime.Parse(secondDateAsString);

            int daysDiff = DateModifier.CalculateDateDiffInDays(firstDate, secondDate);

            Console.WriteLine(daysDiff);
        }
    }
}
