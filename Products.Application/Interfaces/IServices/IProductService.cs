using Products.Application.Interfaces.IServiceResponse;
using Products.Domain.Entites;
using Products.Domain.Models.PaginationRequest;
using Products.Domain.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Interfaces.IServices
{
    public interface IProductService
    {
        Task<IResponse> Create(CreateProductModel model);
        Task<IPagingResponse> Get(PaginationReqModel paginationReq);
        Task<IResponse> Get(int id);
        Task<IResponse> GetDepartment(int Id);
        Task<IResponse> GetCategory(int Id);
        Task<IResponse> GetQuantity(int Id);
    }
}
