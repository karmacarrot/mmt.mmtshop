using Mmt.MmtShop.Api.Controllers;
using Moq;
using NUnit.Framework;
using Microsoft.Extensions.Logging;
using Mmt.MmtShop.ProductService;
using Mmt.MmtShop.ProductService.Models;
using System.Collections.Generic;

namespace Mmt.MmtShop.Api.Tests
{
    public class WhenGettingProducts
    {

        ProductsController productsController;

        [SetUp]
        public void Setup()
        {
            IList<Product> mockProducts = new List<Product>();
            mockProducts.Add(new Product {  ProductDescription="This is a test product!", ProductName="Test Product 1", ProductPrice=9.99m, ProductSKU=10000  });
            mockProducts.Add(new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 2", ProductPrice = 9.99m, ProductSKU = 20000 });
            mockProducts.Add(new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 3", ProductPrice = 9.99m, ProductSKU = 30000 });
            mockProducts.Add(new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 4", ProductPrice = 9.99m, ProductSKU = 40000 });
            mockProducts.Add(new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 5", ProductPrice = 9.99m, ProductSKU = 40000 });
            mockProducts.Add(new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 6", ProductPrice = 9.99m, ProductSKU = 50000 });
            mockProducts.Add(new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 7", ProductPrice = 9.99m, ProductSKU = 50000 });
            mockProducts.Add(new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 8", ProductPrice = 9.99m, ProductSKU = 50000 });

            var mockLogger = new Mock<ILogger<ProductsController>>().Object;
            var mockProductService = Mock.Of<IProductService>(c => c.GetAllProducts() == mockProducts);
            productsController = new ProductsController(mockLogger, mockProductService);
        }

        [Test]
        public void ProductsListIsNotNull()
        {
            var productList = productsController.GetAllProducts();
            Assert.IsNotNull(productList);
        }

        [Test]
        public void AllProductsAreReturnedWhenRequested()
        {
            var productList = productsController.GetAllProducts();
            Assert.AreEqual(8, productList.Count);
        }
    }
}