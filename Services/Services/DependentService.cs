using Models;
using Models.DTO;
using Newtonsoft.Json;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DependentService
    {
        private DependentRepository _dependentRepository;

        public DependentService()
        {
            _dependentRepository = new DependentRepository();
        }

        public string Insert(Dependent dependent)
        {
            return _dependentRepository.Insert(dependent);
        }

        public async Task<List<Dependent>> GetAllDependents()
        {
            List<Dependent> dependents = new();
            var httpClient = new HttpClient();
            List<DependentDTO> dependentsDTO = await _dependentRepository.GetAllDependents();
            foreach (var itemDTO in dependentsDTO)
            {
                var responseCustomer = await httpClient.GetAsync($"https://localhost:7033/api/Customers/{itemDTO.CustomerCPF}");
                var responseAddress = await httpClient.GetAsync($"https://localhost:7042/api/Adresses/{itemDTO.Adress.Id}");
                var customer = JsonConvert.DeserializeObject<Customer>(await responseCustomer.Content.ReadAsStringAsync());
                var address = JsonConvert.DeserializeObject<Adress>(await responseAddress.Content.ReadAsStringAsync());

                dependents.Add(new Dependent
                {
                    CPF = itemDTO.DependentCPF,
                    Name = itemDTO.Name,
                    Adress = address,
                    Customer = customer,
                    DateOfBirth = itemDTO.DateOfBirth,
                    Email = itemDTO.Email,
                    Phone = itemDTO.Phone
                });
            }
            return dependents;
        }

        public async Task<Dependent> GetDependent(string Id)
        {
            DependentDTO dependentDTO = await _dependentRepository.GetDependent(Id);
            var httpClient = new HttpClient();
            var responseCustomer = await httpClient.GetAsync($"https://localhost:7033/api/Customers/{dependentDTO.CustomerCPF}");
            var responseAddress = await httpClient.GetAsync($"https://localhost:7042/api/Adresses/{dependentDTO.Adress.Id}");
            var customer = JsonConvert.DeserializeObject<Customer>(await responseCustomer.Content.ReadAsStringAsync());
            var address = JsonConvert.DeserializeObject<Adress>(await responseAddress.Content.ReadAsStringAsync());

            return new Dependent
            {
                CPF = dependentDTO.DependentCPF,
                Name = dependentDTO.Name,
                Adress = address,
                Customer = customer,
                DateOfBirth = dependentDTO.DateOfBirth,
                Email = dependentDTO.Email,
                Phone = dependentDTO.Phone
            };
        }
    }
}