using Microsoft.AspNetCore.Mvc;

public class MarketController : Controller
{
    public IActionResult Summary()
    {
        ViewBag.Status = "Open";

        ViewData["TopGainer"] = "TCS";
        ViewData["Volume"] = 2000000L;

        return View();
    }

    [HttpGet("Analyze/{ticker}/{days:int?}")]
    public IActionResult Analyze(string ticker, int? days)
    {
        int finalDays = days ?? 30;

        ViewBag.Ticker = ticker;
        ViewBag.Days = finalDays;

        return View();
    }
}