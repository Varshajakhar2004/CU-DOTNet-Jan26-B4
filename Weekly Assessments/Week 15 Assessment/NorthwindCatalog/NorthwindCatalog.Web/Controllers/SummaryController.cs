using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using NorthwindCatalog.Services.DTOs; 
public class SummaryController : Controller
{
    private readonly HttpClient _client;

    public SummaryController(IHttpClientFactory factory)
    {
        _client = factory.CreateClient("api");
    }

    public async Task<IActionResult> Index()
    {
        var data = await _client.GetFromJsonAsync<List<CategorySummaryDto>>
            ("api/summary");

        return View(data);
    }
}