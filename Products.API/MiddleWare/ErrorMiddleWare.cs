using Microsoft.AspNetCore.Http;
using Products.Application.Interfaces.IServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.API.MiddleWare
{
    public class ErrorMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly IResponse response;

        public ErrorMiddleWare(RequestDelegate next,IResponse response)
        {
            _next = next;
            this.response = response;
        }

        public Task Invoke(HttpContext httpContext)
        {

            try
            {
                return _next(httpContext);
            }
            catch(Exception ex)
            {
                response.Succeeded = false;
                response.Data = ex;
                return httpContext.Response.WriteAsync(response.ToString());
            }
        }
    }
}
