using BirlikteCart.Core.Domain.Entities;

namespace BirlikteCart.Core.Domain.Interfaces
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetByUserId(Int64 userId);
        ShoppingCart SaveByUserId(ShoppingCart cart);
        void DeleteByUserId(Int64 userId);

    }
}