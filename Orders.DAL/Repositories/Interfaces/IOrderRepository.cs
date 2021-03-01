using Orders.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Orders.DAL.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
}
