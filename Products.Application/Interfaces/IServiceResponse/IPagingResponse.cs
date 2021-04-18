using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Application.Interfaces.IServiceResponse
{
    public interface IPagingResponse : IResponse
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        int TotlalRows { get; set; }
    }
}
