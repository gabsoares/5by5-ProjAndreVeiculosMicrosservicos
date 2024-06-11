using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Services.Services;

namespace ProjAndreVeiculosMicrosservicos.AcceptUseTerms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcceptUseTermsController : ControllerBase
    {
        private AcceptUseTermService _termService;

        public AcceptUseTermsController()
        {
            _termService = new AcceptUseTermService();
        }

        [HttpGet("{id}")]
        public Models.AcceptUseTerms GetById(int id)
        {
            return _termService.GetById(id).Result;
        }

        [HttpPost]
        public AcceptUseTermsDTO Post(AcceptUseTermsDTO term)
        {
            return _termService.InsertOne(term);
        }
    }
}