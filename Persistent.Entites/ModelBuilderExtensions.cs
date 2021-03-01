using Microsoft.EntityFrameworkCore;
using Products.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Persistence.Entites
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { ID=1, Name="Clothes" },
                new Department { ID=2, Name = "Shoes" },
                new Department { ID = 3, Name = "Electronics" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { ID=1,Name="Men",DepartmentId=1},
                new Category { ID=2,Name="Women",DepartmentId=1},
                new Category { ID=3,Name="Children",DepartmentId=1},

                new Category { ID = 4, Name = "Men", DepartmentId = 2 },
                new Category { ID = 5, Name = "Women", DepartmentId = 2 },
                new Category { ID = 6, Name = "Children", DepartmentId = 2 },

                new Category { ID = 7, Name = "Smart Phones", DepartmentId = 3 },
                new Category { ID = 8, Name = "Tablets", DepartmentId = 3 },
                new Category { ID = 9, Name = "Laptops", DepartmentId = 3 }
            );


            modelBuilder.Entity<Product>().HasData(
                new Product { ID=1,Name="IPhone 12",CatergoryId=7,Price=999, Quantity=100},
                new Product { ID=2,Name="Samsung A71",CatergoryId=7,Price=888, Quantity=80},
                new Product { ID=3,Name="Mi 10T",CatergoryId=7,Price=666, Quantity=60}
            );
        }
    }
}
