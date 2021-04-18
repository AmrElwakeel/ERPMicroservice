using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Domain.Models.Services
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; } 
        public double Price { get; set; }
        public int CatergoryId { get; set; }
    }
}
