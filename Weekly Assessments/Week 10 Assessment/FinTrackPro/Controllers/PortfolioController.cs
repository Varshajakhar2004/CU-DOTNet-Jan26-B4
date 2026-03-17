using Microsoft.AspNetCore.Mvc;
using FinTrackPro.Models;
using System.Linq;

public class PortfolioController : Controller
{
    private static List<Asset> assets = new List<Asset>()
    {
        new Asset { Id = 1, Name = "TCS", Value = 3000 },
        new Asset { Id = 2, Name = "Infosys", Value = 2500 }
    };

    // INDEX
    public IActionResult Index()
    {
        double total = assets.Sum(a => a.Value);
        ViewData["Total"] = total;

        return View(assets);
    }

    // ATTRIBUTE ROUTING
    [Route("Asset/Info/{id:int}")]
    public IActionResult Details(int id)
    {
        var asset = assets.FirstOrDefault(a => a.Id == id);

        if (asset == null)
        {
            return NotFound(); // ✅ safe handling
        }

        return View(asset);
    }

    // DELETE
    public IActionResult Delete(int id)
    {
        var asset = assets.FirstOrDefault(a => a.Id == id);

        if (asset != null)
        {
            assets.Remove(asset);
            TempData["Message"] = "Asset deleted!";
        }
        else
        {
            TempData["Message"] = "Asset not found!";
        }

        return RedirectToAction("Index");
    }
}