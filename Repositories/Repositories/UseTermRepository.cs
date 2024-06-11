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
    public class UseTermRepository
    {
        private MongoDBConnection _dbConnection;
        private MongoClient _client;
        private IMongoCollection<UseTerms> _term;

        public UseTermRepository()
        {
            _dbConnection = MongoDBConnection.GetInstance();
            _client = _dbConnection.client;
            _term =
                _client.GetDatabase("ProjAndreVeiculos").GetCollection<UseTerms>("UseTerms");
        }

        public UseTerms Get(int id)
        {
            return _term.Find<UseTerms>(term => term.Id == id).FirstOrDefault();
        }

        public UseTerms InsertOne(UseTerms term)
        {
            _term.InsertOne(term);
            return term;
        }
    }
}
