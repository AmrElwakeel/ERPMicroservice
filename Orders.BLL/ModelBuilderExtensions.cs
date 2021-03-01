using Microsoft.EntityFrameworkCore;
using Orders.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.BLL
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    ID = 1,
                    Created = DateTime.Now,
                    TotalPrice = 1000
                },
                new Order
                {
                    ID = 2,
                    Created = DateTime.Now,
                    TotalPrice = 3000
                }
            );

            modelBuilder.Entity<OrderDetials>().HasData(
            new OrderDetials
            {
                ID = 1,
                TotalPrice = 500,
                Amount = 2,
                ItemPrice = 250,
                OrderId = 1,
                ProductName = "IPhone",
                ProductId = 1
            },
            new OrderDetials
            {
                ID = 2,
                TotalPrice = 500,
                Amount = 2,
                ItemPrice = 250,
                OrderId = 1,
                ProductName = "MI 10T",
                ProductId = 2
            },
            new OrderDetials
            {
                ID = 3,
                TotalPrice = 500,
                Amount = 2,
                ItemPrice = 250,
                OrderId = 2,
                ProductName = "IPhone",
                ProductId = 1
            },
            new OrderDetials
            {
                ID = 4,
                TotalPrice = 500,
                Amount = 2,
                ItemPrice = 250,
                OrderId = 2,
                ProductName = "MI 10T",
                ProductId = 2
            });
        }
    }
}
