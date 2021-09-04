using Mmt.MmtShop.Api.Controllers;
using Moq;
using NUnit.Framework;
using Microsoft.Extensions.Logging;
using Mmt.MmtShop.ProductService;
using Mmt.MmtShop.ProductService.Models;
using System.Collections.Generic;

namespace Mmt.MmtShop.Api.Tests
{
    public class WhenGettingCategories
    {

        ProductsController productsController;

        [SetUp]
        public void Setup()
        {
            IList<Category> mockCategories = new List<Category>();
            mockCategories.Add(new Category { CategoryId = 1, CategoryName = "Home" });
            mockCategories.Add(new Category { CategoryId = 2, CategoryName = "Garden" });
            mockCategories.Add(new Category { CategoryId = 3, CategoryName = "Electronics" });
            mockCategories.Add(new Category { CategoryId = 4, CategoryName = "Fitness" });
            mockCategories.Add(new Category { CategoryId = 5, CategoryName = "Toys" });

            var mockLogger = new Mock<ILogger<ProductsController>>().Object;
            var mockProductService = Mock.Of<IProductService>(c => c.GetAllCategories() == mockCategories);
            productsController = new ProductsController(mockLogger, mockProductService);
        }

        [Test]
        public void CategoriesListIsNotNull()
        {
            var categoryList = productsController.GetAllCategories();
            Assert.IsNotNull(categoryList);
        }

        [Test]
        public void AllCategoriesAreReturned()
        {
            var categoryList = productsController.GetAllCategories();
            Assert.AreEqual(5, categoryList.Count);
        }
    }
}