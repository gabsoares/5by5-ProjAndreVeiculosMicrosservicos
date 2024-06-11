﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using ProjAndreVeiculosMicrosservicos.Isurance.Data;

namespace ProjAndreVeiculosMicrosservicos.Isurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancesController : ControllerBase
    {
        private readonly DataApiContext _context;

        public InsurancesController(DataApiContext context)
        {
            _context = context;
        }

        // GET: api/Insurances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Insurance>>> GetInsurance()
        {
          if (_context.Insurance == null)
          {
              return NotFound();
          }
            return await _context.Insurance.ToListAsync();
        }

        // GET: api/Insurances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Insurance>> GetInsurance(int id)
        {
          if (_context.Insurance == null)
          {
              return NotFound();
          }
            var insurance = await _context.Insurance.FindAsync(id);

            if (insurance == null)
            {
                return NotFound();
            }

            return insurance;
        }

        // PUT: api/Insurances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsurance(int id, Insurance insurance)
        {
            if (id != insurance.Id)
            {
                return BadRequest();
            }

            _context.Entry(insurance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceExists(id))
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

        // POST: api/Insurances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Insurance>> PostInsurance(Insurance insurance)
        {
          if (_context.Insurance == null)
          {
              return Problem("Entity set 'ProjAndreVeiculosMicrosservicosIsuranceContext.Insurance'  is null.");
          }
            _context.Insurance.Add(insurance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsurance", new { id = insurance.Id }, insurance);
        }

        // DELETE: api/Insurances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurance(int id)
        {
            if (_context.Insurance == null)
            {
                return NotFound();
            }
            var insurance = await _context.Insurance.FindAsync(id);
            if (insurance == null)
            {
                return NotFound();
            }

            _context.Insurance.Remove(insurance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InsuranceExists(int id)
        {
            return (_context.Insurance?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}