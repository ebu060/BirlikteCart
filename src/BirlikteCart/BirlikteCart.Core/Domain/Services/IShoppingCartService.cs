using BirlikteCart.Core.Domain.Entities;

namespace BirlikteCart.Core.Domain.Services
{
    public interface IShoppingCartService
    {
        ShoppingCart GetCartByUserId(long userId);
        ShoppingCart CreateCard(long userId);
        void DeleteCartByUserId(long userId);
        ShoppingCart AddItemToCart(long userId, Product product ,int quantity);
        ShoppingCart RemoveItemFromCart(long userId,Product product);

    }
}
