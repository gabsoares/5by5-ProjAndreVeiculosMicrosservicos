﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIAndreVeiculosMicrosservicos.Payment.Data;
using Models;
using Models.DTO;

namespace APIAndreVeiculosMicrosservicos.Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PixTypesController : ControllerBase
    {
        private readonly APIAndreVeiculosMicrosservicosPaymentContext _context;

        public PixTypesController(APIAndreVeiculosMicrosservicosPaymentContext context)
        {
            _context = context;
        }

        // GET: api/PixTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PixType>>> GetPixType()
        {
            if (_context.PixType == null)
            {
                return NotFound();
            }
            return await _context.PixType.ToListAsync();
        }

        // GET: api/PixTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PixType>> GetPixType(int id)
        {
            if (_context.PixType == null)
            {
                return NotFound();
            }
            var pixType = await _context.PixType.FindAsync(id);

            if (pixType == null)
            {
                return NotFound();
            }

            return pixType;
        }

        // PUT: api/PixTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPixType(int id, PixType pixType)
        {
            if (id != pixType.Id)
            {
                return BadRequest();
            }

            _context.Entry(pixType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PixTypeExists(id))
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

        // POST: api/PixTypes
        [HttpPost]
        public async Task<ActionResult<PixType>> PostPixType(PixTypeDTO pixTypeDTO)
        {
            if (_context.PixType == null)
            {
                return Problem("Entity set 'APIAndreVeiculosMicrosservicosPaymentContext.PixType'  is null.");
            }
            PixType pixType = new(pixTypeDTO);
            pixType.Description = pixTypeDTO.PixDescription;
            _context.PixType.Add(pixType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPixType", new { id = pixType.Id }, pixType);
        }

        // DELETE: api/PixTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePixType(int id)
        {
            if (_context.PixType == null)
            {
                return NotFound();
            }
            var pixType = await _context.PixType.FindAsync(id);
            if (pixType == null)
            {
                return NotFound();
            }

            _context.PixType.Remove(pixType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PixTypeExists(int id)
        {
            return (_context.PixType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}