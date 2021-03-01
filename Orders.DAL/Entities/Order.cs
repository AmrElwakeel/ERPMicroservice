using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.DAL.Entities
{
    public class Order: AuditableEntity
    {
        public Order()
        {
            this.OrderDetials = new List<OrderDetials>();
        }

        public double TotalPrice { get; set; }
        public ICollection<OrderDetials> OrderDetials { get; set; }
    }
}
