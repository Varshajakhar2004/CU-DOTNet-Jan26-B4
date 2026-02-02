using System;

class Program
{
    static void Main()
    {
        decimal[] sales = new decimal[7]; 
        string[] category = new string[7];

        ReadWeeklySales(sales);

        decimal total = CalculateTotal(sales);
        decimal average = CalculateAverage(total, 7);

        int highDay, lowDay; // to store the day of highest and lowest sales
        decimal highest = FindHighestSale(sales, out highDay);
        decimal lowest = FindLowestSale(sales, out lowDay);

        decimal discount = CalculateDiscount(total, true); // festival week
        decimal tax = CalculateTax(total - discount);
        decimal finalAmount = CalculateFinalAmount(total, discount, tax);

        GenerateSalesCategory(sales, category); // categorize sales

        Console.WriteLine("\nWeekly Sales Summary");
        Console.WriteLine("--------------------");
        Console.WriteLine("Total Sales        : " + total);
        Console.WriteLine("Average Daily Sale : " + average);
        Console.WriteLine();
        Console.WriteLine("Highest Sale       : " + highest + " (Day " + highDay + ")");
        Console.WriteLine("Lowest Sale        : " + lowest + " (Day " + lowDay + ")");
        Console.WriteLine();
        Console.WriteLine("Discount Applied   : " + discount);
        Console.WriteLine("Tax Amount         : " + tax);
        Console.WriteLine("Final Payable      : " + finalAmount);
        Console.WriteLine();

        for (int i = 0; i < 7; i++) // display sales category
        {
            Console.WriteLine("Day " + (i + 1) + " : " + category[i]);
        }
    }

    static void ReadWeeklySales(decimal[] sales)
    {
        for (int i = 0; i < sales.Length; i++)
        {
            Console.Write("Enter Day " + (i + 1) + " Sales: ");
            sales[i] = Convert.ToDecimal(Console.ReadLine());
        }
    }
    static decimal CalculateTotal(decimal[] sales)
    {
        decimal sum = 0;
        for (int i = 0; i < sales.Length; i++)
            sum += sales[i];
        return sum;
    }

    static decimal CalculateAverage(decimal total, int days)
    {
        return total / days;
    }
    static decimal FindHighestSale(decimal[] sales, out int day)
    {
        decimal max = sales[0];
        day = 1;

        for (int i = 1; i < sales.Length; i++)
        {
            if (sales[i] > max)
            {
                max = sales[i];
                day = i + 1;
            }
        }
        return max;
    }
    static decimal FindLowestSale(decimal[] sales, out int day)
    {
        decimal min = sales[0];
        day = 1;

        for (int i = 1; i < sales.Length; i++)
        {
            if (sales[i] < min)
            {
                min = sales[i];
                day = i + 1;
            }
        }
        return min;
    }

    static decimal CalculateDiscount(decimal total)
    {
        if (total >= 50000)
            return total * 0.10m;
        else
            return total * 0.05m;
    }
    static decimal CalculateDiscount(decimal total, bool festival)
    {
        decimal discount = CalculateDiscount(total);
        if (festival)
            discount += total * 0.05m;
        return discount;
    }

    static decimal CalculateTax(decimal amount)
    {
        return amount * 0.18m;
    }

    static decimal CalculateFinalAmount(decimal total, decimal discount, decimal tax)
    {
        return total - discount + tax;
    }

    static void GenerateSalesCategory(decimal[] sales, string[] category)
    {
        for (int i = 0; i < sales.Length; i++)
        {
            if (sales[i] < 5000)
                category[i] = "Low";
            else if (sales[i] <= 15000)
                category[i] = "Medium";
            else
                category[i] = "High";
        }
    }
}
