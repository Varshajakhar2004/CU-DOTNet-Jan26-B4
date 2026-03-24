namespace TheCentralizedPricingEngine.Models
{
    public class ProductPrice
    {
        public decimal OriginalPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalPrice { get; set; }
        public string AppliedCode { get; set; }
    }
}
