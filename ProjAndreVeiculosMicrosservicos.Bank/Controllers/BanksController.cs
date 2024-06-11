using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace ProjAndreVeiculosMicrosservicos.Bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private BankService _bankService;

        public BanksController()
        {
            _bankService = new BankService();
        }

        [HttpGet("{cnpj:length(14)}")]
        public Models.Bank GetById(string cnpj)
        {
            return _bankService.GetById(cnpj);
        }

        [HttpPost]
        public Models.Bank Post(Models.Bank bank)
        {
            return _bankService.InsertOne(bank);
        }
        //Inserir com mongo
    }
}