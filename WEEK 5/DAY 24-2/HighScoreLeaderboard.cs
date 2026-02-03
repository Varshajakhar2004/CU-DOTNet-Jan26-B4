namespace Week_5
{
    internal class HighScoreLeaderboard
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, string> Leaderboard = new SortedDictionary<double, string>();

            Leaderboard.Add(55.42, "SwiftRacer");
            Leaderboard.Add(52.10, "SpeedDemon");
            Leaderboard.Add(58.91, "SteadyEddie");
            Leaderboard.Add(51.05, "TurboTom");

            Console.WriteLine("After automatic sorting verification:");

            foreach (var entry in Leaderboard)
            {
                Console.WriteLine($"Time:{entry.Key}, Player:{entry.Value}");
            }

            var goldMedalEntry = Leaderboard.First();
            Console.WriteLine("Gold medal:");
            Console.WriteLine($"Player:{goldMedalEntry.Value}, Time:{goldMedalEntry.Key}");

            double oldTime = 0;
            bool found = false;
            foreach (var entry in Leaderboard)
            {
                if (entry.Value == "SteadyEddie")
                {
                    oldTime = entry.Key;
                    found = true;
                }
            }
            if (found)
            {
                Leaderboard.Remove(oldTime);      
                Leaderboard.Add(54.00, "SteadyEddie");
            }

            Console.WriteLine("Updated leaderboard:");
            foreach (var entry in Leaderboard)
            {
                Console.WriteLine($"Time:{entry.Key},Player:{entry.Value}");
            }
        }
    }
}
