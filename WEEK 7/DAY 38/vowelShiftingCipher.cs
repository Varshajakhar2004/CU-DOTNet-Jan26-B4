using System;
using System.Text;

namespace Class_Practice
{
    internal class vowelShiftingCipher
    {
        public string VowelShiftCipher(string s)
        {
            if (string.IsNullOrEmpty(s))
                return "";

            StringBuilder result = new StringBuilder();

            foreach (char ch in s)
            {
                if (ch == 'a') result.Append('e');
                else if (ch == 'e') result.Append('i');
                else if (ch == 'i') result.Append('o');
                else if (ch == 'o') result.Append('u');
                else if (ch == 'u') result.Append('a');
                else
                {
                    char next = (char)(ch + 1);

                    if (next > 'z')
                        next = 'a';

                    if ("aeiou".Contains(next))
                    {
                        next++;
                        if (next > 'z')
                            next = 'a';
                    }

                    result.Append(next);
                }
            }

            return result.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter lowercase string:");
            string input = Console.ReadLine();

            vowelShiftingCipher obj = new vowelShiftingCipher();
            string output = obj.VowelShiftCipher(input);

            Console.WriteLine("Output: " + output);
        }
    }
}
