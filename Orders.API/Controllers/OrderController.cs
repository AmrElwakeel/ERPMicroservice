﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Orders.DAL.Entities;
using Orders.DAL.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork UOW;
        public OrderController(IUnitOfWork UOW)
        {
            this.UOW = UOW;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await UOW.GetOrderRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order= await UOW.GetOrderRepository.FindById(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Order order)
        {
            UOW.GetOrderRepository.Create(order);
            if (await UOW.SaveChanges())
                return Ok(order);
            return BadRequest(); 
        }

        [HttpPost]
        public async Task<IActionResult> Post(Order order)
        {
            UOW.GetOrderRepository.Update(order);
            if (await UOW.SaveChanges())
                return Ok(order);
            return BadRequest();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            UOW.GetOrderRepository.Delete(id);
            if (!await UOW.SaveChanges())
                return BadRequest();
            return Ok();
        }
    }
}
