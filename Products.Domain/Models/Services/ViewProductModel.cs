using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Domain.Models.Services
{
    public class ViewProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Catergory { get; set; }
    }
}
