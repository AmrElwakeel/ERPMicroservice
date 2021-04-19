using AutoMapper;
using Products.Application.Interfaces.IServiceResponse;
using Products.Application.Interfaces.IServices;
using Products.Application.Interfaces.IUnitOfWork;
using Products.Domain.Entites;
using Products.Domain.Models.PaginationRequest;
using Products.Domain.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Persistence.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork uOW;
        private readonly IMapper mapper;
        private readonly IResponse response;

        public ProductService(IUnitOfWork UOW, IMapper mapper,IResponse response)
        {
            uOW = UOW;
            this.mapper = mapper;
            this.response = response;
        }

        public async Task<IResponse> Create(CreateProductModel model)
        {
            try
            {
                var Entity = mapper.Map<Product>(model);
                uOW.GetProductRepository.Create(Entity);
                if(await uOW.SaveChangesAsync())
                {
                    response.Data = "Added Successfully";
                    response.Succeeded = true;
                }
                else
                {
                    response.Data = "Add is Failed";
                    response.Succeeded = false;
                }
            }
            catch(Exception ex)
            {

                response.Data = ex;
                response.Succeeded = false;
            }
            return response;
        }

        public Task<IPagingResponse> Get(PaginationReqModel paginationReq)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> GetCategory(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> GetDepartment(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> GetQuantity(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
