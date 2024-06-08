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

        public List<CarJob> GetAllCarJobs(byte type)
        {
            return _carJobRepository.GetAllCarJobs(type);
        }
    }
}
