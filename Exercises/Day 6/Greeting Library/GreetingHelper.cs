using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Library
{
    public class GreetingHelper
    {
        public static string GetGreeting(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "Hello, Guest!";
            }
            return $"Hello, {name}!";
        }
    }
}
