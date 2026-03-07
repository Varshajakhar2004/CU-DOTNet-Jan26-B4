using System;

namespace WeeklySalesAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            const int DAYS = 7;

            decimal[] dailySales = new decimal[DAYS];
            string[] salesCategory = new string[DAYS];

            for (int i = 0; i < DAYS; i++)
            {
                while (true)
                {
                    Console.Write($"Enter sales for Day {i + 1}: ");
                    bool isValid = decimal.TryParse(Console.ReadLine(), out decimal sale);

                    if (isValid && sale >= 0)
                    {
                        dailySales[i] = sale;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Sales must be a non-negative number.");
                    }
                }
            }

            decimal totalSales = 0;
            decimal highestSale = dailySales[0];
            decimal lowestSale = dailySales[0];
            int highestDay = 1;
            int lowestDay = 1;

            for (int i = 0; i < DAYS; i++)
            {
                totalSales += dailySales[i];

                if (dailySales[i] > highestSale)
                {
                    highestSale = dailySales[i];
                    highestDay = i + 1;
                }

                if (dailySales[i] < lowestSale)
                {
                    lowestSale = dailySales[i];
                    lowestDay = i + 1;
                }
            }

            decimal averageSales = totalSales / DAYS;

            int daysAboveAverage = 0;
            for (int i = 0; i < DAYS; i++)
            {
                if (dailySales[i] > averageSales)
                {
                    daysAboveAverage++;
                }
            }

            for (int i = 0; i < DAYS; i++)
            {
                if (dailySales[i] < 5000)
                {
                    salesCategory[i] = "Low";
                }
                else if (dailySales[i] <= 15000)
                {
                    salesCategory[i] = "Medium";
                }
                else
                {
                    salesCategory[i] = "High";
                }
            }

            Console.WriteLine("\nWeekly Sales Report");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Total Sales        : {totalSales:F2}");
            Console.WriteLine($"Average Daily Sale : {averageSales:F2}\n");

            Console.WriteLine($"Highest Sale       : {highestSale:F2} (Day {highestDay})");
            Console.WriteLine($"Lowest Sale        : {lowestSale:F2} (Day {lowestDay})\n");

            Console.WriteLine($"Days Above Average : {daysAboveAverage}\n");

            Console.WriteLine("Daily Sales Category Summary:");
            for (int i = 0; i < DAYS; i++)
            {
                Console.WriteLine($"Day {i + 1} : {salesCategory[i]}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

