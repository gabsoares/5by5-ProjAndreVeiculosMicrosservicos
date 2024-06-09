using System.Configuration;
using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using Models.DTO;

namespace Repositories.Repositories_DAPPER
{
    public class AdressRepository
    {
        private string Conn { get; set; }
        public AdressRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }
        public async Task<List<Adress>> GetAllAdresses(byte type)
        {
            List<Adress> adresses = new();
            AdressDTO a = new();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                //ADO
                if (type == 1)
                {
                    var cmd = new SqlCommand(Adress.GETALL, db);
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                adresses.Add(new Adress
                                {
                                    Id = (int)reader["Id"],
                                    PublicPlace = reader["PublicPlace"].ToString(),
                                    ZipCode = reader["ZipCode"].ToString(),
                                    District = reader["District"].ToString(),
                                    Complement = reader["Complement"].ToString(),
                                    Number = (int)reader["Number"],
                                    UF = reader["UF"].ToString(),
                                    City = reader["City"].ToString(),
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
                //DAPPER
                else if (type == 2)
                {
                    var query = db.Query(Adress.GETALL);
                    foreach (var adress in query)
                    {
                        adresses.Add(new Adress
                        {
                            Id = adress.Id,
                            PublicPlace = adress.PublicPlace,
                            ZipCode = adress.ZipCode,
                            District = adress.District,
                            Complement = adress.Complement,
                            Number = adress.Number,
                            UF = adress.UF,
                            City = adress.City,
                        });
                    }
                }
                db.Close();
            }
            return adresses;
        }
    }
}