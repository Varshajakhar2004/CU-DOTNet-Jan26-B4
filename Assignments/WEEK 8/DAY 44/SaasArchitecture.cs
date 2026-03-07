using System.Text;

namespace WEEK8
{
    public abstract class Subscriber : IComparable<Subscriber>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }

        protected Subscriber(string name, DateTime joinDate)
        {
            ID = Guid.NewGuid();
            Name = name;
            JoinDate = joinDate;
        }

        public abstract decimal CalculateMonthlyBill();

        public override bool Equals(object obj)
        {
            if (obj is Subscriber other)
                return this.ID == other.ID;

            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public int CompareTo(Subscriber other)
        {
            int dateComparison = this.JoinDate.CompareTo(other.JoinDate);

            if (dateComparison == 0)
                return this.Name.CompareTo(other.Name);

            return dateComparison;
        }
    }
    public class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }
        public decimal TaxRate { get; set; }

        public BusinessSubscriber(string name, DateTime joinDate,
                                  decimal fixedRate, decimal taxRate)
            : base(name, joinDate)
        {
            FixedRate = fixedRate;
            TaxRate = taxRate;
        }

        public override decimal CalculateMonthlyBill()
        {
            return FixedRate * (1+TaxRate);
        }
    }
    public class ConsumerSubscriber : Subscriber
    {
        public decimal DataUsageGB { get; set; }
        public decimal PricePerGB { get; set; }

        public ConsumerSubscriber(string name, DateTime joinDate,
                                  decimal dataUsageGB, decimal pricePerGB)
            : base(name, joinDate)
        {
            DataUsageGB = dataUsageGB;
            PricePerGB = pricePerGB;
        }

        public override decimal CalculateMonthlyBill()
        {
            return DataUsageGB * PricePerGB;
        }
    }
    public class ReportGenerator
    {
        public static void PrintRevenueReport(IEnumerable<Subscriber> subscribers)
        {
            Console.WriteLine("===== MONTHLY REVENUE REPORT =====");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Type\t\tName\t\tJoin Date\t\tBill");
            Console.WriteLine("-----------------------------------------------------------");

            foreach (var sub in subscribers)
            {
                string type = sub is BusinessSubscriber ? "Business" : "Consumer";

                Console.WriteLine($"{type}\t{sub.Name}\t{sub.JoinDate.ToShortDateString()}\t{sub.CalculateMonthlyBill():C}"
                );
            }
            Console.WriteLine("-----------------------------------------------------------");
        }
    }

    internal class SaasArchitecture
    {
        static void Main(string[] args)
        {
            Dictionary<string, Subscriber> subscribers =
                new Dictionary<string, Subscriber>();

            subscribers.Add("biz1@corp.com",
                new BusinessSubscriber("ABCSD", new DateTime(2023, 1, 10), 10800m, 0.18m));

            subscribers.Add("biz2@corp.com",
                new BusinessSubscriber("LMNAO", new DateTime(2023, 2, 15), 15870m, 0.18m));

            subscribers.Add("user1@gmail.com",
                new ConsumerSubscriber("Varsha", new DateTime(2023, 3, 25), 12009m, 10m));

            subscribers.Add("user2@gmail.com",
                new ConsumerSubscriber("QWERT", new DateTime(2023, 4, 1), 8078m, 12m));

            subscribers.Add("user3@gmail.com",
                new ConsumerSubscriber("VNMXJS", new DateTime(2023, 2, 20), 20009m, 18m));

            var sortedByRevenue = subscribers
                .OrderByDescending(s => s.Value.CalculateMonthlyBill())
                .Select(s => s.Value)
                .ToList();

            ReportGenerator.PrintRevenueReport(sortedByRevenue);
        }
    }

}

