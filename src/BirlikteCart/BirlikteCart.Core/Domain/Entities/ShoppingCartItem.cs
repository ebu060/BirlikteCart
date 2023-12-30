namespace BirlikteCart.Core.Domain.Entities
{
    public class ShoppingCartItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; set; }

        public ShoppingCartItem(Product product,int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
