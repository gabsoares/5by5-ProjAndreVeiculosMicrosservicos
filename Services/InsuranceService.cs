using Models;
using Repositories.Repositories;

namespace Services
{
    public class InsuranceService
    {
        private InsuranceRepository _insuranceRepository;

        public InsuranceService()
        {
            _insuranceRepository = new InsuranceRepository();
        }

        public async Task<List<Insurance>> GetAllInsurances()
        {
            return await _insuranceRepository.GetAllInsurances();
        }

        public async Task<int> InsertInsurance(Insurance insurance)
        {
            return await _insuranceRepository.InsertInsurance(insurance);
        }
    }
}