using Models.DTO;
using Models;
using Repositories.Repositories;
using Repositories.Repositories_DAPPER;

namespace Services.Services
{
    public class UseTermService
    {
        private UseTermRepository _useTermRepository;

        public UseTermService()
        {
            _useTermRepository = new UseTermRepository();
        }

        public UseTerms InsertOne(UseTerms term)
        {
            return _useTermRepository.InsertOne(term);
        }

        public UseTerms GetById(int id)
        {
            return _useTermRepository.Get(id);
        }
    }
}
