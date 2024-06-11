using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using _5by5_ProjAndreVeiculosMicrosservicos.Data;
using Models.DTO;
using Services.Services_DAPPER;
using APIAndreVeiculosMicrosservicos.Adress.Controllers;
using Services;
using APIAndreVeiculosMicrosservicos.Adress.Services;
using DataApi.Data;

namespace _5by5_ProjAndreVeiculosMicrosservicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DataApiContext _context;

        public CustomersController(DataApiContext context)
        {
            _context = context;
        }


        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer(int techType)
        {
            if (_context.Customer == null)
            {
                return NotFound();
            }
            if (techType == 0)
            {
                return await _context.Customer
                    .Include(c => c.Adress)
                    .ToListAsync();
            }
            else if (techType == 1)
            {
                return await new CustomerService().GetAllCustomers(1);
            }
            else if (techType == 2)
            {
                return await new CustomerService().GetAllCustomers(2);
            }
            return null;
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(string id)
        {
            if (_context.Customer == null)
            {
                return NotFound();
            }
            var customer = await _context.Customer
                .Include(c => c.Adress)
                .FirstOrDefaultAsync(c => c.CPF == id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(string id, CustomerDTO customerDTO)
        {
            Customer customer = new(customerDTO);
            customer.Adress = await _context.Adress.FindAsync(customerDTO.Adress);
            customer.Name = customerDTO.CustomerName;
            customer.DateOfBirth = customerDTO.CustomerDateOfBirth;
            customer.Phone = customerDTO.CustomerPhone;
            customer.Email = customerDTO.CustomerEmail;
            customer.Income = customerDTO.CustomerIncome;
            customer.PDFDocument = customerDTO.CustomerPDFDoc;
            if (id != customer.CPF)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CustomerDTO customerDTO)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set '_5by5_ProjAndreVeiculosMicrosservicosContext.Customer'  is null.");
            }
            AdressService adressService = new();
            Customer customer = new(customerDTO);

            var adress = await adressService.RetrieveAdressData(customerDTO.Adress, customerDTO.Adress.ZipCode);
            customer.Adress = adress;
            customer.Adress.Complement = customerDTO.Adress.Complement;
            customer.Adress.Number = customerDTO.Adress.Number;
            customer.Adress.ZipCode = customerDTO.Adress.ZipCode;

            customer.Name = customerDTO.CustomerName;
            customer.DateOfBirth = customerDTO.CustomerDateOfBirth;
            customer.Phone = customerDTO.CustomerPhone;
            customer.Email = customerDTO.CustomerEmail;
            customer.Income = customerDTO.CustomerIncome;
            customer.PDFDocument = customerDTO.CustomerPDFDoc;

            _context.Customer.Add(customer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerExists(customer.CPF))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            new AdressServiceADODapper().InsertOne(customer.Adress);
            return CreatedAtAction("GetCustomer", new { id = customer.CPF }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            if (_context.Customer == null)
            {
                return NotFound();
            }
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(string id)
        {
            return (_context.Customer?.Any(customer => customer.CPF == id)).GetValueOrDefault();
        }
    }
}