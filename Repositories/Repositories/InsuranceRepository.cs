using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using Models.DTO;
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
        public async Task<List<InsuranceDTO>> GetAllInsurances()
        {
            List<InsuranceDTO> insurances = new();
            try
            {
                using (var db = new SqlConnection(Conn))
                {
                    db.Open();
                    var query = await db.QueryAsync<InsuranceDTO>(Insurance.GETALL);
                    foreach (var insurance in query)
                    {
                        insurances.Add(insurance);
                    }
                    db.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return insurances;
        }

        public async Task<InsuranceDTO> GetInsurance(int Id)
        {
            InsuranceDTO insurance = new();
            try
            {
                using (var db = new SqlConnection(Conn))
                {
                    db.Open();
                    var query = await db.QueryAsync<InsuranceDTO>(Insurance.GETONE, new { Id });
                    insurance = query.FirstOrDefault();
                    
                    db.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return insurance;
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