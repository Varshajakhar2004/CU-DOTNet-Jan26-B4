using DecentralizedInventoryManagementSystem.Repositories;
using DecentralizedInventoryManagementSystem.Models;
using DecentralizedInventoryManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Controllers
{
    public class LaptopController : Controller
    {
        private readonly ILaptopRepository _repo;

        public LaptopController(ILaptopRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var laptops = await _repo.GetAsync();
            return View(laptops);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Laptop laptop)
        {
            if (!ModelState.IsValid)
                return View(laptop);

            await _repo.CreateAsync(laptop);

            TempData["Success"] = "Laptop saved successfully!";
            return RedirectToAction("Index");
        }
    }
}