namespace week_4
{
    internal class UtilityBillingSystem
    {
        abstract class UtilityBill
        {
            public UtilityBill()
            {
                ConsumerId = 0;
                ConsumerName = string.Empty;
                UnitsCovered = 0.0M;
                RatePerUnit = 0.0M;
            }


            public UtilityBill(int consumerId, string consumerName, decimal unitsCovered, decimal ratePerUnit)
            {
                ConsumerId = consumerId;
                ConsumerName = consumerName;
                UnitsCovered = unitsCovered;
                RatePerUnit = ratePerUnit;
            }

            public int ConsumerId { get; set; }
            public string ConsumerName { get; set; }
            public decimal UnitsCovered { get; set; }
            public decimal RatePerUnit { get; set; }


            public abstract decimal CalculateBillAmount();

            public virtual decimal CalculateTaxAmount(decimal billAmount)
            {
                return billAmount *0.5M;
            }


            public void PrintBill()
            {
                decimal BillAmount = CalculateBillAmount();
                decimal TaxAmount = CalculateTaxAmount(BillAmount);
                decimal TotalBill = BillAmount + TaxAmount;

                Console.WriteLine($"Consumer ID - {ConsumerId}");
                Console.WriteLine($"Consumer Name - {ConsumerName}");
                Console.WriteLine($"Units Covered - {UnitsCovered}");
                Console.WriteLine($"Rate per unit - {RatePerUnit}");
                Console.WriteLine($"Payable amount - {TotalBill}");
            }
        }

        class ElectricityBill : UtilityBill
        {
            public ElectricityBill(int CustomerId, string CustomerName, decimal UnitsCovered, decimal RatePerUnit) : base(CustomerId, CustomerName, UnitsCovered, RatePerUnit)
            {

            }

            public override decimal CalculateBillAmount()
            {
                decimal TotalBill = UnitsCovered * RatePerUnit;
                if (UnitsCovered > 300)
                {
                    TotalBill += TotalBill * 0.10M;
                }
                return TotalBill;
            }
        }

        class WaterBill : UtilityBill
        {
            public WaterBill(int CustomerId, string CustomerName, decimal UnitsCovered, decimal RatePerUnit) : base(CustomerId, CustomerName, UnitsCovered, RatePerUnit)
            {

            }

            public override decimal CalculateBillAmount()
            {
                return UnitsCovered * RatePerUnit;
            }   

            public override decimal CalculateTaxAmount(decimal billAmount)
            {
                return billAmount * 0.2M;
            }
        }


        class GasBill : UtilityBill
        {
            public GasBill(int CustomerId, string CustomerName, decimal UnitsCovered, decimal RatePerUnit) : base(CustomerId, CustomerName, UnitsCovered, RatePerUnit)
            {

            }

            public override decimal CalculateBillAmount()
            {
                return (UnitsCovered* RatePerUnit) + 150 ;
            }

            public override decimal CalculateTaxAmount(decimal billAmount)
            {
                return 0;
            }
        }
        static void Main(string[] args)
        {
            UtilityBill electricityBill = new ElectricityBill(101, "VARSHA", 120.5M, 3.5M);
            UtilityBill waterBill = new WaterBill(102, "SURAJ", 250.0M, 6.6M);
            UtilityBill gasBill = new GasBill(103, "ANKIT", 150.9M, 5.5M);

            List<UtilityBill>bills = new List<UtilityBill> {  electricityBill, waterBill, gasBill};
            foreach (var item in bills)
            {
                item.PrintBill();
            }

            Console.WriteLine("Bills passed successfully");
        }
    }
}
