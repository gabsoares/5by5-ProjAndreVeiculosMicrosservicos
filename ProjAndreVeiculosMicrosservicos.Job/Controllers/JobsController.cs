﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIAndreVeiculosMicrosservicos.Job.Data;
using Services.Services_DAPPER;
using DataApi.Data;

namespace APIAndreVeiculosMicrosservicos.Job.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly DataApiContext _context;

        public JobsController(DataApiContext context)
        {
            _context = context;
        }

        // GET: api/Jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Job>>> GetJob(byte techType)
        {
            if (_context.Job == null)
            {
                return NotFound();
            }
            if (techType == 0)
            {
                return await _context.Job.ToListAsync();
            }
            else if (techType == 1)
            {
                return await new JobService().GetAllJobs(1);
            }
            else if (techType == 2)
            {
                return await new JobService().GetAllJobs(2);
            }
            return null;
        }

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Job>> GetJob(int id)
        {
            if (_context.Job == null)
            {
                return NotFound();
            }
            var job = await _context.Job.FindAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        // PUT: api/Jobs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(int id, Models.Job job)
        {
            if (id != job.Id)
            {
                return BadRequest();
            }

            _context.Entry(job).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
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

        // POST: api/Jobs
        [HttpPost]
        public async Task<ActionResult<Models.Job>> PostJob(Models.Job job)
        {
            if (_context.Job == null)
            {
                return Problem("Entity set 'APIAndreVeiculosMicrosservicosJobContext.Job'  is null.");
            }
            _context.Job.Add(job);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJob", new { id = job.Id }, job);
        }

        // DELETE: api/Jobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            if (_context.Job == null)
            {
                return NotFound();
            }
            var job = await _context.Job.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            _context.Job.Remove(job);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobExists(int id)
        {
            return (_context.Job?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}