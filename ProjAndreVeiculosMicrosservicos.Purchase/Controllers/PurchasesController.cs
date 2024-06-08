using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIAndreVeiculosMicrosservicos.Purchase.Data;
using Models.DTO;

namespace APIAndreVeiculosMicrosservicos.Purchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly APIAndreVeiculosMicrosservicosPurchaseContext _context;

        public PurchasesController(APIAndreVeiculosMicrosservicosPurchaseContext context)
        {
            _context = context;
        }

        // GET: api/Purchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Purchase>>> GetPurchase()
        {
            if (_context.Purchase == null)
            {
                return NotFound();
            }
            return await _context.Purchase.ToListAsync();
        }

        // GET: api/Purchases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Purchase>> GetPurchase(int id)
        {
            if (_context.Purchase == null)
            {
                return NotFound();
            }
            var purchase = await _context.Purchase.FindAsync(id);

            if (purchase == null)
            {
                return NotFound();
            }

            return purchase;
        }

        // PUT: api/Purchases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchase(int id, Models.Purchase purchase)
        {
            if (id != purchase.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseExists(id))
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

        // POST: api/Purchases
        [HttpPost]
        public async Task<ActionResult<Models.Purchase>> PostPurchase(PurchaseDTO purchaseDTO)
        {
            if (_context.Purchase == null)
            {
                return Problem("Entity set 'APIAndreVeiculosMicrosservicosPurchaseContext.Purchase'  is null.");
            }
            Models.Purchase purchase = new Models.Purchase(purchaseDTO);

            purchase.Car = await _context.Car.FindAsync(purchaseDTO.CarPlate);
            purchase.Price = purchaseDTO.Price;
            purchase.PurchaseDate = purchaseDTO.PurchaseDate;

            _context.Purchase.Add(purchase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchase", new { id = purchase.Id }, purchase);
        }

        // DELETE: api/Purchases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            if (_context.Purchase == null)
            {
                return NotFound();
            }
            var purchase = await _context.Purchase.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            _context.Purchase.Remove(purchase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseExists(int id)
        {
            return (_context.Purchase?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}