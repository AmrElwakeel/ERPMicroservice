using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Application.Models.ProductModels
{
    public class ProductCreateModel
    {
        public string Name { get; set; }
        public int Quantety { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
