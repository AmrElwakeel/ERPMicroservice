using Products.Application.Interfaces.IServiceResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Persistence.Services.ServiceResponse
{
    public class PaginationResponse : Response, IPagingResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotlalRows { get; set; }
    }
}
