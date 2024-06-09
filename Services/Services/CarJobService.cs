using Models;
using Repositories.Repositories_DAPPER;

namespace Services.Services_DAPPER
{
    public class CarJobService
    {
        private CarJobRepository _carJobRepository;

        public CarJobService()
        {
            _carJobRepository = new CarJobRepository();
        }

        public async Task<List<CarJob>> GetAllCarJobs(byte type)
        {
            return await _carJobRepository.GetAllCarJobs(type);
        }
    }
}
