using System.Dynamic;
using System.Reflection.Emit;
using System.Xml.Resolvers;

namespace _09.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> bannedUsers = new HashSet<string>();
            Dictionary<string, int> topResults = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            //Peter-Java-91
            //Sam-banned
            //exam finished
            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] inputInfo = input.Split('-');

                string username = inputInfo[0];

                if (inputInfo[1] == "banned")
                {
                    bannedUsers.Add(username);
                }
                
                if (!bannedUsers.Contains(username))
                {
                    string exam = inputInfo[1];
                    int points = int.Parse(inputInfo[2]);

                    if (!submissions.ContainsKey(exam))
                    {
                        submissions.Add(exam, 0);
                    }
                    submissions[exam]++;

                    if (!topResults.ContainsKey(username))
                    {
                        topResults.Add(username, points);
                    }

                    if (points > topResults[username])
                    {
                        topResults[username] = points;
                    }
                }

                input = Console.ReadLine();
            }
            //Sam | 94 
            Console.WriteLine("Results:");

            foreach (var item in topResults
                .Where(x => !bannedUsers.Contains(x.Key))
                .OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var item in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

        }
    }
}
