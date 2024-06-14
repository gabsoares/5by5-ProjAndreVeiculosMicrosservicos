using APIAndreVeiculosMicrosservicos.Adress.Services;
using DataApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using Services;

namespace ProjAndreVeiculosMicrosservicos.Driver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly DataApiContext _context;

        public DriversController(DataApiContext context)
        {
            _context = context;
        }

        // GET: api/Drivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Driver>>> GetDriver()
        {
            if (_context.Driver == null)
            {
                return NotFound();
            }
            return await _context.Driver.ToListAsync();
        }

        // GET: api/Drivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Driver>> GetDriver(string id)
        {
            if (_context.Driver == null)
            {
                return NotFound();
            }
            var driver = await _context.Driver
                .Include(d => d.Adress)
                .Include(d => d.Cnh)
                .Include(d => d.Cnh.Category)
                .FirstOrDefaultAsync(d => d.CPF == id);

            if (driver == null)
            {
                return NotFound();
            }

            return driver;
        }

        // PUT: api/Drivers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriver(string id, Models.Driver driver)
        {
            if (id != driver.CPF)
            {
                return BadRequest();
            }

            _context.Entry(driver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
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

        // POST: api/Drivers
        [HttpPost]
        public async Task<ActionResult<Models.Driver>> PostDriver(DriverDTO driverDTO)
        {
            if (_context.Driver == null)
            {
                return Problem("Entity set 'ProjAndreVeiculosMicrosservicosDriverContext.Driver'  is null.");
            }
            AdressService adressService = new();
            var adress = await adressService.GetAdressData(driverDTO.Adress.ZipCode, driverDTO.Adress);

            Models.Driver driver = new(driverDTO);
            driver.Adress = adress;
            driver.Cnh = new Cnh
            {
                CnhNumber = driverDTO.Cnh.CnhNumber,
                DueDate = driverDTO.Cnh.DueDate,
                RG = driverDTO.Cnh.RG,
                CPF = driverDTO.Cnh.CPF,
                DadName = driverDTO.Cnh.DadName,
                MotherName = driverDTO.Cnh.MotherName,
                Category = await _context.CnhCategory.FindAsync(driverDTO.Cnh.Category.Id)
            };
            _context.Driver.Add(driver);
            try
            {
                await _context.SaveChangesAsync();
                new AdressServiceADODapper().InsertOne(driver.Adress);
            }
            catch (DbUpdateException)
            {
                if (DriverExists(driver.CPF))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetDriver", new { id = driver.CPF }, driver);
        }

        // DELETE: api/Drivers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(string id)
        {
            if (_context.Driver == null)
            {
                return NotFound();
            }
            var driver = await _context.Driver.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            _context.Driver.Remove(driver);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriverExists(string id)
        {
            return (_context.Driver?.Any(e => e.CPF == id)).GetValueOrDefault();
        }
    }
}