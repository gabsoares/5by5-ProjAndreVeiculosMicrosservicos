using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;

namespace Repositories.Repositories
{
    public class PurchaseRepository
    {
        private string Conn { get; set; }
        public PurchaseRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }
        public async Task<List<Purchase>> GetAllPurchases(byte type)
        {
            List<Purchase> purchases = new();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                //ADO
                if (type == 1)
                {
                    var cmd = new SqlCommand(Purchase.GETALL, db);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            purchases.Add(new Purchase
                            {
                                Id = (int)reader["Id"],
                                Price = (Decimal)reader["Price"],
                                PurchaseDate = (DateTime)reader["PurchaseDate"],
                                Car = new Car()
                                {
                                    CarPlate = reader["CarPlate"].ToString(),
                                    CarColor = reader["CarColor"].ToString(),
                                    CarName = reader["CarName"].ToString(),
                                    ModelYear = (int)reader["ModelYear"],
                                    FabricationYear = (int)reader["FabricationYear"],
                                    IsSold = (bool)reader["IsSold"]
                                }
                            });
                        }
                    }
                }
                //DAPPER
                else if (type == 2)
                {
                    var query = db.Query<Purchase, Car, Purchase>(Purchase.GETALLDapper,
                        (purchase, car) =>
                        {
                            purchase.Car = car;
                            return purchase;
                        },
                        splitOn: "CarPlate"
                        );
                    foreach (var purchase in query)
                    {
                        purchases.Add(purchase);
                    }
                }
                db.Close();
            }
            return purchases;
        }
    }
}