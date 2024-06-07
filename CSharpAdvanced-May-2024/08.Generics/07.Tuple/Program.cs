using System;

namespace _07.Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string[] alcholicPerson = Console.ReadLine().Split();
            string[] values = Console.ReadLine().Split();

            string personName = personInfo[0] + " " + personInfo[1];
            string personTown = personInfo[2];

            string alcoholicName = alcholicPerson[0];
            int alcoholicLiters = int.Parse(alcholicPerson[1]);

            int integerValue = int.Parse(values[0]);
            double doubleValue = double.Parse(values[1]);

            MyTuple<string, string> personInfoTuple
                = new MyTuple<string, string>(personName, personTown);

            MyTuple<string, int> alcoholicPersonTuple
                = new MyTuple<string, int>(alcoholicName, alcoholicLiters);

            MyTuple<int, double> valuesTuple
                = new MyTuple<int, double>(integerValue, doubleValue);

            Console.WriteLine($"{personInfoTuple.Item1} -> {personInfoTuple.Item2}");
            Console.WriteLine($"{alcoholicPersonTuple.Item1} -> {alcoholicPersonTuple.Item2}");
            Console.WriteLine($"{valuesTuple.Item1} -> {valuesTuple.Item2}");
        }
    }
}
