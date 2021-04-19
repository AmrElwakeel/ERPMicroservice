using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Domain.Models.PaginationRequest
{
    public class PaginationReqModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
