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
    public class ProductRepository : Repository<Product>, IProductRepository, IRepository<Product>
    {
        public ProductRepository(ApplicationDbContext dbContext):base(dbContext)
        { }

        public async Task<Category> GetCategory(int Id)
        {
            var product = await entities.Where(a => a.ID == Id).Include(a => a.Catergory).SingleOrDefaultAsync();

            return product.Catergory;
        }

        public async Task<Department> GetDepartment(int Id)
        {
            var product = await entities.Where(a => a.ID == Id)
                .Include(a => a.Catergory).ThenInclude(c=>c.Department).SingleOrDefaultAsync();

            return product.Catergory.Department;
        }

        //public override async Task<IEnumerable<Product>> GetAll()
        //{
        //    return await entities.Include(a => a.Catergory).ThenInclude(c => c.Department).ToListAsync();
        //}

        public async Task<int> GetQuantity(int Id)
        {
            var product = await FindById(Id);
            return product.Quantity;
        }

        public async void IncreaseAmount(int Id, int Amount)
        {
            var product = await FindById(Id);

            if (Amount > 0)
            {
                product.Quantity += Amount;
                Update(product);
            }
        }
        public async void DecreaseAmount(int Id, int Amount)
        {
            var product = await FindById(Id);

            if (Amount <= product.Quantity && Amount > 0)
            {
                product.Quantity -= Amount;
                Update(product);
            }
        }
    }
}
