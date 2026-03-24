using Microsoft.AspNetCore.Mvc;
using TheCentralizedPricingEngine.Models;

public class ProductController : Controller
{
    private readonly CartService _cartService;

    public ProductController(CartService cartService)
    {
        _cartService = cartService;
    }
    

    public IActionResult Index()
    {
        var product = new List<Product>
        {
            new Product { Id = 1, Name = "Watch", Price = 100 },
            new Product { Id = 2, Name = "Shoes", Price = 200 },
            new Product { Id = 3, Name = "Bag", Price = 150 }
        };

        return View(product);
    }

    public IActionResult AddToCart(int id)
    {
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Watch", Price = 100 },
            new Product { Id = 2, Name = "Shoes", Price = 200 },
            new Product { Id = 3, Name = "Bag", Price = 150 }
        };

        var product = products.FirstOrDefault(p => p.Id == id);

        if (product != null)
            _cartService.AddToCart(product);

        return RedirectToAction("Index", "Cart");
    }
}