using Mmt.MmtShop.Api.Controllers;
using Moq;
using NUnit.Framework;
using Microsoft.Extensions.Logging;
using Mmt.MmtShop.ProductService;
using Mmt.MmtShop.ProductService.Models;
using System.Collections.Generic;
using System;

namespace Mmt.MmtShop.Api.Tests
{
    public class WhenGettingFeaturedProducts
    {

        PromotionsController promotionsController;

        [SetUp]
        public void Setup()
        {
            IList<Product> mockProducts = new List<Product>();
            mockProducts.Add(new Product {  ProductDescription="This is a test product!", ProductName="Test Product 1", ProductPrice=9.99m, ProductSKU=10000, CategoryId=1  });
            mockProducts.Add(new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 2", ProductPrice = 9.99m, ProductSKU = 20000, CategoryId = 2 });
            mockProducts.Add(new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 3", ProductPrice = 9.99m, ProductSKU = 30000, CategoryId = 3 });
            mockProducts.Add(new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 4", ProductPrice = 9.99m, ProductSKU = 40000, CategoryId = 4 });
            mockProducts.Add(new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 5", ProductPrice = 9.99m, ProductSKU = 40000, CategoryId = 4 });
            mockProducts.Add(new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 6", ProductPrice = 9.99m, ProductSKU = 50000, CategoryId = 5 });
            mockProducts.Add(new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 7", ProductPrice = 9.99m, ProductSKU = 50000, CategoryId = 5 });
            mockProducts.Add(new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 8", ProductPrice = 9.99m, ProductSKU = 50000, CategoryId = 5 });

            var mockLogger = new Mock<ILogger<PromotionsController>>().Object;
            var mockProductService = Mock.Of<IProductService>(c => c.GetAllProducts() == mockProducts && c.GetAllFeaturedProducts() == mockProducts);

            promotionsController = new PromotionsController(mockLogger, mockProductService);
        }

        [Test]
        public void FeaturedProductsListIsNotNull()
        {
            var productList = promotionsController.GetFeaturedProducts();
            Assert.IsNotNull(productList);
        }

        [Test]
        public void AllFeaturedProductsAreReturned()
        {
            var productList = promotionsController.GetFeaturedProducts();
            Assert.AreEqual(8, productList.Count);
        }
    }
}