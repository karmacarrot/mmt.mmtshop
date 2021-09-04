using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmt.MmtShop.ProductService.Models
{
    public class Product
    {
        public int ProductSKU { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
