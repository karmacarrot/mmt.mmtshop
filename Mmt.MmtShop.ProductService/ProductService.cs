using Mmt.MmtShop.ProductService.Models;
using Mmt.MmtShop.ProductService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmt.MmtShop.ProductService
{
    public class ProductService : IProductService
    {
        ProductContext _productContext;
        
        public ProductService(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public IList<Category> GetAllCategories() 
        {
            return _productContext.Categories.ToList();
        }

        public IList<Product> GetAllProducts()
        {
            return _productContext.Products.ToList();
        }

        public IList<Product> GetAllProductsByCategory(Int32 categoryId)
        {
            return _productContext.Products.Where<Product>(x => x.CategoryId == categoryId).ToList();
        }

        public IList<Product> GetAllFeaturedProducts()
        {
            return _productContext.Products.Where<Product>(x => x.ProductCategory.IsFeatured).ToList();
        }
    }
}
