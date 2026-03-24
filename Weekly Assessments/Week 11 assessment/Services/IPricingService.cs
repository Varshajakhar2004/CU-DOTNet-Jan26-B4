using TheCentralizedPricingEngine.Models;

public interface IPricingService
{
    ProductPrice CalculatePrice(decimal basePrice, string promoCode);
}
