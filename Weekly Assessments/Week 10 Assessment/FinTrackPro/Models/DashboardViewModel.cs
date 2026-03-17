using System.Collections.Generic;

namespace FinTrackPro.Models
{
    public class DashboardViewModel
    {
        public int TotalAccounts { get; set; }
        public double TotalBalance { get; set; }
        public double TotalCredit { get; set; }
        public double TotalDebit { get; set; }
        public List<Transaction> RecentTransactions { get; set; } = new List<Transaction>();
    }
}
