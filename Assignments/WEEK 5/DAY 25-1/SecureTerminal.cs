namespace Week_5
{
    internal class SecureTerminal
    {
        static void Main(string[] args)
        {
            string pin = "";
            Console.WriteLine("Enter the secret 4-digit pin:");

            while(pin.Length<4)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if(char.IsDigit(keyInfo.KeyChar) )
                {
                   pin += keyInfo.KeyChar;
                    Console.Write("*");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Your secret pin is :{pin} ");
        }
    }
}
