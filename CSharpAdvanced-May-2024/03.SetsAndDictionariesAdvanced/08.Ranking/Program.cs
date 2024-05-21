namespace _08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //"{contest}:{password for contest}" 
            //"end of contests". 
            Dictionary<string, string> contestPasswords
                = new Dictionary<string, string>();

            Dictionary<string, Dictionary<string, int>> userContests =
                new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] inputInfo = input.Split(':');

                string contest = inputInfo[0];
                string password = inputInfo[1];

                contestPasswords.Add(contest, password);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of submissions")
            {
                //"{contest}=>{password}=>{username}=>{points}
                string[] inputInfo = input.Split("=>");

                string contest = inputInfo[0];
                string password = inputInfo[1];
                string username = inputInfo[2];
                int points = int.Parse(inputInfo[3]);

                if (!(contestPasswords.ContainsKey(contest)
                    && contestPasswords[contest] == password))
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (!userContests.ContainsKey(username))
                {
                    userContests.Add(username, new Dictionary<string, int>());
                }

                if (!userContests[username].ContainsKey(contest))
                {
                    userContests[username].Add(contest, 0);
                }

                if (points > userContests[username][contest])
                {
                    userContests[username][contest] = points;
                }

                input = Console.ReadLine();
            }

            var topCandidate = userContests
                .OrderByDescending(x => x.Value.Sum(y => y.Value))
                .FirstOrDefault();

            Console.WriteLine($"Best candidate is {topCandidate.Key} with total {topCandidate.Value.Values.Sum(x => x)} points.");

            //string topCanidate = string.Empty;
            //int maxPoints = int.MinValue;

            //foreach (var (user, contest) in userContests)
            //{
            //    int totalSum = contest.Values.Sum(x => x);

            //    if (totalSum > maxPoints)
            //    {
            //        maxPoints = totalSum;
            //        topCanidate = user;
            //    }
            //}

            Console.WriteLine("Ranking:");

            foreach (var (user, contests) in userContests.OrderBy(x => x.Key))
            {
                Console.WriteLine(user);

                foreach (var contest in contests.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
