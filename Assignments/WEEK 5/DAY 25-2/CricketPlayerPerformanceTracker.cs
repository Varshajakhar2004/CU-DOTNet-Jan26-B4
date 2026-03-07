namespace Week_5
{
    internal class Player
    {
        public string Name { get; set; }
        public int RunsScored { get; set; }
        public int BallsFaced { get; set; }
        public bool IsOut { get; set; }
        public double StrikeRate { get; set; }
        public double Average { get; set; }
    }

    internal class CricketPlayerPerformanceTracker
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();

            Console.WriteLine("Enter full CSV file path:");
            string path = Console.ReadLine();

            if (!File.Exists(path))
            {
                Console.WriteLine("Error: File not found.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    // Skip header
                    if (line.StartsWith("Name"))
                        continue;

                    try
                    {
                        string[] data = line.Split(',');

                        if (data.Length < 4)
                            throw new FormatException();

                        string name = data[0].Trim();
                        int runs = int.Parse(data[1].Trim());
                        int balls = int.Parse(data[2].Trim());
                        bool isOut = bool.Parse(data[3].Trim());

                        double strikeRate = balls == 0 ? 0 : (double)runs / balls * 100;

                        players.Add(new Player
                        {
                            Name = name,
                            RunsScored = runs,
                            BallsFaced = balls,
                            IsOut = isOut,
                            StrikeRate = strikeRate,
                            Average = runs
                        });
                    }
                    catch
                    {
                        Console.WriteLine($"Invalid data format: {line}");
                    }
                }

                var result = players
                    .Where(p => p.BallsFaced >= 10)
                    .OrderByDescending(p => p.StrikeRate)
                    .ToList();

                Console.WriteLine("\nName            Runs    SR      Avg");
                Console.WriteLine("---------------------------------------");

                foreach (var p in result)
                {
                    Console.WriteLine(
                        $"{p.Name,-15} {p.RunsScored,-7} {p.StrikeRate,6:F2} {p.Average,8:F2}"
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
