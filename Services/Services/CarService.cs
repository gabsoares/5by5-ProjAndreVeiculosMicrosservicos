using Models;
using Repositories.Repositories_DAPPER;

namespace Services.Services_DAPPER
{
    public class CarService
    {
        private CarRepository _carRepository;

        public CarService()
        {
            _carRepository = new CarRepository();
        }

        public async Task<List<Car>> GetAllCars(byte type)
        {
            return await _carRepository.GetAllCars(type);
        }
    }
}
