using BirlikteCart.Core.Domain.Entities;
using BirlikteCart.Core.Domain.Interfaces;

namespace BirlikteCart.Infrastructure.Data
{
    public class InMemoryShoppingCartRepository : IShoppingCartRepository
    {
        private static readonly Dictionary<Int64, ShoppingCart> _carts = new();

        /// <summary>
        /// Sepeti User ID'sine göre silmek için metod 
        /// </summary>
        /// <param name="userId"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void DeleteByUserId(long userId)
        {
            if (!_carts.Remove(userId))
            {
                throw new KeyNotFoundException("Silinecek sepet bulunamadı.");
            }
        }

        /// <summary>
        /// Sepeti UserId'sine göre almak için metod
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>ShoppingCart</returns>
        /// <exception cref="NotImplementedException"></exception>
        public ShoppingCart GetByUserId(long userId)
        {
            if (_carts.TryGetValue(userId, out var cart))
            {
                return cart;
            }
            else
            {
                throw new KeyNotFoundException("Sepet bulunamadı.");
            }
        }

        /// <summary>
        /// Sepeti kaydetmek veya güncellemek için metod
        /// </summary>
        /// <param name="cart"></param>
        /// <returns>ShoppingCart</returns>
        /// <exception cref="NotImplementedException"></exception>
        public ShoppingCart SaveByUserId(ShoppingCart cart)
        {
            _carts[cart.UserId] = cart;
            return cart;
        }
    }
}
