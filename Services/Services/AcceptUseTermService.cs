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
            _useTermRepository = new UseTermRepository();
        }

        public AcceptUseTermsDTO InsertOne(AcceptUseTermsDTO term)
        {
            return _acceptUseTermRepository.InsertOne(term);
        }

        public async Task<AcceptUseTerms> GetById(int id)
        {
            var acceptUseTermDTO = _acceptUseTermRepository.Get(id);
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://localhost:7033/api/Customers/{acceptUseTermDTO.CustomerCPF}");

            string json = await response.Content.ReadAsStringAsync();
            Customer customer = JsonConvert.DeserializeObject<Customer>(json);

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