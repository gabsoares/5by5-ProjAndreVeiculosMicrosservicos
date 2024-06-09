using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;

namespace Repositories.Repositories_DAPPER
{
    public class CarRepository
    {
        private string Conn { get; set; }
        public CarRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }
        public async Task<List<Car>> GetAllCars(byte type)
        {
            List<Car> cars = new();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                //ADO
                if (type == 1)
                {
                    var cmd = new SqlCommand(Car.GETALL, db);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cars.Add(new Car
                            {
                                CarPlate = reader["CarPlate"].ToString(),
                                CarName = reader["CarName"].ToString(),
                                ModelYear = (int)reader["ModelYear"],
                                FabricationYear = (int)reader["FabricationYear"],
                                CarColor = reader["CarColor"].ToString(),
                                IsSold = (bool)reader["IsSold"]
                            });
                        }
                    }
                }
                //DAPPER
                else if (type == 2)
                {
                    var query = db.Query(Car.GETALL);
                    foreach (var car in query)
                    {
                        cars.Add(new Car
                        {
                            CarPlate = car.CarPlate,
                            CarName = car.CarName,
                            ModelYear = car.ModelYear,
                            FabricationYear = car.FabricationYear,
                            CarColor = car.CarColor,
                            IsSold = car.IsSold,
                        });
                    }
                }
                db.Close();
            }
            return cars;
        }
    }
}