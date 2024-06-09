using Models;
using Repositories.Repositories_DAPPER;

namespace Services.Services_DAPPER
{
    public class EmployeeService
    {
        private EmployeeRepository _employeeRepository;

        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public async Task<List<Employee>> GetAllEmployees(byte type)
        {
            return await _employeeRepository.GetAllEmployees(type);
        }
    }
}
