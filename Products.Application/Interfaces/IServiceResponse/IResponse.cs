using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Application.Interfaces.IServiceResponse
{
    public interface IResponse
    {
        bool Succeeded { get; set; }
        object Data { get; set; }
    }
}
