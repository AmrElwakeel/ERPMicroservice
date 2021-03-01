using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Products.Domain.Entites
{
    public class Category : AuditableEntity
    {
        public Category()
        {
            this.Products = new List<Product>();
        }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
