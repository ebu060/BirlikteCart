using BirlikteCart.Core.Domain.Entities;
using BirlikteCart.Infrastructure.Data;

namespace BirlikteCart.Tests.Infrastructure.Data
{
    [TestFixture]
    public class InMemoryShoppingCartRepositoryTests
    {
        private InMemoryShoppingCartRepository _repository;
        private ShoppingCart _shoppingCart;
        private long _userId;

        [SetUp]
        public void SetUp()
        {
            _repository = new InMemoryShoppingCartRepository();
            _userId = 796103156434234; // Example UserId
            _shoppingCart = new ShoppingCart(_userId);
            
        }

        [Test]
        public void GetByUserId_WithExistingUserId_ReturnsShoppingCart()
        {
            _repository.SaveByUserId(_shoppingCart);
            var result = _repository.GetByUserId(_userId);
            Assert.AreEqual(_shoppingCart, result);
        }

        [Test]
        public void GetByUserId_WithNonExistingUserId_ThrowsKeyNotFoundException()
        {
            long nonExistingUserId = 1234563453786;
            var ex = Assert.Throws<KeyNotFoundException>(() => _repository.GetByUserId(nonExistingUserId));
            Assert.That(ex.Message, Is.EqualTo("Sepet bulunamadı."));
        }

        [Test]
        public void SaveByUserId_WithNewShoppingCart_AddsShoppingCart()
        {
            _repository.SaveByUserId(_shoppingCart);
            var retrievedCart = _repository.GetByUserId(_userId);
            Assert.AreEqual(_shoppingCart, retrievedCart);
        }

        [Test]
        public void SaveByUserId_WithExistingShoppingCart_UpdatesShoppingCart()
        {
            _repository.SaveByUserId(_shoppingCart);
            var updatedCart = new ShoppingCart(_userId);
            updatedCart.AddItem(new Product(Guid.NewGuid(), "Updated Product", 20.00m), 1);
            _repository.SaveByUserId(updatedCart);
            var retrievedCart = _repository.GetByUserId(_userId);
            Assert.AreEqual(updatedCart, retrievedCart);
        }

        [Test]
        public void DeleteByUserId_WithExistingUserId_RemovesShoppingCart()
        {
            _repository.SaveByUserId(_shoppingCart);
            _repository.DeleteByUserId(_userId);
            var ex = Assert.Throws<KeyNotFoundException>(() => _repository.GetByUserId(_userId));
            Assert.That(ex.Message, Is.EqualTo("Sepet bulunamadı."));
        }

        [Test]
        public void DeleteByUserId_WithNonExistingUserId_ThrowsKeyNotFoundException()
        {
            long nonExistingUserId = 45646767642312;
            var ex = Assert.Throws<KeyNotFoundException>(() => _repository.DeleteByUserId(nonExistingUserId));
            Assert.That(ex.Message, Is.EqualTo("Silinecek sepet bulunamadı."));
        }
    }
}
