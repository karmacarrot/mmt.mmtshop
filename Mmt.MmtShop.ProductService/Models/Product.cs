using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmt.MmtShop.ProductService.Models
{
    public class Product
    {
        [Key]
        public int ProductSKU { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public Int16 ProductCategoryId { get; set; }
    }
}
