using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;

namespace _07.TheV_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, SortedSet<string>> vloggerFollowers
            //    = new Dictionary<string, SortedSet<string>>();
            //Dictionary<string, SortedSet<string>> vloggerFollowing
            //    = new Dictionary<string, SortedSet<string>>();

            Dictionary<string, Vlogger> vloggers = new Dictionary<string, Vlogger>();

            //EmilConrad joined The V-Logger
            //Saffrona followed EmilConrad
            //Statistics
            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] inputInfo = input.Split();

                if (inputInfo[1] == "joined")
                {
                    string username = inputInfo[0];

                    //vloggerFollowers.TryAdd(username, new SortedSet<string>());
                    //vloggerFollowing.TryAdd(username, new SortedSet<string>());

                    vloggers.TryAdd(username, new Vlogger());
                }
                else if (inputInfo[1] == "followed")
                {
                    string firstVlogger = inputInfo[0];
                    string secondVlogger = inputInfo[2];

                    if (vloggers.ContainsKey(firstVlogger) 
                        && vloggers.ContainsKey(secondVlogger)
                        && firstVlogger != secondVlogger)
                    {
                        vloggers[firstVlogger].Following.Add(secondVlogger);
                        vloggers[secondVlogger].Followers.Add(firstVlogger);
                    }

                    //if (vloggerFollowers.ContainsKey(firstVlogger) 
                    //    && vloggerFollowers.ContainsKey(secondVlogger)
                    //    && firstVlogger != secondVlogger)
                    //{
                    //    vloggerFollowers[secondVlogger].Add(firstVlogger);
                    //    vloggerFollowing[firstVlogger].Add(secondVlogger);
                    //}
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var sortedVloggers = vloggers
                .OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Following.Count);

            //var sortedVloggers = vloggerFollowers
            //    .OrderByDescending(x => x.Value.Count)
            //    .ThenBy(x => vloggerFollowing[x.Key].Count);

            int counter = 0;

            foreach (var item in sortedVloggers)
            {
                Console.WriteLine($"{++counter}. {item.Key} : {item.Value.Followers.Count} followers, {item.Value.Following.Count} following");

                //Console.WriteLine($"{++counter}. {item.Key} : {item.Value.Count} followers, {vloggerFollowing[item.Key].Count} following");

                if (counter == 1)
                {
                    foreach (var vlogger in item.Value.Followers)
                    {
                        Console.WriteLine($"*  {vlogger}");
                    }
                }
            }
        }

        class Vlogger
        {
            public Vlogger()
            {
                Followers = new SortedSet<string>();
                Following = new SortedSet<string>();
            }

            public SortedSet<string> Followers { get; set; }

            public SortedSet<string> Following { get; set; }
        }
    }
}

