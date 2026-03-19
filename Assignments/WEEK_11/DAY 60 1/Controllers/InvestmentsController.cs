using Microsoft.AspNetCore.Mvc;

public class InvestmentsController : Controller
{
    private readonly PortfolioContext _context;

    public InvestmentsController(PortfolioContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Investments.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(InvestmentCreateViewModel vm)
    {
        if (ModelState.IsValid)
        {
            var model = new Investment
            {
                TickerSymbol = vm.TickerSymbol,
                AssetName = vm.TickerSymbol,
                PurchasePrice = vm.Price,
                Quantity = vm.Quantity,
                PurchaseDate = DateTime.Now
            };

            _context.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(vm);
    }
}