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
    public class PixTypeRepository
    {
        private string Conn { get; set; }
        public PixTypeRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }
        public async Task<List<PixType>> GetAllPixTypes(byte type)
        {
            List<PixType> pixTypes = new();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                //ADO
                if (type == 1)
                {
                    var cmd = new SqlCommand(PixType.GETALL, db);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pixTypes.Add(new PixType
                            {
                                Id = reader.GetInt32(0),
                                Description = reader.GetString(1)
                            });
                        }
                    }
                }
                //DAPPER
                else if (type == 2)
                {
                    var query = db.Query(PixType.GETALL);
                    foreach (var pixType in query)
                    {
                        pixTypes.Add(new PixType
                        {
                            Id = pixType.Id,
                            Description = pixType.Description
                        });
                    }
                }
                db.Close();
            }
            return pixTypes;
        }
    }
}
