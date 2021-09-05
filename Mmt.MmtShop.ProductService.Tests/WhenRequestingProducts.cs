using Microsoft.EntityFrameworkCore;
using Mmt.MmtShop.ProductService.Models;
using Mmt.MmtShop.ProductService.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Mmt.MmtShop.ProductService.Tests
{

    public class WhenRequestingProducts
    {

        ProductService productService;

        [SetUp]
        public void Setup()
        {

            var testProducts = new List<Product> {
                new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 1", ProductPrice = 9.99m, ProductSKU = 10000, CategoryId = 1, ProductCategory = new Category { CategoryId=1, CategoryName="Test", IsFeatured=false } },
                new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 2", ProductPrice = 9.99m, ProductSKU = 20000, CategoryId = 2, ProductCategory = new Category { CategoryId=2, CategoryName="Test", IsFeatured=false } },
                new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 3", ProductPrice = 9.99m, ProductSKU = 30000, CategoryId = 3, ProductCategory = new Category { CategoryId=3, CategoryName="Test", IsFeatured=false } },
                new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 4", ProductPrice = 9.99m, ProductSKU = 40000, CategoryId = 4, ProductCategory = new Category { CategoryId=4, CategoryName="Test", IsFeatured=true } },
                new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 5", ProductPrice = 9.99m, ProductSKU = 40000, CategoryId = 4, ProductCategory = new Category { CategoryId=4, CategoryName="Test", IsFeatured=true } },
                new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 6", ProductPrice = 9.99m, ProductSKU = 50000, CategoryId = 5, ProductCategory = new Category { CategoryId=5, CategoryName="Test", IsFeatured=false } },
                new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 7", ProductPrice = 9.99m, ProductSKU = 50000, CategoryId = 5, ProductCategory = new Category { CategoryId=5, CategoryName="Test", IsFeatured=false } },
                new Product { ProductDescription = "This is a test product!", ProductName = "Test Product 8", ProductPrice = 9.99m, ProductSKU = 50000, CategoryId = 5, ProductCategory = new Category { CategoryId=5, CategoryName="Test", IsFeatured=false } }
            }.AsQueryable();

            var mockProductContext = new Mock<ProductContext>();
            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(testProducts.GetEnumerator());
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(testProducts.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(testProducts.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(testProducts.ElementType);

            mockProductContext.Setup(x => x.Products).Returns(mockSet.Object);
            productService = new ProductService(mockProductContext.Object);
        }

        [Test]
        public void ProductsListIsNotNullWhenRequestedViaService()
        {
            var products = productService.GetAllProducts();
            Assert.IsNotNull(products);
        }

        [Test]
        public void ProductsListIsFullWhenRequestedViaService()
        {
            var products = productService.GetAllProducts();
            Assert.AreEqual(8, products.Count);
        }

        [Test]
        public void ProductsListIsNotNullWhenRequestingCategoryViaService()
        {
            var products = productService.GetAllProductsByCategory(1);
            Assert.IsNotNull(products);
        }

        [Test]
        public void ProductsListFiltersByCategoryOneWhenRequestedViaService()
        {
            var products = productService.GetAllProductsByCategory(1);
            Assert.AreEqual(1, products.Count);
        }

        [Test]
        public void ProductsListFiltersByCategoryFiveWhenRequestedViaService()
        {
            var products = productService.GetAllProductsByCategory(5);
            Assert.AreEqual(3, products.Count);
        }

        [Test]
        public void ProductsListFiltersByFeaturedWhenRequestedViaService()
        {
            var products = productService.GetAllFeaturedProducts();
            Assert.AreEqual(2, products.Count);
            Assert.AreEqual(4, products[0].CategoryId);
            Assert.AreEqual(4, products[1].CategoryId);
        }
    }
}