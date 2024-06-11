using Models;
using Models.DTO;
using Newtonsoft.Json;
using Repositories.Repositories;
using Repositories.Repositories_DAPPER;
using System.Drawing.Text;
using System.Text.Json.Serialization;

namespace Services.Services
{
    public class AcceptUseTermService
    {
        private AcceptUseTermRepository _acceptUseTermRepository;
        private UseTermRepository _useTermRepository;

        public AcceptUseTermService()
        {
            _acceptUseTermRepository = new AcceptUseTermRepository();
        }

        public AcceptUseTermsDTO InsertOne(AcceptUseTermsDTO term)
        {
            return _acceptUseTermRepository.InsertOne(term);
        }

        public async Task<AcceptUseTerms> GetById(int id)
        {
            var acceptUseTermDTO = _acceptUseTermRepository.Get(id);
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost:5000/Customer/{acceptUseTermDTO.CustomerCPF}");

            var customer = JsonConvert.DeserializeObject<Customer>(response.Content.ToString());

            var useTerm = _useTermRepository.Get(id);
            return new AcceptUseTerms
            {
                Id = id,
                Customer = customer,
                UseTerms = useTerm,
                AgreeDate = acceptUseTermDTO.AgreeDate
            };
        }
    }
}