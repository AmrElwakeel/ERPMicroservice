using Microsoft.EntityFrameworkCore;
using Orders.DAL.Entities;
using Orders.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.BLL.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository,IRepository<Order>
    {
        public OrderRepository(ApplicationDbContext dbContext):base(dbContext)
        { }

        public override async Task<IEnumerable<Order>> GetAll()
        {
            return await entities.Include(o => o.OrderDetials).ToListAsync();
        }

        public override Task<Order> FindById(int id)
        {
            return entities.Where(a=>a.ID==id).Include(o => o.OrderDetials).FirstOrDefaultAsync();
        }
    }
}
