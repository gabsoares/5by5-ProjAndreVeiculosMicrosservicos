using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using ProjAndreVeiculosMicrosservicos.Dependent.Data;

namespace ProjAndreVeiculosMicrosservicos.Dependent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependentsController : ControllerBase
    {
        private readonly DataApiContext _context;

        public DependentsController(DataApiContext context)
        {
            _context = context;
        }

        // GET: api/Dependents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Dependent>>> GetDependent()
        {
          if (_context.Dependent == null)
          {
              return NotFound();
          }
            
        }

        // GET: api/Dependents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Dependent>> GetDependent(string id)
        {
          if (_context.Dependent == null)
          {
              return NotFound();
          }
            var dependent = await _context.Dependent.FindAsync(id);

            if (dependent == null)
            {
                return NotFound();
            }

            return dependent;
        }

        private bool DependentExists(string id)
        {
            return (_context.Dependent?.Any(e => e.CPF == id)).GetValueOrDefault();
        }
    }
}
