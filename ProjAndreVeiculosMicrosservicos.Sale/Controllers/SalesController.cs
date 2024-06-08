using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIAndreVeiculosMicrosservicos.Sale.Data;
using Models.DTO;
using Models;

namespace APIAndreVeiculosMicrosservicos.Sale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly APIAndreVeiculosMicrosservicosSaleContext _context;

        public SalesController(APIAndreVeiculosMicrosservicosSaleContext context)
        {
            _context = context;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Sale>>> GetSale()
        {
            if (_context.Sale == null)
            {
                return NotFound();
            }
            return await _context.Sale
                .Include(s => s.Car)
                .Include(s => s.Client)
                .Include(s => s.Client.Adress)
                .Include(s => s.Employee)
                .Include(s => s.Employee.Adress)
                .Include(s => s.Employee.Role)
                .Include(s => s.Payment)
                .Include(s => s.Payment.CreditCard)
                .Include(s => s.Payment.Pix)
                .Include(s => s.Payment.Ticket)
                .ToListAsync();
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Sale>> GetSale(int id)
        {
            if (_context.Sale == null)
            {
                return NotFound();
            }
            var sale = await _context.Sale
                .Include(s => s.Car)
                .Include(s => s.Client)
                .Include(s => s.Client.Adress)
                .Include(s => s.Employee)
                .Include(s => s.Employee.Adress)
                .Include(s => s.Employee.Role)
                .Include(s => s.Payment)
                .Include(s => s.Payment.CreditCard)
                .Include(s => s.Payment.Pix)
                .Include(s => s.Payment.Ticket)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return sale;
        }

        // PUT: api/Sales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(int id, Models.Sale sale)
        {
            if (id != sale.Id)
            {
                return BadRequest();
            }

            _context.Entry(sale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
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

        // POST: api/Sales
        [HttpPost]
        public async Task<ActionResult<Models.Sale>> PostSale(SaleDTO saleDTO)
        {
            if (_context.Sale == null)
            {
                return Problem("Entity set 'APIAndreVeiculosMicrosservicosSaleContext.Sale'  is null.");
            }
            Models.Sale sale = new Models.Sale(saleDTO);

            sale.Car = await _context.Car.FindAsync(saleDTO.CarPlate);
            sale.Client = await _context.Customer.FindAsync(saleDTO.CustomerCPF);
            sale.Employee = await _context.Employee.FindAsync(saleDTO.EmployeeCPF);
            sale.Payment = await _context.Payment.FindAsync(saleDTO.PaymentId);
            sale.SaleValue = saleDTO.SaleValue;
            sale.SaleDate = saleDTO.SaleDate;

            _context.Sale.Add(sale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSale", new { id = sale.Id }, sale);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            if (_context.Sale == null)
            {
                return NotFound();
            }
            var sale = await _context.Sale.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _context.Sale.Remove(sale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaleExists(int id)
        {
            return (_context.Sale?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}