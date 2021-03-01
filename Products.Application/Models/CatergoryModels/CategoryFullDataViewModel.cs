using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Application.Models.CatergoryModels
{
    public class CategoryFullDataViewModel : CatergoryViewModel
    { 
        public List<string> Products { get; set; }
        public string Department { get; set; }
    }
}
