using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exemplo_api.Data;
using exemplo_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace exemplo_api.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            var products = await context.Products.Include(x => x.Category).ToListAsync();
            return products;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id)
        {
            var product = await context.Products.Include(x => x.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post(
            [FromServices] DataContext context,
            [FromBody] Product model)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("id")]
        public async Task<ActionResult<Product>> Delete([FromServices] DataContext context, int id)
        {
            var product = await context.Products
                .FirstOrDefaultAsync(x => x.Id == id);
            context.Remove(product);
            await context.SaveChangesAsync();

            return product;
        }

        [HttpPut]
        [Route("id")]
        public async Task<ActionResult<Product>> Put(
                    [FromServices] DataContext context,
                    [FromBody] Product model, int id)
        {
            if (ModelState.IsValid)
            {
                context.Products.Update(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
