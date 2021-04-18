using Products.Application.Interfaces.IServiceResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Persistence.Services.ServiceResponse
{
    public class Response : IResponse
    {
        public bool Succeeded { get; set ; }
        public object Data { get ; set; }
    }
}
