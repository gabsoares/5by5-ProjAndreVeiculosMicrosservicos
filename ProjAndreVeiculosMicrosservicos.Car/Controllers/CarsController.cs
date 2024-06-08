using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIAndreVeiculosMicrosservicos.Car.Data;
using APIAndreVeiculosMicrosservicos.Car.CarService;
using Models.DTO;

namespace APIAndreVeiculosMicrosservicos.Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly APIAndreVeiculosMicrosservicosCarContext _context;

        public CarsController(APIAndreVeiculosMicrosservicosCarContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Car>>> GetCar()
        {
            if (_context.Car == null)
            {
                return NotFound();
            }
            return await _context.Car.ToListAsync();
        }

        // GET: api/Cars/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Car>> GetCar(string id)
        {
            if (_context.Car == null)
            {
                return NotFound();
            }
            var car = await _context.Car.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Cars/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(string id, Models.Car car)
        {
            if (id != car.CarPlate)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Cars
        [HttpPost]
        public async Task<ActionResult<Models.Car>> PostCar(CarDTO carDTO)
        {
            if (_context.Car == null)
            {
                return Problem("Entity set 'APIAndreVeiculosMicrosservicosCarContext.Car'  is null.");
            }
            Models.Car car = new Models.Car(carDTO);

            car.CarPlate = new CarService.CarService().GenerateCarPlate();
            car.IsSold = false;

            _context.Car.Add(car);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CarExists(car.CarPlate))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetCar", new { id = car.CarPlate }, car);
        }

        // DELETE: api/Cars/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(string id)
        {
            if (_context.Car == null)
            {
                return NotFound();
            }
            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Car.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(string id)
        {
            return (_context.Car?.Any(car => car.CarPlate == id)).GetValueOrDefault();
        }
    }
}