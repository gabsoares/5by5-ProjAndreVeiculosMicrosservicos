using DataApi.Services;
using Models;
using Models.DTO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class AcceptUseTermRepository
    {
        private MongoDBConnection _dbConnection;
        private MongoClient _client;
        private IMongoCollection<AcceptUseTermsDTO> _term;

        public AcceptUseTermRepository()
        {
            _dbConnection = MongoDBConnection.GetInstance();
            _client = _dbConnection.client;
            _term =
                _client.GetDatabase("ProjAndreVeiculos").GetCollection<AcceptUseTermsDTO>("AcceptUseTerms");
        }

        public AcceptUseTermsDTO Get(int id)
        {
            return _term.Find<AcceptUseTermsDTO>(term => term.Id == id).FirstOrDefault();
        }

        public AcceptUseTermsDTO InsertOne(AcceptUseTermsDTO term)
        {
            _term.InsertOne(term);
            return term;
        }

    }
}
