using System;

namespace Class_Practice
{
    internal class SplitWiseForShares
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter the number of total people:");
            int n = Convert.ToInt32(Console.ReadLine());

            double[] paid = new double[n];
            double total = 0;

            for (int i = 0; i < n; i++)// humne total nikala
            {
                Console.WriteLine($"Enter the amount paid{i+1}: ");
                paid[i]  = Convert.ToDouble(Console.ReadLine());
                total += paid[i];
            }

            double share = total / n;//then kitna kitna share hoga per head
            Console.WriteLine($"Total share per head is{share}");


            double[] diff = new double[n];//then difference ki kisko kitna dena h ya lena h
            for (int i = 0; i < n; i++)
            {
                diff[i] = paid[i] - share;   
            }

            Console.WriteLine("Who pays whom:");

            for (int i = 0; i < n; i++)//jisko money deni hogi
            {
                if (diff[i] < 0) 
                {
                    for (int j = 0; j < n; j++)//jisko receive krni h 
                    {
                        if(diff[j] > 0)
                        {
                            double amount;
                            if (-diff[i] < diff[j])
                            {
                                amount = -diff[i];   // jitna i dega
                            }
                            else
                            {
                                amount = diff[j];    // jitna j ko receive krna h
                            }

                            Console.WriteLine($"Person {i + 1} pays {amount} to Person {j + 1}");

                            diff[i] += amount;//jitna diya vo km krna h and jitna liya vo add 
                            diff[j] -= amount;

                            if (diff[i] == 0) //-------------if paid amount= share then break the loop
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("Splitting is done");
        }
    }
}
