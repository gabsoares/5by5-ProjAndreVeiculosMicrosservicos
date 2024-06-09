using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;

namespace Repositories.Repositories_DAPPER
{
    public class CarJobRepository
    {
        private string Conn { get; set; }
        public CarJobRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }
        public async Task<List<CarJob>> GetAllCarJobs(byte type)
        {
            List<CarJob> carJobs = new();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                //ADO
                if (type == 1)
                {
                    var cmd = new SqlCommand(CarJob.GETALL, db);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CarJob carJob = new();
                            carJobs.Add(new CarJob
                            {
                                Id = (int)reader["Id"],
                                Car = new Car()
                                {
                                    CarPlate = reader["CarPlate"].ToString(),
                                    CarColor = reader["CarColor"].ToString(),
                                    CarName = reader["CarName"].ToString(),
                                    ModelYear = (int)reader["ModelYear"],
                                    FabricationYear = (int)reader["FabricationYear"],
                                    IsSold = (bool)reader["IsSold"]
                                },
                                Job = new Job()
                                {
                                    Id = (int)reader["Id"],
                                    Description = reader["Description"].ToString()
                                },
                                Status = (bool)reader["Status"],
                            });
                        }
                    }
                }
                //DAPPER
                else if (type == 2)
                {
                    var query = db.Query<CarJob, Car, Job, CarJob>(CarJob.GETALL,
                        (carJob, car, job) =>
                        {
                            carJob.Car = car;
                            carJob.Job = job;
                            return carJob;
                        },
                        splitOn: "CarPlate, Id"
                        ).ToList();
                    foreach (var carJob in query)
                    {
                        carJobs.Add(carJob);
                    }
                }
                db.Close();
            }
            return carJobs;
        }
    }
}