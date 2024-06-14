using DataApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using Services.Services;

namespace ProjAndreVeiculosMicrosservicos.Isurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancesController : ControllerBase
    {
        private readonly DataApiContext _context;
        private readonly InsuranceService _insuranceService;
        public InsurancesController(DataApiContext context)
        {
            _context = context;
            _insuranceService = new InsuranceService();
        }

        // GET: api/Insurances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Insurance>>> GetInsurance()
        {
            if (_context.Insurance == null)
            {
                return NotFound();
            }
            return await _insuranceService.GetAllInsurances();
        }

        // GET: api/Insurances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Insurance>> GetInsurance(int id)
        {
            if (_context.Insurance == null)
            {
                return NotFound();
            }
            var insurance = await _insuranceService.GetInsurance(id);

            if (insurance == null)
            {
                return NotFound();
            }

            return insurance;
        }

        // POST: api/Insurances
        [HttpPost]
        public async Task<ActionResult<Insurance>> PostInsurance(InsuranceDTO insuranceDTO)
        {
            if (_context.Insurance == null)
            {
                return Problem("Entity set 'ProjAndreVeiculosMicrosservicosIsuranceContext.Insurance' is null.");
            }
            Insurance insurance = new Insurance(insuranceDTO);
            var carPlate = _context.Car.Where(c => c.CarPlate == insuranceDTO.CarPlate).FirstOrDefault();

            var customer = _context.Customer
                .Where(c => c.CPF == insuranceDTO.CustomerCPF)
                .Include(c => c.Adress)
                .FirstOrDefault();

            var driver = _context.Driver
                .Where(d => d.CPF == insuranceDTO.DriverCPF)
                .Include(d => d.Adress)
                .Include(d => d.Cnh)
                .Include(d => d.Cnh.Category)
                .FirstOrDefault();

            insurance.Car = carPlate;
            insurance.Customer = customer;
            insurance.Driver = driver;

            insurance.Id = _insuranceService.InsertInsurance(insurance).Result;
            return CreatedAtAction("GetInsurance", new { id = insurance.Id }, insurance);
        }

        private bool InsuranceExists(int id)
        {
            return (_context.Insurance?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}