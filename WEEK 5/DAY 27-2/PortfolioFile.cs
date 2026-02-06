using System.Text;

namespace Week_5
{
    public class Loan
    {
        public string ClientName { get; set; }
        public double Principal { get; set; }
        public double InterestRate { get; set; }
    }

    internal class PortfolioFile
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string directory = @"../../../";
            string file = "loans.csv";
            string path = directory + file;

            if (!File.Exists(path))
            {
                using StreamWriter empty = new StreamWriter(path);
                empty.WriteLine("ClientName,Principal,InterestRate");
            }

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                Console.WriteLine("Enter the name of client:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the principal amount:");
                double.TryParse(Console.ReadLine(), out double principalAmount);

                Console.WriteLine("Enter the interest rate:");
                double.TryParse(Console.ReadLine(), out double interestRate);

                writer.WriteLine($"{name},{principalAmount},{interestRate}");
            }

            Console.WriteLine("\n------------------ THE LOAN PORTFOLIO MANAGER ------------------\n");
            Console.WriteLine("CLIENT     |   PRINCIPAL    |   INTEREST    | RISK LEVEL");
            Console.WriteLine("----------------------------------------------------------");

            string[] lines = File.ReadAllLines(path);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');

                if (parts.Length != 3)
                    continue;

                string clientName = parts[0];
                double principalAmount = double.Parse(parts[1]);
                double interestRate = double.Parse(parts[2]);

                double interestAmount = (principalAmount * interestRate) / 100;

                string riskLevel =
                    interestRate > 10 ? "HIGH" :
                    interestRate >= 5 ? "MEDIUM" :
                    "LOW";

                Console.WriteLine(
                    $"{clientName,-10} | " +
                    $"{principalAmount,12:C} | " +
                    $"{interestAmount,11:C} | " +
                    $"{riskLevel}"
                );
            }
        }
    }
}
