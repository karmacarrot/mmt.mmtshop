using Mmt.MmtShop.ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmt.MmtShop.ProductService
{
    public interface IProductService
    {
        IList<Category> GetAllCategories();
        IList<Product> GetAllProducts();
        IList<Product> GetAllProductsByCategory(Int16 categoryId);
    }
}
