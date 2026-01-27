using System.Threading.Channels;

namespace week_4
{

    class Loan
    {

        public Loan()
        {
            LoanNumber = string.Empty;
            CustomerName = string.Empty;
            PrincipalAmount = 0.0M;
            TenureInYear = 0;
        }

        public Loan(string loanNumber, string customerName, decimal principalAmount, int tenureInYear)
        {
            LoanNumber = loanNumber;
            CustomerName = customerName;
            PrincipalAmount = principalAmount;
            TenureInYear = tenureInYear;
            Console.WriteLine("base class ");
        }
        public string LoanNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal PrincipalAmount { get; set; }
        public int TenureInYear { get; set; }

        public virtual decimal  CalculateEMI()
        {
            decimal rate = 10M; // 10% simple interest
            decimal simpleInterest = (PrincipalAmount * rate * TenureInYear) / 100;
            decimal totalAmount = PrincipalAmount + simpleInterest;

            int totalMonths = TenureInYear * 12;

            return totalAmount / totalMonths;
        }   
    }

    class HomeLoan : Loan
    {
        public HomeLoan(string loanNumber,
                    string customerName,
                    decimal principalAmount,
                    int tenureInYear)
        : base(loanNumber, customerName, principalAmount, tenureInYear)
        {

        }
        


        public override decimal CalculateEMI()
        {
            decimal rate = 08M; // 10% simple interest
            decimal simpleInterest = (PrincipalAmount * rate * TenureInYear) / 100;
            decimal totalAmount = PrincipalAmount + simpleInterest;

            int totalMonths = TenureInYear * 12;

            return totalAmount / totalMonths;
        }
    }

    class CarLoan : Loan
    {

        public CarLoan(string loanNumber,
                    string customerName,
                    decimal principalAmount,
                    int tenureInYear)
        : base(loanNumber, customerName, principalAmount, tenureInYear)
        {

        }
        public override decimal CalculateEMI()
        {
            decimal rate = 09M;
            decimal simpleInterest = (PrincipalAmount * rate * TenureInYear) / 100;
            decimal totalAmount = PrincipalAmount + simpleInterest + 15000;
            int totalMonths = TenureInYear * 12;

            return totalAmount / totalMonths;

        }

    }
    internal class Demo05LoanInheritance
    {
        static void Main(string[] args)
        {
            Loan[] loans = new Loan[4]
            {
              new HomeLoan("H1001", "VARSHA", 500000M, 3),
              new HomeLoan("S2002", "Suraj", 100000M, 5),
              new CarLoan("C3001", "Amit", 200000M, 2),
              new CarLoan("C3002", "Rita", 400000M, 4)
            };

            for (int i=0; i<loans.Length; i++)
            {
                Loan loan = loans[i];
                decimal emi = loan.CalculateEMI();

                if (loan is  HomeLoan)
                Console.WriteLine($"HomeLoan EMI ({loan.CustomerName}) : {emi :F2}");
                else if (loan is CarLoan)
                Console.WriteLine($"CarLoan EMI ({loan.CustomerName}) : {emi :F2}");
            }

        }
    }
}
