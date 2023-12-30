using BirlikteCart.Core.Domain.Entities;

namespace BirlikteCart.Tests.Core.Domain.Entities
{
    [TestFixture]
    public class ShoppingCartItemTests
    {
        private Product _testProduct;

        [SetUp]
        public void SetUp()
        {
            _testProduct = new Product(Guid.NewGuid(), "Test Product", 10.00m);
        }

        [Test]
        public void Constructor_WithValidArguments_InitializesPropertiesCorrectly()
        {
            int quantity = 5;
            ShoppingCartItem item = new ShoppingCartItem(_testProduct, quantity);
            Assert.AreEqual(_testProduct, item.Product);
            Assert.AreEqual(quantity, item.Quantity);
        }

        [Test]
        public void Quantity_PropertyChanged_UpdatesValueCorrectly()
        {
            ShoppingCartItem item = new ShoppingCartItem(_testProduct, 1);
            int updatedQuantity = 3;
            item.Quantity = updatedQuantity;
            Assert.AreEqual(updatedQuantity, item.Quantity);
        }
    }
}
