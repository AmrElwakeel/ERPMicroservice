using Products.Application.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork
    {
        public IProductRepository GetProductRepository { get; }
        public IDepartmentRepository GetDepartmentRepository { get; }
        public ICategoryRepository GetCategoryRepository { get; }
        Task<bool> SaveChangesAsync();
        bool SaveChanges();
    }
}
