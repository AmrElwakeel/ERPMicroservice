using Products.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Interfaces.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    { 
        Task<Department> GetDepartment(int Id);
        Task<Category> GetCategory(int Id);
        Task<int> GetQuantity(int Id);
        void IncreaseAmount(int Id, int Amount);
        void DecreaseAmount(int Id,int Amount);
    }
}
