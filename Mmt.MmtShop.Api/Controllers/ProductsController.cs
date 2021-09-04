﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IList<Category> GetAllCategories()
        {
            return null;
        }
    }
}
