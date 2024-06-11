using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using ProjAndreVeiculosMicrosservicos.Dependent.Data;

namespace ProjAndreVeiculosMicrosservicos.Dependent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependentsController : ControllerBase
    {
        private readonly DataApiContext _context;

        public DependentsController(DataApiContext context)
        {
            _context = context;
        }

        // GET: api/Dependents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Dependent>>> GetDependent()
        {
          if (_context.Dependent == null)
          {
              return NotFound();
          }
            return await _context.Dependent.ToListAsync();
        }

        // GET: api/Dependents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Dependent>> GetDependent(string id)
        {
          if (_context.Dependent == null)
          {
              return NotFound();
          }
            var dependent = await _context.Dependent.FindAsync(id);

            if (dependent == null)
            {
                return NotFound();
            }

            return dependent;
        }

        // PUT: api/Dependents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDependent(string id, Models.Dependent dependent)
        {
            if (id != dependent.CPF)
            {
                return BadRequest();
            }

            _context.Entry(dependent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DependentExists(id))
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

        // POST: api/Dependents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.Dependent>> PostDependent(Models.Dependent dependent)
        {
          if (_context.Dependent == null)
          {
              return Problem("Entity set 'ProjAndreVeiculosMicrosservicosDependentContext.Dependent'  is null.");
          }
            _context.Dependent.Add(dependent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DependentExists(dependent.CPF))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDependent", new { id = dependent.CPF }, dependent);
        }

        // DELETE: api/Dependents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDependent(string id)
        {
            if (_context.Dependent == null)
            {
                return NotFound();
            }
            var dependent = await _context.Dependent.FindAsync(id);
            if (dependent == null)
            {
                return NotFound();
            }

            _context.Dependent.Remove(dependent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DependentExists(string id)
        {
            return (_context.Dependent?.Any(e => e.CPF == id)).GetValueOrDefault();
        }
    }
}
