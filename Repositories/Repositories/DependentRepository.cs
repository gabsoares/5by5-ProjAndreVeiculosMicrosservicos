using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;
using System.Reflection.Emit;

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

        public List<Dependent> GetAllDependents()
        {
            List<Dependent> dependents = new();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                var cmd = new SqlCommand { Connection = db };

                cmd.CommandText = "SELECT [d].[CPF], [d].[AdressId], [d].[CustomerCPF], [d].[DateOfBirth], [d].[Email], [d].[Name], [d].[Phone], [c].[CPF], [c].[AdressId], [c].[DateOfBirth], [c].[Email], [c].[Income], [c].[Name], [c].[PDFDocument], [c].[Phone], [a].[Id], [a].[City], [a].[Complement], [a].[District], [a].[Number], [a].[PublicPlace], [a].[UF], [a].[ZipCode] FROM [Dependent] AS[d] LEFT JOIN[Customer] AS [c] ON [d].[CustomerCPF] = [c].[CPF] LEFT JOIN [Adress] AS[a] ON[d].[AdressId] = [a].[Id]";

                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dependents.Add(new Dependent
                        {
                            CPF = reader.GetString(0),
                            Adress = new()
                            {
                                Id = reader.GetInt32(1),
                                City = reader.GetString(16),
                                Complement = reader.GetString(17),
                                District = reader.GetString(18),
                                Number = reader.GetInt32(19),
                                PublicPlace = reader.GetString(20),
                                UF = reader.GetString(21),
                                ZipCode = reader.GetString(22)
                            },
                            Customer = new()
                            {
                                CPF = reader.GetString(2),
                                Adress = new()
                                {
                                    Id = reader.GetInt32(8)
                                },
                                DateOfBirth = reader.GetDateTime(9),
                                Email = reader.GetString(10),
                                Income = reader.GetDecimal(11),
                                Name = reader.GetString(12),
                                PDFDocument = reader.GetString(13),
                                Phone = reader.GetString(14)

                            },
                            DateOfBirth = reader.GetDateTime(3),
                            Email = reader.GetString(4),
                            Name = reader.GetString(5),
                            Phone = reader.GetString(6),
                        });
                    }
                }
                db.Close();
            }
            return dependents;
        }
    }
}