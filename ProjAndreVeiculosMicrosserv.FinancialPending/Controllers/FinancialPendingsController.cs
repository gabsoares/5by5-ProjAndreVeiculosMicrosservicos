using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using Models;
using Models.DTO;
using ProjAndreVeiculosMicrosserv.FinancialPending.Data;
using Services.Services;

namespace ProjAndreVeiculosMicrosserv.FinancialPending.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FinancialPendingsController : ControllerBase
{
    private readonly DataApiContext _context;
    private readonly FinancialPendingService _financialPendingService;

    public FinancialPendingsController(DataApiContext context)
    {
        _context = context;
        _financialPendingService = new FinancialPendingService();
    }

    // GET: api/FinancialPendings
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.FinancialPending>>> GetFinancialPending()
    {
        if (_context.FinancialPending == null) return NotFound();
        return await _context.FinancialPending.ToListAsync();
    }

    // GET: api/FinancialPendings/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Models.FinancialPending>> GetFinancialPending(int id)
    {
        if (_context.FinancialPending == null) return NotFound();
        var financialPending = await _context.FinancialPending.FindAsync(id);

        if (financialPending == null) return NotFound();

        return financialPending;
    }

    // PUT: api/FinancialPendings/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFinancialPending(int id, Models.FinancialPending financialPending)
    {
        if (id != financialPending.Id) return BadRequest();

        _context.Entry(financialPending).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FinancialPendingExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // POST: api/FinancialPendings
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Models.FinancialPending>> PostFinancialPending(
        FinancialPendingDTO financialPendingDto)
    {
        if (_context.FinancialPending == null)
            return Problem(
                "Entity set 'ProjAndreVeiculosMicrosservFinancialPendingContext.FinancialPending'  is null.");

        var customer = _context.Customer.Find(financialPendingDto.Cpf);
        if (customer == null) return BadRequest();

        var financialPending = new Models.FinancialPending
        {
            Id = financialPendingDto.Id,
            BillingDate = financialPendingDto.BillingDate,
            Customer = customer,
            Description = financialPendingDto.Description,
            PendingDate = financialPendingDto.PendingDate,
            Status = financialPendingDto.Status,
            Value = financialPendingDto.Value
        };

        await _context.FinancialPending.AddAsync(financialPending);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFinancialPending", new { id = financialPendingDto.Id }, financialPendingDto);
    }

    // DELETE: api/FinancialPendings/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFinancialPending(int id)
    {
        if (_context.FinancialPending == null) return NotFound();
        var financialPending = await _context.FinancialPending.FindAsync(id);
        if (financialPending == null) return NotFound();

        _context.FinancialPending.Remove(financialPending);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FinancialPendingExists(int id)
    {
        return (_context.FinancialPending?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}