using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Domain.Entites
{
    public class Department : AuditableEntity
    {
        public Department()
        {
            this.Catergories = new List<Category>();
        }
        public string Name { get; set; }
        public ICollection<Category> Catergories { get; set; }
    }
}
