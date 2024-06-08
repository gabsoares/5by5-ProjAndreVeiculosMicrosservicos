using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIAndreVeiculosMicrosservicos.Employee.Data;
using Models;

namespace APIAndreVeiculosMicrosservicos.Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly APIAndreVeiculosMicrosservicosEmployeeContext _context;

        public EmployeesController(APIAndreVeiculosMicrosservicosEmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Employee>>> GetEmployee()
        {
            if (_context.Employee == null)
            {
                return NotFound();
            }
            return await _context.Employee.Include(r => r.Role).Include(a => a.Adress).ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Employee>> GetEmployee(string id)
        {
            if (_context.Employee == null)
            {
                return NotFound();
            }
            var employee = await _context.Employee.Include(e => e.Adress).Include(e => e.Role).FirstOrDefaultAsync(c => c.CPF == id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(string id, Models.Employee employee)
        {
            if (id != employee.CPF)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Models.Employee>> PostEmployee(Models.Employee employee)
        {
            if (_context.Employee == null)
            {
                return Problem("Entity set 'APIAndreVeiculosMicrosservicosEmployeeContext.Employee'  is null.");
            }
            employee.Adress = await _context.Adress.FindAsync(employee.Adress.Id);
            employee.Role = await _context.Role.FindAsync(employee.Role.Id);
            _context.Employee.Add(employee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeExists(employee.CPF))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployee", new { id = employee.CPF }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            if (_context.Employee == null)
            {
                return NotFound();
            }
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(string id)
        {
            return (_context.Employee?.Any(e => e.CPF == id)).GetValueOrDefault();
        }
    }
}