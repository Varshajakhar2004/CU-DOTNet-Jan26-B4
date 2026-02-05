using System.Numerics;

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
            Console.WriteLine("Enter the CSV path");
            string filepath = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(filepath);

                foreach (string line in lines)
                {
                    try
                    {
                        string[] data = line.Split(',');

                        string name = data[0].Trim();
                        int runs = int.Parse(data[1].Trim());
                        int balls = int.Parse(data[2].Trim());
                        bool isOut = bool.Parse(data[3].Trim());

                        double strikeRate = balls == 0 ? 0 : (double)runs / balls * 100;
                        double average = isOut ? runs : runs;

                        Player player = new Player
                        {
                            Name = name,
                            RunsScored = runs,
                            BallsFaced = balls,
                            IsOut = isOut,
                            StrikeRate = strikeRate,
                            Average = average
                        };


                        players.Add(player);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Invalid data format in line: {line}");
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine($"Cannot calculate strike rate (balls = 0) in line: {line}");
                    }
                }

                var filteredPlayers = players
                    .Where(p => p.BallsFaced >= 10)
                    .OrderByDescending(p => p.StrikeRate)
                    .ToList();

                Console.WriteLine("\nName            Runs    SR      Avg");
                Console.WriteLine("---------------------------------------");

                foreach (var p in filteredPlayers)
                {
                    Console.WriteLine(
                        $"{p.Name,-15} {p.RunsScored,-7} {p.StrikeRate,6:F2} {p.Average,8:F2}"
                    );
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: The specified CSV file was not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}

        
    

