namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person("StoSho", 28);

            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}
