using Models;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CreditCardService
    {
        private CreditCardRepository _creditCardRepository;

        public CreditCardService()
        {
            _creditCardRepository = new CreditCardRepository();
        }

        public async Task<List<CreditCard>> GetAllCreditCards(byte type)
        {
            return await _creditCardRepository.GetAllCreditCards(type);
        }
    }
}
