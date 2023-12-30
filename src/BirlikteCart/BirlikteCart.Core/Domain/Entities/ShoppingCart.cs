namespace BirlikteCart.Core.Domain.Entities
{
    public class ShoppingCart
    {
        public Guid Id { get; private set; }
        public long UserId { get; private set; }
        public List<ShoppingCartItem> Items { get; private set; }
        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += (item.Product.Price * item.Quantity);
                }
                return totalPrice;
            }
        }

        public ShoppingCart(long userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Items = new List<ShoppingCartItem>();
        }

        /// <summary>
        /// Ürün zaten sepette varsa miktarını güncelle , yoksa ürünü ekle
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public void AddItem(Product product,int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
            {
                if (quantity > 0)
                    existingItem.Quantity += quantity;
                else
                {
                    if ((existingItem.Quantity += quantity) < 0)
                        Items.Remove(existingItem);
                    else
                        existingItem.Quantity += quantity;
                }
            }
            else           
                Items.Add(new ShoppingCartItem(product, quantity));
            
        }

        /// <summary>
        /// Ürünü sepetten çıkar
        /// </summary>
        /// <param name="product"></param>
        public void RemoveItem(Product product)
        {
            var existingItem = Items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
                Items.Remove(existingItem);        
            else           
                throw new ArgumentException("Çıkarılmak istenen ürün sepette bulunamadı.");           
        }
    }
}