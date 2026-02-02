namespace Bank_Transaction_Narration_Analyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();  
            string[] data = input.Split('#');

            string transactionId = data[0];
            string accountHolder = data[1];
            string narration = data[2];

            narration = narration.Trim();

            while(narration.Contains(" "))
            {
                narration = narration.Replace("  ", " ");
            }

            narration = narration.ToLower();

            bool hasDeposit = narration.Contains("deposit");
            bool hasWithdrawal = narration.Contains("withdrawal");
            bool hasTransfer = narration.Contains("transfer");

            bool hasKeyword = hasDeposit || hasWithdrawal || hasTransfer;

            string standardNarration = "cash deposit successful";
            bool isStandard = narration.Equals(standardNarration);

            string category;
            if(!hasKeyword)
            {
                category = "Non Financial transaction";
            }
            else if(hasKeyword && isStandard)
            {
                category = "Standard transaction";
            }
            else
            {
                category = "Custom transaction";
            }

            Console.WriteLine("Transaction ID:" + transactionId);
            Console.WriteLine("Account Holder :" + accountHolder);
            Console.WriteLine("Narration:" + narration);
            Console.WriteLine("Category:" + category);

        }
    }
}
