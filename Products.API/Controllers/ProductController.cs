using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Application.Interfaces.IUnitOfWork;
using Products.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IUnitOfWork UOW;

        public ProductController(ILogger<ProductController> logger, IUnitOfWork UOW)
        {
            _logger = logger;
            this.UOW = UOW;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await UOW.GetProductRepository.GetAll());
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await UOW.GetProductRepository.FindById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Product product)
        {
            UOW.GetProductRepository.Create(product);
            if (await UOW.SaveChangesAsync())
                return Ok(product);
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            UOW.GetProductRepository.Update(product);
            if (await UOW.SaveChangesAsync())
                return Ok(product);
            return BadRequest();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            UOW.GetProductRepository.Delete(id);
            if (!await UOW.SaveChangesAsync())
                return BadRequest();
            return Ok();
        }
    }
}
