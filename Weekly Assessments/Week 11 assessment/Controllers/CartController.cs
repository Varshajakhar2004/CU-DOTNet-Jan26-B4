using Microsoft.AspNetCore.Mvc;
using TheCentralizedPricingEngine.Models;

public class CartController : Controller
{
    private readonly CartService _cartService;
    private readonly IPricingService _pricingService;

    public CartController(CartService cartService, IPricingService pricingService)
    {
        _cartService = cartService;
        _pricingService = pricingService;
    }

    public IActionResult Index()
    {
        ViewBag.Total = _cartService.GetTotal();
        return View(_cartService.GetCart());
    }

    [HttpPost]
    public IActionResult ApplyPromo(string promoCode)
    {
        var total = _cartService.GetTotal();

        var result = _pricingService.CalculatePrice(total, promoCode);

        ViewBag.Pricing = result;
        ViewBag.Total = total;

        return View("Index", _cartService.GetCart());
    }
}