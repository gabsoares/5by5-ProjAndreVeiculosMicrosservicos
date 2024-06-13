using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Collections.Generic;
using System.Configuration;

namespace Repositories.Repositories
{
    public class InsuranceRepository
    {
        private string Conn { get; set; }
        public InsuranceRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }
        public async Task<List<Insurance>> GetAllInsurances()
        {
            List<Insurance> insurances = new();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                var query = db.Query(Insurance.GETALL);
                foreach (var insurance in query)
                {
                    insurances.Add(new Insurance
                    {
                        Id = insurance.Id,
                        Car = insurance.Car,
                        Customer = insurance.Customer,
                        Driver = insurance.Driver,
                        Franchise = insurance.Franchise
                    });
                }
                db.Close();
            }
            return insurances;
        }

        public async Task<int> InsertInsurance(Insurance insurance)
        {
            int insuranceId;
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                insuranceId = db.ExecuteScalar<int>(Insurance.INSERT,
                    new
                    {
                        CustomerCPF = insurance.Customer.CPF,
                        Franchise = insurance.Franchise,
                        CarPlate = insurance.Car.CarPlate,
                        DriverCPF = insurance.Driver.CPF
                    });
                db.Close();
            }
            return insuranceId;
        }
    }
}