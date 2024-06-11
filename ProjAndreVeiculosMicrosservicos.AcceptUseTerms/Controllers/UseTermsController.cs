using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services.Services;

namespace ProjAndreVeiculosMicrosservicos.AcceptUseTerms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseTermsController : ControllerBase
    {
        private UseTermService _termService;

        public UseTermsController()
        {
            _termService = new UseTermService();
        }

        [HttpGet("{id}")]
        public Models.UseTerms GetById(int id)
        {
            return _termService.GetById(id);
        }

        [HttpPost]
        public Models.UseTerms Post(Models.UseTerms term)
        {
            return _termService.InsertOne(term);
        }
    }
}