using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;

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
    }
}