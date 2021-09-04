using Mmt.MmtShop.Api.Controllers;
using Moq;
using NUnit.Framework;
using Microsoft.Extensions.Logging;

namespace Mmt.MmtShop.Api.Tests
{
    public class WhenGettingCategories
    {

        ProductsController productsController;

        [SetUp]
        public void Setup()
        {
            var mockLogger = new Mock<ILogger<ProductsController>>().Object;
            productsController = new ProductsController(mockLogger);
        }

        [Test]
        public void CategoriesListIsNotNull()
        {
            var categoryList = productsController.GetAllCategories();
            Assert.IsNotNull(categoryList);
        }

        [Test]
        public void AtLeastOneCategoryIsReturned()
        {
            var categoryList = productsController.GetAllCategories();
            Assert.IsTrue(categoryList.Count > 0);
        }
    }
}