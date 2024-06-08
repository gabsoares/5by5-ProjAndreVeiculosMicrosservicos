using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIAndreVeiculosMicrosservicos.Adress.Data;
using APIAndreVeiculosMicrosservicos.Adress.Services;
using Models.DTO;
using Models;

namespace APIAndreVeiculosMicrosservicos.Adress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly APIAndreVeiculosMicrosservicosAdressContext _context;

        public AdressesController(APIAndreVeiculosMicrosservicosAdressContext context)
        {
            _context = context;
        }

        // GET: api/Adresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Adress>>> GetAdress()
        {
          if (_context.Adress == null)
          {
              return NotFound();
          }
            return await _context.Adress.ToListAsync();
        }

        // GET: api/Adresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Adress>> GetAdress(int id)
        {
          if (_context.Adress == null)
          {
              return NotFound();
          }
            var adress = await _context.Adress.FindAsync(id);

            if (adress == null)
            {
                return NotFound();
            }

            return adress;
        }

        // PUT: api/Adresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdress(int id, AdressDTO adressDTO)
        {
            Models.Adress adress = new(adressDTO, 1);

            string cep = adress.ZipCode;

            new AdressService().RetrieveAdressData(adressDTO, cep, adress);

            if (id != adress.Id)
            {
                return BadRequest();
            }

            _context.Entry(adress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdressExists(id))
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

        // POST: api/Adresses
        [HttpPost]
        public async Task<ActionResult<Models.Adress>> PostAdress(AdressDTO adressDTO)
        {
          if (_context.Adress == null)
          {
              return Problem("Entity set 'APIAndreVeiculosMicrosservicosAdressContext.Adress'  is null.");
            }

            Models.Adress adress = new Models.Adress(adressDTO, 0);
            string cep = adress.ZipCode;

            new AdressService().RetrieveAdressData(adressDTO, cep, adress);

            _context.Adress.Add(adress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdress", new { id = adress.Id }, adress);
        }

        // DELETE: api/Adresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdress(int id)
        {
            if (_context.Adress == null)
            {
                return NotFound();
            }
            var adress = await _context.Adress.FindAsync(id);
            if (adress == null)
            {
                return NotFound();
            }

            _context.Adress.Remove(adress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdressExists(int id)
        {
            return (_context.Adress?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}