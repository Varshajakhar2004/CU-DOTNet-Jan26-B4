namespace Week2Assessment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] policyHolderNames = new string[5];
            decimal[] annualPremiums = new decimal[5];

            Decimal totalPremium  = 0;
            Decimal highestPremium = 0;
            Decimal lowestPremium = 0;
            Decimal averagePremium;

            for (int i = 0; i < 5; i++)
            {
                while(true)
                {
                    Console.WriteLine($"Enter the name of account holder{i+1}");
                    policyHolderNames[i] = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(policyHolderNames[i]))
                        break;
                    Console.WriteLine("Name can not be empty, Enter again!!!");
                }
                while(true)
                {
                    Console.WriteLine($"Enter the annual premium for{policyHolderNames[i]}");
                    if (decimal.TryParse(Console.ReadLine(), out annualPremiums[i]) && annualPremiums[i] >= 0)
                        break;
                    Console.WriteLine("Invalid premium amount, Enter again!!!");
                }
                Console.WriteLine();
            }
            highestPremium = annualPremiums[0];
            lowestPremium = annualPremiums[0];
             
            for (int i = 0; i < 5; i++)
            {
                totalPremium += annualPremiums[i];
                if (annualPremiums[i] > highestPremium)
                    highestPremium = annualPremiums[i];
                if (annualPremiums[i] < lowestPremium)
                    lowestPremium = annualPremiums[i];
            }
            averagePremium = totalPremium / 5;

            Console.WriteLine("Insurance Premium Summary");
            Console.WriteLine("------------------------");
            Console.WriteLine("Name\tPremium\tCategory");
            Console.WriteLine("--------------------------------------");

            for (int i = 0; i < 5; i++)
            {
                string category;
                if (annualPremiums[i] < 10000)
                    category = "Low";
                else if (annualPremiums[i] <= 25000)
                    category = "Medium";
                else
                    category = "High";
                Console.WriteLine($"{policyHolderNames[i].ToUpper(),-15}{annualPremiums[i],-15:F2}{category}");
            }
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"Total Premium:{totalPremium:F2}");
            Console.WriteLine($"Highest Premium:{highestPremium:F2}");
            Console.WriteLine($"Lowest Premium:{lowestPremium:F2}");
            Console.WriteLine($"Average Premium:{averagePremium:F2}");

            Console.ReadLine();

        }
    }
}
