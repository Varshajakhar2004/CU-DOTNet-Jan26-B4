namespace Week_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select services (yes/no)");
            Console.Write("Treadmill: ");
            bool treadmill = Console.ReadLine().ToLower() == "yes"; 
            Console.Write("Weight Lifting: ");
            bool weightLifting = Console.ReadLine().ToLower() == "yes";
            Console.Write("Zumba: ");
            bool zumba = Console.ReadLine().ToLower() == "yes";
            
            double totalAmount;
            CalculateMembershipAmount(treadmill, weightLifting, zumba, out totalAmount);            // Method call using out
            Console.WriteLine("Total Membership Amount for gym = " + totalAmount);
        }

        static void CalculateMembershipAmount(
            bool treadmill,
            bool weightLifting,
            bool zumba,
            out double totalAmount)
        {
            int amount = 1000;   // fixed monthly charge

            if (treadmill || weightLifting || zumba)            // At least one service is mandatory
            {
                if (treadmill) amount += 300;
                if (weightLifting) amount += 500;
                if (zumba) amount += 250;
            }
            else
            {
                amount += 200;    // penalty for not opting any service
                Console.WriteLine("NO SERVICE OPTED");
            }

            double gst = amount * 0.05;
            totalAmount = amount + gst;
        }
    }
}
