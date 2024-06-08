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

        public List<Employee> GetAllEmployees(byte type)
        {
            return _employeeRepository.GetAllEmployees(type);
        }
    }
}
