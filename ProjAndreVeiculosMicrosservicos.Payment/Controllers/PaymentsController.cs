﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIAndreVeiculosMicrosservicos.Payment.Data;

namespace APIAndreVeiculosMicrosservicos.Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly APIAndreVeiculosMicrosservicosPaymentContext _context;

        public PaymentsController(APIAndreVeiculosMicrosservicosPaymentContext context)
        {
            _context = context;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Payment>>> GetPayment()
        {
          if (_context.Payment == null)
          {
              return NotFound();
          }
            return await _context.Payment.ToListAsync();
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Payment>> GetPayment(int id)
        {
          if (_context.Payment == null)
          {
              return NotFound();
          }
            var payment = await _context.Payment.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // PUT: api/Payments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Models.Payment payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
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

        // POST: api/Payments
        [HttpPost]
        public async Task<ActionResult<Models.Payment>> PostPayment(Models.Payment payment)
        {
          if (_context.Payment == null)
          {
              return Problem("Entity set 'APIAndreVeiculosMicrosservicosPaymentContext.Payment'  is null.");
          }
            _context.Payment.Add(payment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            if (_context.Payment == null)
            {
                return NotFound();
            }
            var payment = await _context.Payment.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.Payment.Remove(payment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentExists(int id)
        {
            return (_context.Payment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}