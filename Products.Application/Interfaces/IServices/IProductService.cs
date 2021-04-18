using Products.Application.Interfaces.IServiceResponse;
using Products.Domain.Entites;
using Products.Domain.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Interfaces.IServices
{
    public interface IProductService
    {
        Task<IResponse> AddProduct(CreateProductModel model);
        Task<IResponse> GetDepartment(int Id);
        Task<IResponse> GetCategory(int Id);
        Task<IResponse> GetQuantity(int Id);
        IResponse IncreaseAmount(int Id, int Amount);
        IResponse DecreaseAmount(int Id, int Amount);
    }
}
