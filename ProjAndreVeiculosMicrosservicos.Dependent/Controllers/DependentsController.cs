using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAndreVeiculosMicrosservicos.Adress.Controllers;
using APIAndreVeiculosMicrosservicos.Adress.Services;
using DataApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using ProjAndreVeiculosMicrosservicos.Dependent.Data;
using Services;
using Services.Services;

namespace ProjAndreVeiculosMicrosservicos.Dependent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependentsController : ControllerBase
    {
        private readonly DataApiContext _context;
        private readonly DependentService _dependentService;
        private readonly AdressService _adressService;
        private readonly AdressesController _adressController;

        public DependentsController(DataApiContext context)
        {
            _context = context;
            _dependentService = new DependentService();
            _adressService = new AdressService();
            _adressController = new AdressesController(context);
        }

        // GET: api/Dependents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Dependent>>> GetDependent()
        {
            if (_context.Dependent == null)
            {
                return NotFound();
            }
            return _dependentService.GetAllDependents();
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

        [HttpPost]
        public async Task<ActionResult<Models.Dependent>> InsertDependent(DependentDTO dependentDTO)
        {
            if (_context.Dependent == null)
            {
                return Problem("Entity set 'APIDependentContext.Dependent'  is null.");
            }

            var customer = _context.Customer.Where(x => x.CPF == dependentDTO.CustomerCPF).FirstOrDefault();
            Models.Dependent dependent = new(dependentDTO);
            if(customer == null)
            {
                return BadRequest("Cliente nao existe");
            }

            var adress = await _adressService.GetAdressData(dependentDTO.Adress.ZipCode, dependentDTO.Adress);
            int adressId = _adressController.PostAdress(dependentDTO.Adress).Result.Value;
            dependent.Customer = customer;
            dependent.Adress = adress;
            dependent.Adress.Id = adressId;

            _dependentService.Insert(dependent);

            return CreatedAtAction("GetDependent", new { id = dependent.CPF }, dependent);
        }

        private bool DependentExists(string id)
        {
            return (_context.Dependent?.Any(e => e.CPF == id)).GetValueOrDefault();
        }
    }
}