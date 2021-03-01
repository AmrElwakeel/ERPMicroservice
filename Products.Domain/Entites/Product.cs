using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Domain.Entites
{
    public class Product : AuditableEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int CatergoryId { get; set; }
        [ForeignKey("CatergoryId")]
        public Category Catergory { get; set; }
    }
}
