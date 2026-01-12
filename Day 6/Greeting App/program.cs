using Greeting_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_App
{
    internal class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            string greeting = GreetingHelper.GetGreeting(name);
            Console.WriteLine(greeting);
        }
    }
}
