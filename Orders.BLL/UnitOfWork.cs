using Orders.BLL.Repositories;
using Orders.DAL.Repositories.Interfaces;
using Orders.DAL.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Orders.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        IOrderRepository OrderRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IOrderRepository GetOrderRepository
        {
            get
            {
                if (OrderRepository == null)
                    OrderRepository = new OrderRepository(context); 

                return OrderRepository;
            }
        }

        public async Task<bool> SaveChanges()
        {  
            return await context.SaveChangesAsync() == 0 ? false : true;
        }
    }
}
