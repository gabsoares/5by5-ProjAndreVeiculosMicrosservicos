﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIAndreVeiculosMicrosservicos.CarJob.Data;
using Models;
using Models.DTO;

namespace APIAndreVeiculosMicrosservicos.CarJob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarJobsController : ControllerBase
    {
        private readonly APIAndreVeiculosMicrosservicosCarJobContext _context;

        public CarJobsController(APIAndreVeiculosMicrosservicosCarJobContext context)
        {
            _context = context;
        }

        // GET: api/CarJobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.CarJob>>> GetCarJob()
        {
            if (_context.CarJob == null)
            {
                return NotFound();
            }
            return await _context.CarJob.ToListAsync();
        }

        // GET: api/CarJobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.CarJob>> GetCarJob(int id)
        {
            if (_context.CarJob == null)
            {
                return NotFound();
            }
            var carJob = await _context.CarJob.FindAsync(id);

            if (carJob == null)
            {
                return NotFound();
            }

            return carJob;
        }

        // PUT: api/CarJobs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarJob(int id, Models.CarJob carJob)
        {
            if (id != carJob.Id)
            {
                return BadRequest();
            }

            _context.Entry(carJob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarJobExists(id))
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

        // POST: api/CarJobs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.CarJob>> PostCarJob(CarJobDTO carJobDTO)
        {
            if (_context.CarJob == null)
            {
                return Problem("Entity set 'APIAndreVeiculosMicrosservicosCarJobContext.CarJob'  is null.");
            }

            Models.CarJob carJob = new Models.CarJob(carJobDTO);
            carJob.Car = await _context.Car.FindAsync(carJobDTO.CarPlate);
            carJob.Job = await _context.Job.FindAsync(carJobDTO.JobId);

            _context.CarJob.Add(carJob);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarJob", new { id = carJob.Id }, carJob);
        }

        // DELETE: api/CarJobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarJob(int id)
        {
            if (_context.CarJob == null)
            {
                return NotFound();
            }
            var carJob = await _context.CarJob.FindAsync(id);
            if (carJob == null)
            {
                return NotFound();
            }

            _context.CarJob.Remove(carJob);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarJobExists(int id)
        {
            return (_context.CarJob?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}