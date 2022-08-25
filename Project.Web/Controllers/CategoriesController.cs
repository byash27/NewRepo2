using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.Web.Data;
using Project.Web.Models;

namespace Project.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CategoriesController> _logger;  // changes


        public CategoriesController(
                    ApplicationDbContext context,
                    ILogger<CategoriesController> logger)    //block changed
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var pc = await _context.Categories.ToListAsync(); // pc =  product categories
                if (pc == null)
                {
                    _logger.LogWarning("No Categories were found");
                    return NotFound();
                }
                _logger.LogInformation("Extracted all the categories");
                return Ok(pc);
            }
            catch
            {
                _logger.LogError("Attempt made to retrieve information");
                return BadRequest();
            }
        }
        //public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        //{
        //    return await _context.Categories.ToListAsync();
        //}

        // GET: api/Categories/5                    // Third test here (block changed)
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategory(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null) { return NotFound(); }
                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }


        }


        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.CatgoryId)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.CatgoryId }, category);
        }

        // DELETE: api/Categories/5                 // Changes for delete test
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            try
            {
                var issueCategory = await _context.Categories.FindAsync(id);
                if (issueCategory == null)
                {
                    return NotFound();
                }

                _context.Categories.Remove(issueCategory);
                await _context.SaveChangesAsync();

                return Ok(issueCategory);
            }
            catch
            {
                return BadRequest();
            }

        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CatgoryId == id);
        }
    }
}
