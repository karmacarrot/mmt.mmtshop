using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mmt.MmtShop.ProductService;
using Mmt.MmtShop.ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmt.MmtShop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public IList<Product> GetProducts(Int32? categoryId = null)
        {
            if (categoryId is null || categoryId == 0)
            {
                return _productService.GetAllProducts();
            }
            return _productService.GetAllProductsByCategory((Int32)categoryId);
        }
    }
}
