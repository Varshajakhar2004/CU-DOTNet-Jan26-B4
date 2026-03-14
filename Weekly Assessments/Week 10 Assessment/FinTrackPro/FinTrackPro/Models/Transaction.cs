namespace FinTrackPro.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }

        public string Category { get; set; }   // Income / Expense

        public DateTime Date { get; set; }
    }
}