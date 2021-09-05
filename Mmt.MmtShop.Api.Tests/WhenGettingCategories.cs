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

        CategoriesController categoriesController;

        [SetUp]
        public void Setup()
        {
            IList<Category> mockCategories = new List<Category>();
            mockCategories.Add(new Category { CategoryId = 1, CategoryName = "Home", IsFeatured = false });
            mockCategories.Add(new Category { CategoryId = 2, CategoryName = "Garden", IsFeatured = false });
            mockCategories.Add(new Category { CategoryId = 3, CategoryName = "Electronics", IsFeatured = true });
            mockCategories.Add(new Category { CategoryId = 4, CategoryName = "Fitness", IsFeatured = false });
            mockCategories.Add(new Category { CategoryId = 5, CategoryName = "Toys", IsFeatured = false });

            var mockLogger = new Mock<ILogger<CategoriesController>>().Object;
            var mockProductService = Mock.Of<IProductService>(c => c.GetAllCategories() == mockCategories);
            categoriesController = new CategoriesController(mockLogger, mockProductService);
        }

        [Test]
        public void CategoriesListIsNotNull()
        {
            var categoryList = categoriesController.GetAllCategories();
            Assert.IsNotNull(categoryList);
        }

        [Test]
        public void AllCategoriesAreReturned()
        {
            var categoryList = categoriesController.GetAllCategories();
            Assert.AreEqual(5, categoryList.Count);
        }
    }
}