namespace WEEK_6
{
    internal class Splitwise
    {
        static List<string> SettleExpenseShare(Dictionary<string, double> expenses)
        {
            List<string> settlement = new List<string>();

            // Queues
            Queue<KeyValuePair<string, double>> receivers =
                new Queue<KeyValuePair<string, double>>();

            Queue<KeyValuePair<string, double>> payers =
                new Queue<KeyValuePair<string, double>>();

            var totalExpense = expenses.Values.Sum();
            var persons = expenses.Count;
            var share = totalExpense / persons;

            // Populate queues
            foreach (var person in expenses)
            {
                if (person.Value < share)
                {
                    // Person needs to PAY
                    payers.Enqueue(
                        new KeyValuePair<string, double>(
                            person.Key,
                            share - person.Value));
                }
                else if (person.Value > share)
                {
                    // Person needs to RECEIVE
                    receivers.Enqueue(
                        new KeyValuePair<string, double>(
                            person.Key,
                            person.Value - share));
                }
            }

            // Settlement
            while (payers.Count > 0 && receivers.Count > 0)
            {
                var payer = payers.Dequeue();
                var receiver = receivers.Dequeue();

                double amount = Math.Min(payer.Value, receiver.Value);

                settlement.Add($"{payer.Key}, {receiver.Key}, {amount}");

                // Remaining balances
                if (payer.Value > amount)
                {
                    payers.Enqueue(
                        new KeyValuePair<string, double>(
                            payer.Key,
                            payer.Value - amount));
                }

                if (receiver.Value > amount)
                {
                    receivers.Enqueue(
                        new KeyValuePair<string, double>(
                            receiver.Key,
                            receiver.Value - amount));
                }

                Console.WriteLine("settlement done");
            }

            return settlement;
        }

        static void Main(string[] args)
        {
            Dictionary<string, double> expenses =
                new Dictionary<string, double>()
                {
                    {"Varsha" ,100},
                    {"kriti", 200},
                    {"suraj", 300},
                    {"duggu",400 }
                };

            List<string> settlement = SettleExpenseShare(expenses);

            Console.WriteLine("\nFinal Settlement:");

            foreach (var payment in settlement)
            {
                Console.WriteLine(payment);
            }
        }
    }
}
