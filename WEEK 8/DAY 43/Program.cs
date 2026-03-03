using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace FinancialPortfolioSystem
{
    //  CUSTOM EXCEPTION 
    public class InvalidFinancialDataException : Exception
    {
        public InvalidFinancialDataException(string message) : base(message) { }
    }

    //  INTERFACES 
    public interface IRiskAssessable
    {
        string GetRiskCategory();
    }

    public interface IReportable
    {
        string GenerateReportLine();
    }

    //  ABSTRACT CLASS
    public abstract class FinancialInstrument
    {
        private decimal quantity;
        private decimal purchasePrice;
        private decimal marketPrice;
        private string currency;

        public string InstrumentId { get; set; }
        public string Name { get; set; }
        public DateTime PurchaseDate { get; set; }

        public string Currency
        {
            get => currency;
            set
            {
                if (value.Length != 3)
                    throw new InvalidFinancialDataException("Currency must be 3-letter code.");
                currency = value.ToUpper();
            }
        }

        public decimal Quantity
        {
            get => quantity;
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Quantity cannot be negative.");
                quantity = value;
            }
        }

        public decimal PurchasePrice
        {
            get => purchasePrice;
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Purchase price cannot be negative.");
                purchasePrice = value;
            }
        }

        public decimal MarketPrice
        {
            get => marketPrice;
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Market price cannot be negative.");
                marketPrice = value;
            }
        }

        protected FinancialInstrument(string id, string name, string currency,
            decimal qty, decimal buyPrice, decimal mPrice)
        {
            InstrumentId = id;
            Name = name;
            Currency = currency;
            Quantity = qty;
            PurchasePrice = buyPrice;
            MarketPrice = mPrice;
            PurchaseDate = DateTime.Now;
        }

        public decimal Investment() => Quantity * PurchasePrice;

        public abstract decimal CalculateCurrentValue();

        public virtual string GetInstrumentSummary()
        {
            return $"{InstrumentId} - {Name} | Value: {CalculateCurrentValue():C}";
        }
    }

    // INSTRUMENT TYPES 
    public class Equity : FinancialInstrument, IRiskAssessable, IReportable
    {
        public Equity(string id, string name, string currency,
            decimal qty, decimal buyPrice, decimal mPrice)
            : base(id, name, currency, qty, buyPrice, mPrice) { }

        public override decimal CalculateCurrentValue()
            => Quantity * MarketPrice;

        public string GetRiskCategory() => "High";

        public string GenerateReportLine() => GetInstrumentSummary();
    }

    public class Bond : FinancialInstrument, IRiskAssessable, IReportable
    {
        public Bond(string id, string name, string currency,
            decimal qty, decimal buyPrice, decimal mPrice)
            : base(id, name, currency, qty, buyPrice, mPrice) { }

        public override decimal CalculateCurrentValue()
            => Quantity * MarketPrice;

        public string GetRiskCategory() => "Low";

        public string GenerateReportLine() => GetInstrumentSummary();
    }

    public class MutualFund : FinancialInstrument, IRiskAssessable
    {
        public MutualFund(string id, string name, string currency,
            decimal qty, decimal buyPrice, decimal mPrice)
            : base(id, name, currency, qty, buyPrice, mPrice) { }

        public override decimal CalculateCurrentValue()
            => Quantity * MarketPrice;

        public string GetRiskCategory() => "Medium";
    }

    public class FixedDeposit : FinancialInstrument
    {
        public FixedDeposit(string id, string name, string currency,
            decimal qty, decimal buyPrice, decimal mPrice)
            : base(id, name, currency, qty, buyPrice, mPrice) { }

        public override decimal CalculateCurrentValue()
            => Quantity * MarketPrice;
    }

    //PORTFOLIO
    public class Portfolio
    {
        private List<FinancialInstrument> instruments = new();
        private Dictionary<string, FinancialInstrument> lookup = new();

        public void AddInstrument(FinancialInstrument instrument)
        {
            if (lookup.ContainsKey(instrument.InstrumentId))
                throw new Exception("Duplicate Instrument ID.");

            if (lookup.Count > 0 &&
                lookup.Values.First().Currency != instrument.Currency)
                throw new Exception("Currency mismatch in portfolio.");

            instruments.Add(instrument);
            lookup[instrument.InstrumentId] = instrument;
        }

        public void RemoveInstrument(string id)
        {
            if (lookup.ContainsKey(id))
            {
                instruments.Remove(lookup[id]);
                lookup.Remove(id);
            }
        }

        public FinancialInstrument GetInstrumentById(string id)
            => lookup.ContainsKey(id) ? lookup[id] : null;

        public decimal GetTotalPortfolioValue()
            => instruments.Sum(i => i.CalculateCurrentValue());

        public List<FinancialInstrument> GetInstrumentsByRisk(string risk)
        {
            return instruments
                .OfType<IRiskAssessable>()
                .Where(i => i.GetRiskCategory() == risk)
                .Cast<FinancialInstrument>()
                .ToList();
        }

        public List<FinancialInstrument> GetAll() => instruments;
    }

    // TRANSACTION
    public class Transaction
    {
        public string TransactionId { get; set; }
        public string InstrumentId { get; set; }
        public string Type { get; set; } 
        public decimal Units { get; set; }
        public DateTime Date { get; set; }

        public void Apply(Portfolio portfolio)
        {
            var instrument = portfolio.GetInstrumentById(InstrumentId);
            if (instrument == null)
                throw new Exception("Instrument not found.");

            if (Type == "Buy")
                instrument.Quantity += Units;
            else if (Type == "Sell")
            {
                if (Units > instrument.Quantity)
                    throw new Exception("Selling more than owned.");
                instrument.Quantity -= Units;
            }
        }
    }

    // REPORT GENERATOR
    public class ReportGenerator
    {
        public void GenerateConsoleReport(Portfolio portfolio)
        {
            Console.WriteLine("\n-----------PORTFOLIO SUMMARY-------------------");

            var grouped = portfolio.GetAll()
                .GroupBy(i => i.GetType().Name);

            foreach (var group in grouped)
            {
                decimal totalInvestment = group.Sum(i => i.Investment());
                decimal totalCurrent = group.Sum(i => i.CalculateCurrentValue());

                Console.WriteLine($"\nInstrument Type: {group.Key}");
                Console.WriteLine($"Total Investment: {totalInvestment:C}");
                Console.WriteLine($"Current Value: {totalCurrent:C}");
                Console.WriteLine($"Profit/Loss: {(totalCurrent - totalInvestment):C}");
            }

            Console.WriteLine($"\nOverall Portfolio Value: {portfolio.GetTotalPortfolioValue():C}");

            var riskDistribution = portfolio.GetAll()
                .OfType<IRiskAssessable>()
                .GroupBy(r => r.GetRiskCategory());

            Console.WriteLine("\nRisk Distribution:");
            foreach (var risk in riskDistribution)
                Console.WriteLine($"{risk.Key}: {risk.Count()}");
        }

        public void GenerateFileReport(Portfolio portfolio)
        {
            string fileName = $"PortfolioReport_{DateTime.Now:yyyyMMdd}.txt";

            try
            {
                using StreamWriter sw = new StreamWriter(fileName);

                sw.WriteLine("PORTFOLIO REPORT");
                sw.WriteLine($"Generated on: {DateTime.Now}");
                sw.WriteLine("--------------------------------");

                foreach (var inst in portfolio.GetAll()
                    .OrderByDescending(i => i.CalculateCurrentValue()))
                {
                    sw.WriteLine(inst.GetInstrumentSummary());
                }

                sw.WriteLine("--------------------------------");
                sw.WriteLine($"Total Portfolio Value: {portfolio.GetTotalPortfolioValue():C}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("File write permission error.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Portfolio portfolio = new Portfolio();

            string csv = "EQ001,Equity,INFY,INR,100,1500,1650";
            string[] parts = csv.Split(',');

            if (parts.Length != 7)
                throw new Exception("Invalid CSV format.");

            FinancialInstrument eq = new Equity(
                parts[0], parts[2], parts[3],
                decimal.Parse(parts[4]),
                decimal.Parse(parts[5]),
                decimal.Parse(parts[6]));

            portfolio.AddInstrument(eq);

            portfolio.AddInstrument(new Bond("BD001", "Gov Bond", "INR", 50, 1000, 1050));
            portfolio.AddInstrument(new MutualFund("MF001", "HDFC MF", "INR", 200, 500, 550));
            portfolio.AddInstrument(new FixedDeposit("FD001", "SBI FD", "INR", 1, 100000, 110000));

            Transaction[] transactions =
            {
                new Transaction{ TransactionId="T1", InstrumentId="EQ001", Type="Buy", Units=10, Date=DateTime.Now },
                new Transaction{ TransactionId="T2", InstrumentId="EQ001", Type="Sell", Units=5, Date=DateTime.Now }
            };

            List<Transaction> transactionList = transactions.ToList();

            foreach (var t in transactionList)
                t.Apply(portfolio);

            ReportGenerator report = new ReportGenerator();
            report.GenerateConsoleReport(portfolio);
            report.GenerateFileReport(portfolio);

            Console.ReadLine();
        }
    }
}
