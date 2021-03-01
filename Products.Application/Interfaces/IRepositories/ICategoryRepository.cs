using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Products.Domain.Entites;

namespace Products.Application.Interfaces.IRepositories
{
    public interface ICategoryRepository: IRepository<Category>
    {
        Task<IEnumerable<Category>> GetFullData();
    }
}
