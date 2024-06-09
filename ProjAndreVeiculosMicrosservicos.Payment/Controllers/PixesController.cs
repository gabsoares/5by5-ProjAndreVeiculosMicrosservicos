using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIAndreVeiculosMicrosservicos.Payment.Data;
using Models;
using Models.DTO;
using Services.Services;

namespace APIAndreVeiculosMicrosservicos.Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PixesController : ControllerBase
    {
        private readonly APIAndreVeiculosMicrosservicosPaymentContext _context;

        public PixesController(APIAndreVeiculosMicrosservicosPaymentContext context)
        {
            _context = context;
        }

        // GET: api/Pixes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pix>>> GetPix(byte techType)
        {
            if (_context.Pix == null)
            {
                return NotFound();
            }
            if (techType == 0)
            {
                return await _context.Pix
                    .Include(p => p.PixType)
                    .ToListAsync();
            }
            else if (techType == 1)
            {
                return await new PixService().GetAllPix(1);
            }
            else if (techType == 2)
            {
                return await new PixService().GetAllPix(2);
            }
            return null;

        }

        // GET: api/Pixes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pix>> GetPix(int id)
        {
            if (_context.Pix == null)
            {
                return NotFound();
            }
            var pix = await _context.Pix
                .Include(p => p.PixType)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pix == null)
            {
                return NotFound();
            }

            return pix;
        }

        // PUT: api/Pixes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPix(int id, Pix pix)
        {
            if (id != pix.Id)
            {
                return BadRequest();
            }

            _context.Entry(pix).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PixExists(id))
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

        // POST: api/Pixes
        [HttpPost]
        public async Task<ActionResult<Pix>> PostPix(PixDTO pixDTO)
        {
            if (_context.Pix == null)
            {
                return Problem("Entity set 'APIAndreVeiculosMicrosservicosPaymentContext.Pix'  is null.");
            }
            Pix pix = new Pix(pixDTO);
            pix.PixType = await _context.PixType.FindAsync(pixDTO.PixTypeId);
            pix.PixKey = pixDTO.PixKey;
            _context.Pix.Add(pix);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPix", new { id = pix.Id }, pix);
        }

        // DELETE: api/Pixes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePix(int id)
        {
            if (_context.Pix == null)
            {
                return NotFound();
            }
            var pix = await _context.Pix.FindAsync(id);
            if (pix == null)
            {
                return NotFound();
            }

            _context.Pix.Remove(pix);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PixExists(int id)
        {
            return (_context.Pix?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}