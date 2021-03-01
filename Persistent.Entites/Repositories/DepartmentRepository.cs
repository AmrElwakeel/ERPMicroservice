using Microsoft.EntityFrameworkCore;
using Persistence.Entites;
using Persistence.Entites.Repositories;
using Products.Application.Interfaces.IRepositories;
using Products.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Persistence.Entites.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository, IRepository<Department>
    {
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public async Task<IEnumerable<Department>> GetFullData()
        {
            return await this.entities.Where(a => a.IsActive == true && a.IsDeleted == false)
                .Include(a => a.Catergories).ToListAsync();
        }
    }
}
