using Models;
using Repositories.Repositories_DAPPER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services_DAPPER
{
    public class CustomerService
    {
        private CustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        public async Task<List<Customer>> GetAllCustomers(byte type)
        {
            return await _customerRepository.GetAllCustomers(type);
        }
    }
}
