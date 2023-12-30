using BirlikteCart.Core.Domain.Entities;

namespace BirlikteCart.Tests.Core.Domain.Entities
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Product_Should_Construct_With_Expected_Values()
        {
            Guid expectedId = Guid.NewGuid();
            string expectedName = "Test Product";
            decimal expectedPrice = 9.99m;


            Product product = new Product(expectedId, expectedName, expectedPrice);


            Assert.AreEqual(expectedId, product.Id);
            Assert.AreEqual(expectedName, product.Name);
            Assert.AreEqual(expectedPrice, product.Price);
        }
    }
}
