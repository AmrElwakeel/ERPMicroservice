using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Persistence.Entites.Broker.Models
{
    public class OrderProductMsgModel
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public bool AddedOrder { get; set; }
    }
}
