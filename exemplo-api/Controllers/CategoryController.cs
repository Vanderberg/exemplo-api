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
    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            var categories = await context.Categories.ToListAsync();
            return categories;

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Category>> GetById([FromServices] DataContext context, int id)
        {
            var category = await context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return category;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post(
            [FromServices] DataContext context, 
            [FromBody] Category model)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(model);
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
        public async Task<ActionResult<Category>> Delete([FromServices] DataContext context, int id)
        {
            var category = await context.Categories
                .FirstOrDefaultAsync(x => x.Id == id);
            context.Remove(category);
            await context.SaveChangesAsync();

            return category;
        }

        [HttpPut]
        [Route("id")]
        public async Task<ActionResult<Category>> Put(
                    [FromServices] DataContext context,
                    [FromBody] Category model, int id)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Update(model);
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
