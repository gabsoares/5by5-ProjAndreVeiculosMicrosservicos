using DataApi.Services;
using Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// oi, André!!
namespace Repositories.Repositories
{
    public class BankRepository
    {
        private MongoDBConnection _dbConnection;
        private MongoClient _client;
        private IMongoCollection<Bank> _bank;

        public BankRepository()
        {
            _dbConnection = MongoDBConnection.GetInstance();
            _client = _dbConnection.client;
            _bank =
                _client.GetDatabase("ProjAndreVeiculos").GetCollection<Bank>("Bank");
        }

        public Bank Get(string cnpj)
        {
            return _bank.Find<Bank>(bank => bank.CNPJ == cnpj).FirstOrDefault();
        }

        public Bank InsertOne(Bank bank)
        {
            _bank.InsertOne(bank);
            return bank;
        }

    }
}
