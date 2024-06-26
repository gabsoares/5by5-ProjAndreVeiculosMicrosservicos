﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIAndreVeiculosMicrosservicos.Purchase.Data;
using Models.DTO;
using Services.Services;
using DataApi.Data;

namespace APIAndreVeiculosMicrosservicos.Purchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly DataApiContext _context;

        public PurchasesController(DataApiContext context)
        {
            _context = context;
        }

        // GET: api/Purchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Purchase>>> GetPurchase(byte techType)
        {
            if (_context.Purchase == null)
            {
                return NotFound();
            }

            if (techType == 0)
            {
                return await _context.Purchase
                    .Include(p => p.Car)
                    .ToListAsync();
            }
            else if (techType == 1)
            {
                return await new PurchaseService().GetAllPurchases(1);
            }
            else if (techType == 2)
            {
                return await new PurchaseService().GetAllPurchases(2);
            }
            return null;
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