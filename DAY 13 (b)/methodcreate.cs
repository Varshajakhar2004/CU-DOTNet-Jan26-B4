namespace LineDisplayDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayLine();
            DisplayLine('+');
            DisplayLine('$', 60);


            PrintLine();   // for printing the all parameters using single method
            PrintLine(ch: '$');
            PrintLine(70);
            PrintLine(60, '+');
        }

        static void DisplayLine()
        {
            Console.WriteLine(new string('-', 40));
        }

        static void DisplayLine(char ch)
        {
            Console.WriteLine(new string(ch, 40));
        }

        static void DisplayLine(char ch, int count)
        {
            Console.WriteLine(new string(ch, count));
        }

            static void PrintLine(int num = 40, char ch = '-') // for printing the pararameters using single method  line 12 till 15
          {
            for (int i = 0; i < num; i++)
            {
                Console.Write(ch);
            }
            Console.WriteLine();
            }
    }
}

