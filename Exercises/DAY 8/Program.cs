namespace LoginMessageProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

           
            string[] parts = input.Split('|');// Splitting
            string user = parts[0].Trim();
            string message = parts[1].Trim().ToLower();

            string standard = "login successful";//messages to be displayed
            string status;
            if (!message.Contains("successful"))
                status = "LOGIN FAILED";
            else if (message == standard)
                status = "LOGIN SUCCESS";
            else
                status = "LOGIN SUCCESS (CUSTOM MESSAGE)";

            Console.WriteLine("User     : " + user);// output
            Console.WriteLine("Message  : " + message);
            Console.WriteLine("Status   : " + status);

        }
    }
}

