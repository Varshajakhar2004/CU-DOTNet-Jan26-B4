using FrontendMVCIntegration.Models;
using FrontendMVCIntegration.Services;
using Microsoft.AspNetCore.Mvc;

public class TravelController : Controller
{
    private readonly IDestinationService _service;

    public TravelController(IDestinationService service)
    {
        _service = service;
    }

    // GET: Show all
    public async Task<IActionResult> Index()
    {
        var data = await _service.GetAllAsync();
        return View(data);
    }

    // GET: Create Page
    public IActionResult Create()
    {
        return View();
    }

    // POST: Create Destination
    [HttpPost]
    public async Task<IActionResult> Create(Destination d)
    {
        d.Id = 0; 
        await _service.AddAsync(d);
        return RedirectToAction("Index");
    }

    // GET: Top Rated
    public async Task<IActionResult> TopRated()
    {
        var data = await _service.GetAllAsync();

        var top = data.Where(d => d.Rating >= 4);

        return View(top);
    }

    public async Task<IActionResult> Recent()
    {
        var data = await _service.GetAllAsync();

        var recent = data
            .OrderByDescending(d => d.LastVisited)
            .Take(5);

        return View(recent);
    }
}