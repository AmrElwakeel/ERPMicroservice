using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Application.Models.ProductModels
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantety { get; set; }
        public decimal Price { get; set; }
        public string Catergory { get; set; }
        public string Department { get; set; }

    }
}
