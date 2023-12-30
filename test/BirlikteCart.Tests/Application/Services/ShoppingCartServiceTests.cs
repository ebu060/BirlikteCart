using BirlikteCart.Application.Services;
using BirlikteCart.Core.Domain.Entities;
using BirlikteCart.Core.Domain.Interfaces;
using Moq;
using NUnit.Framework.Internal;

namespace BirlikteCart.Tests.Application.Services
{
    [TestFixture]
    public class ShoppingCartServiceTests
    {
        private Mock<IShoppingCartRepository> _mockRepository;
        private ShoppingCartService _service;
        private long _userId; // Example UserId

        [SetUp]
        public void Setup()
        {
            _userId = 23143135453761;
            _mockRepository = new Mock<IShoppingCartRepository>();
            _service = new ShoppingCartService(_mockRepository.Object);           
        }

        [Test]
        public void CreateCart_WhenCalled_ShouldCreateNewCart()
        {
            var shoppingCart = new ShoppingCart(_userId);
            _mockRepository.Setup(x => x.SaveByUserId(It.IsAny<ShoppingCart>())).Returns(shoppingCart);
            var result = _service.CreateCard(_userId);
            Assert.That(result.UserId, Is.EqualTo(_userId));
        }


        [Test]
        public void AddItemToCart_WhenCalled_AddsItemAndSavesCart()
        {
   
            var shoppingCart = new ShoppingCart(_userId);
            var product = new Product(Guid.NewGuid(), "Test Product", 10.5m);
            var quantity = 1;

            _mockRepository.Setup(repo => repo.GetByUserId(_userId)).Returns(shoppingCart);
            _service.AddItemToCart(_userId, product, quantity);
            _mockRepository.Verify(repo => repo.GetByUserId(_userId), Times.Once);
            _mockRepository.Verify(repo => repo.SaveByUserId(It.Is<ShoppingCart>(cart => cart.Items.Count > 0)), Times.Once);
        }

        [Test]
        public void DeleteCartByUserId_WhenCalled_InvokesRepository()
        {
            _service.DeleteCartByUserId(_userId);
            _mockRepository.Verify(repo => repo.DeleteByUserId(_userId), Times.Once);
        }


        [Test]
        public void GetCardByUserId_WhenCalled_InvokesRepository()
        {
            var expectedCart = new ShoppingCart(_userId);
            _mockRepository.Setup(repo => repo.GetByUserId(_userId)).Returns(expectedCart);


            var result = _service.GetCartByUserId(_userId);

            _mockRepository.Verify(repo => repo.GetByUserId(_userId), Times.Once);
            Assert.AreEqual(expectedCart, result);
        }
    }
}
