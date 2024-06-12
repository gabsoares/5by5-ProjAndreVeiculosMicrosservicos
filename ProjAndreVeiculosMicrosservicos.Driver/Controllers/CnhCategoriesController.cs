using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataApi.Data;
using Models;

namespace ProjAndreVeiculosMicrosservicos.Driver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CnhCategoriesController : ControllerBase
    {
        private readonly DataApiContext _context;

        public CnhCategoriesController(DataApiContext context)
        {
            _context = context;
        }

        // GET: api/CnhCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CnhCategory>>> GetCnhCategory()
        {
          if (_context.CnhCategory == null)
          {
              return NotFound();
          }
            return await _context.CnhCategory.ToListAsync();
        }

        // GET: api/CnhCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CnhCategory>> GetCnhCategory(long id)
        {
          if (_context.CnhCategory == null)
          {
              return NotFound();
          }
            var cnhCategory = await _context.CnhCategory.FindAsync(id);

            if (cnhCategory == null)
            {
                return NotFound();
            }

            return cnhCategory;
        }

        // PUT: api/CnhCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCnhCategory(long id, CnhCategory cnhCategory)
        {
            if (id != cnhCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(cnhCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CnhCategoryExists(id))
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

        // POST: api/CnhCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CnhCategory>> PostCnhCategory(CnhCategory cnhCategory)
        {
          if (_context.CnhCategory == null)
          {
              return Problem("Entity set 'DataApiContext.CnhCategory'  is null.");
          }
            _context.CnhCategory.Add(cnhCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCnhCategory", new { id = cnhCategory.Id }, cnhCategory);
        }

        // DELETE: api/CnhCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCnhCategory(long id)
        {
            if (_context.CnhCategory == null)
            {
                return NotFound();
            }
            var cnhCategory = await _context.CnhCategory.FindAsync(id);
            if (cnhCategory == null)
            {
                return NotFound();
            }

            _context.CnhCategory.Remove(cnhCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CnhCategoryExists(long id)
        {
            return (_context.CnhCategory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
