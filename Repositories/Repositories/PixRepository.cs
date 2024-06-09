using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;

namespace Repositories.Repositories
{
    public class PixRepository
    {
        private string Conn { get; set; }
        public PixRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }
        public async Task<List<Pix>> GetAllPix(byte type)
        {
            List<Pix> pixes = new();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                //ADO
                if (type == 1)
                {
                    var cmd = new SqlCommand(Pix.GETALL, db);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pixes.Add(new Pix
                            {
                                Id = reader["PixId"] == DBNull.Value ? 0 : (int)reader["PixId"],
                                PixType = new()
                                {
                                    Id = reader["PixTypeId"] == DBNull.Value ? 0 : (int)reader["PixTypeId"],
                                    Description = reader["Description"].ToString()
                                },
                                PixKey = reader["PixKey"].ToString()
                            });
                        }
                    }
                }
                //DAPPER
                else if (type == 2)
                {
                    var query = db.Query<Pix, PixType, Pix>(Pix.GETALLDapper,
                        (pix, pixType) =>
                        {
                            pix.PixType = pixType;
                            return pix;
                        },
                        splitOn:"Id"
                        );
                    foreach (var pix in query)
                    {
                        pixes.Add(pix);
                    }
                }
                db.Close();
            }
            return pixes;
        }
    }
}