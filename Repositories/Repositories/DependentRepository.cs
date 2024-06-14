using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;
using System.Reflection.Emit;
using Models.DTO;
using Dapper;

namespace Repositories.Repositories
{
    public class DependentRepository
    {
        private string Conn { get; set; }
        public DependentRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public string Insert(Dependent dependent)
        {
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                var cmd = new SqlCommand { Connection = db };
                cmd.CommandText = "INSERT INTO dbo.Dependent (CPF, Name, DateOfBirth, AdressId, Phone, Email, CustomerCPF) VALUES (@CPF, @Name, @DateOfBirth, @AdressId, @Phone, @Email, @CustomerCPF)";
                cmd.Parameters.Add("@CPF", sqlDbType: System.Data.SqlDbType.NVarChar).Value = dependent.CPF;
                cmd.Parameters.Add("@Name", sqlDbType: System.Data.SqlDbType.NVarChar).Value = dependent.Name;
                cmd.Parameters.Add("@DateOfBirth", sqlDbType: System.Data.SqlDbType.DateTime).Value = dependent.DateOfBirth;
                cmd.Parameters.Add("@AdressId", sqlDbType: System.Data.SqlDbType.Int).Value = dependent.Adress.Id;
                cmd.Parameters.Add("@Phone", sqlDbType: System.Data.SqlDbType.NVarChar).Value = dependent.Phone;
                cmd.Parameters.Add("@Email", sqlDbType: System.Data.SqlDbType.NVarChar).Value = dependent.Email;
                cmd.Parameters.Add("@CustomerCPF", sqlDbType: System.Data.SqlDbType.NVarChar).Value = dependent.Customer.CPF;
                cmd.ExecuteNonQuery();
                db.Close();
            }
            return dependent.CPF;
        }

        public async Task<List<DependentDTO>> GetAllDependents()
        {
            List<DependentDTO> dependents = new();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                var cmd = new SqlCommand { Connection = db };

                cmd.CommandText = "SELECT CPF, Name, DateOfBirth, AdressId, Phone, Email, CustomerCPF FROM dbo.Dependent";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dependents.Add(new DependentDTO
                        {
                            DependentCPF = reader.GetString(0),
                            Name = reader.GetString(1),
                            DateOfBirth = reader.GetDateTime(2),
                            Adress = new AdressDTO { Id = reader.GetInt32(3) },
                            Phone = reader.GetString(4),
                            Email = reader.GetString(5),
                            CustomerCPF = reader.GetString(6)
                        });
                    }
                }
                db.Close();
            }
            return dependents;
        }

        public async Task<DependentDTO> GetDependent(string DependentCPF)
        {
            try
            {
                using (var db = new SqlConnection(Conn))
                {
                    db.Open();
                    var cmd = new SqlCommand { Connection = db };
                    cmd.CommandText = "SELECT CPF, Name, DateOfBirth, AdressId, Phone, Email, CustomerCPF FROM dbo.Dependent WHERE CPF = @DependentCPF";
                    cmd.Parameters.AddWithValue("@DependentCPF", DependentCPF);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new DependentDTO
                            {
                                DependentCPF = reader.GetString(0),
                                Name = reader.GetString(1),
                                DateOfBirth = reader.GetDateTime(2),
                                Adress = new AdressDTO { Id = reader.GetInt32(3) },
                                Phone = reader.GetString(4),
                                Email = reader.GetString(5),
                                CustomerCPF = reader.GetString(6)
                            };
                        }
                        db.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
    }
}