using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Domain.Models.Services
{
    public class ViewDepartmentModel
    {
        public ViewDepartmentModel()
        {
            this.Catergories = new List<string>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<string> Catergories { get; set; }
    }
}
