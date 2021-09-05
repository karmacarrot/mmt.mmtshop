using System;
using System.ComponentModel.DataAnnotations;

namespace Mmt.MmtShop.ProductService.Models
{
    public class Category
    {
        [Key]
        public Int32 CategoryId { get; set; }

        public string CategoryName { get; set; }
        public bool IsFeatured { get; set; }
    }
}
