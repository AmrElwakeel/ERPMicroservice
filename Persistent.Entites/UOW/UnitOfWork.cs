using Persistence.Entites;
using Products.Application.Interfaces.IRepositories;
using Products.Application.Interfaces.IUnitOfWork;
using Products.Persistence.Entites.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Persistence.Entites.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        ICategoryRepository categoryRepository;
        IDepartmentRepository departmentRepository; 
        IProductRepository productRepository;


        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IProductRepository GetProductRepository
        {
            get
            {
                if(productRepository==null)
                    productRepository = new ProductRepository(context);

                return productRepository;
            }
        }

        public IDepartmentRepository GetDepartmentRepository
        {
            get
            {
                if (departmentRepository == null)
                    departmentRepository = new DepartmentRepository(context);

                return departmentRepository;
            }
        }

        public ICategoryRepository GetCategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(context);

                return categoryRepository;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() == 1 ? true : false;
        }
        public bool SaveChanges()
        {
            return context.SaveChanges() == 1 ? true : false;
        }
    }
}
