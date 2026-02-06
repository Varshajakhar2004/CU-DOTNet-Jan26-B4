using System.Globalization;

namespace Week_5
{
    internal class DailyLogger
    {
        static void Main(string[] args)
        {
            string directory = @"../../../";
            if(!Directory.Exists(directory))
            {
                Console.WriteLine("Directory does not exist");
                return;
            }

            string file = "journal.txt";
            string path = directory + file;

            using StreamWriter sw = new StreamWriter(path, true);

            do
            {
                Console.WriteLine("Enter the daily data");
                string data = Console.ReadLine();
                if (data == "stop")
                    break;
                sw.WriteLine(data);

                DateTime today = DateTime.Today; 
                sw.WriteLine($"{today:dd-MM-yyyy} : {data}");
            } while (true);
        }
    }
}
