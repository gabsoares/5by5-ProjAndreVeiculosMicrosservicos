using Azure;
using Models;
using Newtonsoft.Json;
using Repositories.Repositories;

namespace Services.Services
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
            List<Insurance> insuranceList = new();
            var insuranceDTO = await _insuranceRepository.GetAllInsurances();
            var httpClient = new HttpClient();
            foreach (var item in insuranceDTO)
            {
                var responseCustomer = await httpClient.GetAsync($"https://localhost:7033/api/Customers/{item.CustomerCPF}");
                var responseCar = await httpClient.GetAsync($"https://localhost:7055/api/Cars/{item.CarPlate}");
                var responseDriver = await httpClient.GetAsync($"https://localhost:7188/api/Drivers/{item.DriverCPF}");

                var customer = JsonConvert.DeserializeObject<Customer>(await responseCustomer.Content.ReadAsStringAsync());
                var car = JsonConvert.DeserializeObject<Car>(await responseCar.Content.ReadAsStringAsync());
                var driver = JsonConvert.DeserializeObject<Driver>(await responseDriver.Content.ReadAsStringAsync());

                insuranceList.Add(new Insurance
                {
                    Id = item.Id,
                    Car = car,
                    Customer = customer,
                    Franchise = item.Franchise,
                    Driver = driver
                });
            }
            return insuranceList;
        }

        public async Task<Insurance> GetInsurance(int Id)
        {
            var insuranceDTO = await _insuranceRepository.GetInsurance(Id);
            var httpClient = new HttpClient();

            var responseCustomer = await httpClient.GetAsync($"https://localhost:7033/api/Customers/{insuranceDTO.CustomerCPF}");
            var responseCar = await httpClient.GetAsync($"https://localhost:7055/api/Cars/{insuranceDTO.CarPlate}");
            var responseDriver = await httpClient.GetAsync($"https://localhost:7188/api/Drivers/{insuranceDTO.DriverCPF}");

            var customer = JsonConvert.DeserializeObject<Customer>(await responseCustomer.Content.ReadAsStringAsync());
            var car = JsonConvert.DeserializeObject<Car>(await responseCar.Content.ReadAsStringAsync());
            var driver = JsonConvert.DeserializeObject<Driver>(await responseDriver.Content.ReadAsStringAsync());


            return new Insurance
            {
                Id = insuranceDTO.Id,
                Car = car,
                Driver = driver,
                Customer = customer,
                Franchise = insuranceDTO.Franchise
            };
        }

        public async Task<int> InsertInsurance(Insurance insurance)
        {
            return await _insuranceRepository.InsertInsurance(insurance);
        }
    }
}