using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;

namespace Repositories.Repositories_DAPPER
{
    public class RoleRepository
    {
        private string Conn { get; set; }
        public RoleRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }
        public List<Role> GetAllRoles(byte type)
        {
            List<Role> roles = new();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                //ADO
                if (type == 1)
                {
                    var cmd = new SqlCommand(Role.GETALL, db);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(new Role
                            {
                                Id = reader["Id"] == DBNull.Value ? 0 : (int)reader["Id"],
                                Description = reader["Description"].ToString()
                            });
                        }
                    }
                }
                //DAPPER
                else if (type == 2)
                {
                    var query = db.Query(Role.GETALL);
                    foreach (var role in query)
                    {
                        roles.Add(new Role
                        {
                            Id = role.Id,
                            Description = role.Description
                        });
                    }
                }
                db.Close();
            }
            return roles;
        }
    }
}