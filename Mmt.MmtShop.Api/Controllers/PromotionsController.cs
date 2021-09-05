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
    public class PromotionsController : ControllerBase
    {
        private readonly ILogger<PromotionsController> _logger;
        private readonly IProductService _productService;

        public PromotionsController(ILogger<PromotionsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public IList<Product> GetFeaturedProducts()
        {
            return _productService.GetAllFeaturedProducts();
        }
    }
}
