using System.Diagnostics;
using FinTrackPro.Models;
using Microsoft.AspNetCore.Mvc;
using FinTrackPro.Data;
using Microsoft.EntityFrameworkCore;

namespace FinTrackPro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FinTrackProContext _context;

        public HomeController(ILogger<HomeController> logger, FinTrackProContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var vm = new DashboardViewModel();

            vm.TotalAccounts = _context.Account.Count();
            vm.TotalBalance = _context.Account.Sum(a => a.Balance);

            var allTx = _context.Transaction
                        .Include(t => t.Account)
                        .AsNoTracking()
                        .OrderByDescending(t => t.Date)
                        .ToList();
            vm.TotalCredit = allTx.Where(t => (t.Category ?? "").Equals("Credit", System.StringComparison.OrdinalIgnoreCase)).Sum(t => t.Amount);
            vm.TotalDebit = allTx.Where(t => (t.Category ?? "").Equals("Debit", System.StringComparison.OrdinalIgnoreCase)).Sum(t => t.Amount);

            vm.RecentTransactions = allTx.Take(10).ToList();

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
