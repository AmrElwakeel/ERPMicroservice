using Orders.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Orders.DAL.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        public IOrderRepository GetOrderRepository { get; }
        Task<bool> SaveChanges();
    }
}
