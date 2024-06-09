using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class SaleRepository
    {
        private string Conn { get; set; }
        public SaleRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }
        public async Task<List<Sale>> GetAllSales(byte type)
        {
            List<Sale> sales = new();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                //ADO
                if (type == 1)
                {
                    var cmd = new SqlCommand(Sale.GETALL, db);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sales.Add(new Sale
                            {
                                Id = reader.GetInt32(0),
                                Car = new Car { CarPlate = reader.GetString(3) },
                                SaleDate = reader.GetDateTime(1),
                                SaleValue = reader.GetDecimal(2),
                                Client = new Customer { CPF = reader.GetString(4) },
                                Employee = new Employee { CPF = reader.GetString(5) },
                                Payment = new Payment { Id = reader.IsDBNull(6) ? 0 : reader.GetInt32(6) },
                            });
                        }
                    }
                }
                //DAPPER
                else if (type == 2)
                {
                    var queryResult = db.Query<Sale, Car, Customer, Employee, Payment, Sale>(
                        Sale.GETALL,
                        (sale, car, client, employee, payment) =>
                        {
                            sale.Car = car;
                            sale.Client = client;
                            sale.Employee = employee;
                            sale.Payment = payment ?? new Payment();
                            return sale;
                        },
                        splitOn: "CarPlate, ClientCPF, EmployeeCPF, PaymentId"
                    );

                    foreach (var sale in queryResult)
                    {
                        sales.Add(sale);
                    }
                }
                db.Close();
            }
            return sales;
        }
    }
}