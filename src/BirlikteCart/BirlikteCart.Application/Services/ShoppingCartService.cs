using BirlikteCart.Core.Domain.Entities;
using BirlikteCart.Core.Domain.Interfaces;
using BirlikteCart.Core.Domain.Services;

namespace BirlikteCart.Application.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        /// <summary>
        /// Sepete ürün ekle
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <returns>ShoppingCart</returns>
        /// <exception cref="NotImplementedException"></exception>
        public ShoppingCart AddItemToCart(long userId, Product product, int quantity)
        {
            var shoppingCart = _shoppingCartRepository.GetByUserId(userId);
            shoppingCart.AddItem(product, quantity);
            _shoppingCartRepository.SaveByUserId(shoppingCart);
            return shoppingCart;
        }

        /// <summary>
        /// Sepet Oluştur
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>ShoppingCart</returns>
        public ShoppingCart CreateCard(long userId)
        {
            var shoppingCart = new ShoppingCart(userId);
            var a = _shoppingCartRepository.SaveByUserId(shoppingCart);
            return a;
        }

        /// <summary>
        /// Sepeti sil
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteCartByUserId(long userId)
        {
            _shoppingCartRepository.DeleteByUserId(userId);
        }

        /// <summary>
        /// Sepeti Getir
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>shoppingCart</returns>
        public ShoppingCart GetCartByUserId(long userId)
        {
            return _shoppingCartRepository.GetByUserId(userId);
        }

        /// <summary>
        /// Sepetten ürün sil
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="product"></param>
        /// <returns>shoppingCart</returns>
        public ShoppingCart RemoveItemFromCart(long userId, Product product)
        {
            var shoppingCart = _shoppingCartRepository.GetByUserId(userId);
            shoppingCart.RemoveItem(product);
            return _shoppingCartRepository.SaveByUserId(shoppingCart);
        }
    }
}
