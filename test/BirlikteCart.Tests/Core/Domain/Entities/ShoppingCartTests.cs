using BirlikteCart.Core.Domain.Entities;

namespace BirlikteCart.Tests.Core.Domain.Entities
{
    [TestFixture]
    public class ShoppingCartTests
    {
        private ShoppingCart _cart;
        private Product _product;

        [SetUp]
        public void Setup()
        {
            _cart = new ShoppingCart(1); 
            _product = new Product (Guid.NewGuid(),"Test Product",  100m ); 
        }

        [Test]
        public void Add_AddsProductToEmptyCart_IncreasesItemCount()
        {
            _cart.AddItem(_product, 1);
            Assert.AreEqual(1, _cart.Items.Count);
            Assert.AreEqual(_product.Price, _cart.TotalPrice);
        }

        [Test]
        public void Add_AddsMultipleProductsToCart_AccumulatesTotalPrice()
        {
            var secondProduct = new Product ( Guid.NewGuid(), "Test Product 2" , 200m );
            _cart.AddItem(_product, 1);
            _cart.AddItem(secondProduct, 2); 
            Assert.AreEqual(3, _cart.Items.Sum(item => item.Quantity));
            Assert.AreEqual(_product.Price + (secondProduct.Price * 2), _cart.TotalPrice);
        }

        [Test]
        public void Add_ExistingProduct_UpdatesQuantity()
        {

            _cart.AddItem(_product, 1); 
            _cart.AddItem(_product, 2); 

            var item = _cart.Items.First(i => i.Product.Id == _product.Id);
            Assert.AreEqual(3, item.Quantity);
        }

        [Test]
        public void Remove_ExistingProduct_DecreasesItemCount()
        {
            _cart.AddItem(_product, 3);
            _cart.RemoveItem(_product);
            Assert.AreEqual(0, _cart.Items.Count);
        }

        [Test]
        public void Remove_NonExistingProduct_ThrowsException()
        {
            var nonExistingProduct = new Product ( Guid.NewGuid(), "Non Exist Product" , 200m );
            var ex = Assert.Throws<ArgumentException>(() => _cart.RemoveItem(nonExistingProduct));
            Assert.That(ex.Message, Is.EqualTo("Çıkarılmak istenen ürün sepette bulunamadı."));
        }

    }
}
