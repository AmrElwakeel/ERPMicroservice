using Persistence.Entites.Repositories;
using Products.Application.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using Products.Domain.Entites;
using System.Threading.Tasks;
using Persistence.Entites;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Products.Persistence.Entites.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository, IRepository<Category>
    { 
        public CategoryRepository(ApplicationDbContext dbContext):base(dbContext)
        {  }
        public async Task<IEnumerable<Category>> GetFullData()
        {
            return await this.entities.Where(a => a.IsActive == true && a.IsDeleted == false)
                .Include(a => a.Products).ToListAsync();
        }
    }
}
