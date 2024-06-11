using Models;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class BankService
    {
        private BankRepository _bankRepository;

        public BankService()
        {
            _bankRepository = new BankRepository();
        }

        public Bank InsertOne(Bank bank)
        {
            return _bankRepository.InsertOne(bank);
        }

        public Bank GetById(string cnpj)
        {
            return _bankRepository.Get(cnpj);
        }
    }
}