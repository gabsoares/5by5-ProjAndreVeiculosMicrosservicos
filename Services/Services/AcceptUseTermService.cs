using Models;
using Models.DTO;
using Newtonsoft.Json;
using Repositories.Repositories;

namespace Services.Services
{
    public class AcceptUseTermService
    {
        private AcceptUseTermRepository _acceptUseTermRepository;
        private UseTermService _useTermService;

        public AcceptUseTermService()
        {
            _acceptUseTermRepository = new AcceptUseTermRepository();
            _useTermService = new UseTermService();
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
            var customer = JsonConvert.DeserializeObject<Customer>(json);
            var useTerm = _useTermService.GetById(acceptUseTermDTO.UseTermId);
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