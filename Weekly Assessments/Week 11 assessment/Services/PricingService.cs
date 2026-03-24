namespace TheCentralizedPricingEngine.Services
{
    using TheCentralizedPricingEngine.Models;

    public class PricingService : IPricingService
    {
        public ProductPrice CalculatePrice(decimal basePrice, string promoCode)
        {
            decimal discount = 0;

            if (!string.IsNullOrEmpty(promoCode))
            {
                promoCode = promoCode.ToUpper();

                if (promoCode == "WINTER25")
                    discount = basePrice * 0.15m;

                else if (promoCode == "FREESHIP")
                    discount = 5;
            }

            decimal finalPrice = basePrice - discount;

            return new ProductPrice
            {
                OriginalPrice = basePrice,
                DiscountAmount = discount,
                FinalPrice = finalPrice < 0 ? 0 : finalPrice,
                AppliedCode = promoCode
            };
        }
    }
}
