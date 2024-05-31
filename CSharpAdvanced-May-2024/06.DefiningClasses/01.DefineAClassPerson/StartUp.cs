namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Name = "StoSho",
                Age = 30
            };

            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}
