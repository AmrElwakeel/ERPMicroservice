using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Orders.DAL.Entities
{
    public class OrderDetials
    {
        [Key]
        public int ID { get; set; }
        public int Amount { get; set; }
        public double ItemPrice { get; set; }
        public double TotalPrice { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
