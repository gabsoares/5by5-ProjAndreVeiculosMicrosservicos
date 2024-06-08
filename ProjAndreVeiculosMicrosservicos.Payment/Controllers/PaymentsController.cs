using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIAndreVeiculosMicrosservicos.Payment.Data;
using Models.DTO;
using Services.Services;

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
        public async Task<ActionResult<IEnumerable<Models.Payment>>> GetPayment(byte techType)
        {
            if (_context.Payment == null)
            {
                return NotFound();
            }
            if (techType == 0)
            {
                return await _context.Payment
                    .Include(p => p.CreditCard)
                    .Include(p => p.Ticket)
                    .Include(p => p.Pix)
                    .Include(p => p.Pix.PixType)
                    .ToListAsync();
            }
            else if (techType == 1)
            {
                return new PaymentService().GetAllPayments(1);
            }
            else if (techType == 2)
            {
                return new PaymentService().GetAllPayments(2);
            }
            return null;

        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Payment>> GetPayment(int id)
        {
            if (_context.Payment == null)
            {
                return NotFound();
            }
            var payment = await _context.Payment
                .Include(p => p.CreditCard)
                .Include(p => p.Ticket)
                .Include(p => p.Pix)
                .Include(p => p.Pix.PixType)
                .FirstOrDefaultAsync(p => p.Id == id);

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
        public async Task<ActionResult<Models.Payment>> PostPayment(PaymentDTO paymentDTO)
        {
            if (_context.Payment == null)
            {
                return Problem("Entity set 'APIAndreVeiculosMicrosservicosPaymentContext.Payment'  is null.");
            }
            Models.Payment payment = new(paymentDTO);
            payment.CreditCard = await _context.CreditCard.FindAsync(paymentDTO.CreditCardId);
            payment.Ticket = await _context.Ticket.FindAsync(paymentDTO.TicketId);
            payment.Pix = await _context.Pix.FindAsync(paymentDTO.PixId);
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