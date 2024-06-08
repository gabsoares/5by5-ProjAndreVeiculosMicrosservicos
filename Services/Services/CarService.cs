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

        public List<Car> GetAllCars(byte type)
        {
            return _carRepository.GetAllCars(type);
        }
    }
}
