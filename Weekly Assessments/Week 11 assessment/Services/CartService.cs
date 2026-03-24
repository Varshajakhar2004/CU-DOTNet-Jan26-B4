using TheCentralizedPricingEngine.Models;

public class CartService
{
    private List<CartItem> _items = new List<CartItem>();

    public List<CartItem> GetCart()
    {
        return _items;
    }

    public void AddToCart(Product product)
    {
        var existing = _items.FirstOrDefault(x => x.Product.Id == product.Id);

        if (existing != null)
            existing.Quantity++;
        else
            _items.Add(new CartItem { Product = product, Quantity = 1 });
    }

    public decimal GetTotal()
    {
        return _items.Sum(x => x.Product.Price * x.Quantity);
    }
}