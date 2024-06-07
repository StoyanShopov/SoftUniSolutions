using System;

namespace _08.Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string[] alcholicPerson = Console.ReadLine().Split();
            string[] bankInfo = Console.ReadLine().Split();

            string personName = personInfo[0] + " " + personInfo[1];
            string personAddress = personInfo[2];
            string personTown = string.Join(" ", personInfo.Skip(3));

            string alcoholicName = alcholicPerson[0];
            int alcoholicLiters = int.Parse(alcholicPerson[1]);
            bool drunk = alcholicPerson[2] == "drunk";

            string personBankInfoName = bankInfo[0];
            double personBankAccountBalance = double.Parse(bankInfo[1]);
            string personoBankName = bankInfo[2];

            MyTuple<string, string, string> personInfoTuple
                = new MyTuple<string, string, string>(personName, personAddress, personTown);

            MyTuple<string, int, bool> alcoholicPersonTuple
                = new MyTuple<string, int, bool>(alcoholicName, alcoholicLiters, drunk);

            MyTuple<string, double, string> personBankTuple
                = new MyTuple<string, double, string>(personBankInfoName, personBankAccountBalance, personoBankName);

            Console.WriteLine(personInfoTuple);
            Console.WriteLine(alcoholicPersonTuple);
            Console.WriteLine(personBankTuple);
        }
    }
}
