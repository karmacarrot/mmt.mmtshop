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
    }
}
