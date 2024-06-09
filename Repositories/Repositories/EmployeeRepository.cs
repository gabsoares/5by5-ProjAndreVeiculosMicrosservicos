using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;

namespace Repositories.Repositories_DAPPER
{
    public class EmployeeRepository
    {
        private string Conn { get; set; }
        public EmployeeRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public async Task<List<Employee>> GetAllEmployees(byte type)
        {
            List<Employee> employees = new();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                //ADO
                if (type == 1)
                {
                    var cmd = new SqlCommand(Employee.GETALL, db);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee customer = new();
                            employees.Add(new Employee
                            {
                                CPF = reader["CPF"].ToString(),
                                Comission = (Decimal)reader["Comission"],
                                ComissionValue = (Decimal)reader["ComissionValue"],
                                Role = new Role
                                {
                                    Id = reader["RoleId"] == DBNull.Value ? 0 : (int)reader["RoleId"],
                                    Description = reader["Description"].ToString()
                                },
                                Name = reader["Name"].ToString(),
                                DateOfBirth = (DateTime)reader["DateOfBirth"],
                                Phone = reader["Phone"].ToString(),
                                Email = reader["Email"].ToString(),
                                Adress = new Adress
                                {
                                    Id = reader["AdressId"] == DBNull.Value ? 0 : (int)reader["AdressId"],
                                    PublicPlace = reader["PublicPlace"].ToString(),
                                    ZipCode = reader["ZipCode"].ToString(),
                                    District = reader["District"].ToString(),
                                    Complement = reader["Complement"].ToString(),
                                    Number = reader["Number"] == DBNull.Value ? 0 : (int)reader["Number"],
                                    UF = reader["UF"].ToString(),
                                    City = reader["City"].ToString()
                                }
                            });
                        }
                    }
                }
                //DAPPER
                else if (type == 2)
                {
                    var query = db.Query<Employee, Role, Adress, Employee>(Employee.GETALLDapper,
                        (employee, role, adress) =>
                        {
                            employee.Role = role;
                            employee.Adress = adress;
                            return employee;
                        },
                        splitOn: "Id, Id"
                        ).ToList();
                    foreach (var customer in query)
                    {
                        employees.Add(customer);
                    }
                }
                db.Close();
            }
            return employees;
        }
    }
}
