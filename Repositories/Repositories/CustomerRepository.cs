using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;

namespace Repositories.Repositories_DAPPER
{
    public class CustomerRepository
    {
        private string Conn { get; set; }
        public CustomerRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public async Task<List<Customer>> GetAllCustomers(byte type)
        {
            List<Customer> customers = new();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                //ADO
                if (type == 1)
                {
                    var cmd = new SqlCommand(Customer.GETALL, db);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new();
                            customers.Add(new Customer
                            {
                                CPF = reader["CPF"].ToString(),
                                Income = (Decimal)reader["Income"],
                                PDFDocument = reader["PDFDocument"].ToString(),
                                Name = reader["Name"].ToString(),
                                DateOfBirth = (DateTime)reader["DateOfBirth"],
                                Phone = reader["Phone"].ToString(),
                                Email = reader["Email"].ToString(),
                                Adress = new Adress
                                {
                                    Id = reader["Id"] == DBNull.Value ? 0 : (int)reader["Id"],
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
                    var query = db.Query<Customer, Adress, Customer>(Customer.GETALL,
                        (customer, adress) =>
                        {
                            customer.Adress = adress;
                            return customer;
                        },
                        splitOn: "Id"
                        ).ToList();
                    foreach (var customer in query)
                    {
                        customers.Add(customer);
                    }
                }
                db.Close();
            }
            return customers;
        }

        public async Task<Customer?> GetCustomerById(string cpf)
        {
            Customer customer = new();
            //DAPPER
            using (var db = new SqlConnection(Conn))
            {
                db.Open();

                var query = await db.QueryAsync<Customer, Adress, Customer>(Customer.GETONE, (customer, adress) =>
                    {
                        customer.Adress = adress;
                        return customer;
                    }, new {Cpf = cpf}, splitOn: "Id");

                db.Close();
                return query.FirstOrDefault<Customer>();
            }
        }
    }
}