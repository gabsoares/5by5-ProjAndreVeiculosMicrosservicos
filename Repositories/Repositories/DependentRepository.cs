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

        public Dependent Insert(Dependent dependent)
        {
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                using (var cmd = new SqlCommand("INSERT INTO dbo.Dependent (CPF, Name, DateOfBirth, AdressId, Phone, Email) VALUES (@CPF, @Name, @DateOfBirth, @Phone, @email", db))
                {
                    cmd.Parameters.Add("@CPF", sqlDbType: System.Data.SqlDbType.NVarChar).Value = dependent.CPF;
                    cmd.Parameters.Add("@Name", sqlDbType: System.Data.SqlDbType.NVarChar).Value = dependent.Name;
                    cmd.Parameters.Add("@DateOfBirth", sqlDbType: System.Data.SqlDbType.DateTime).Value = dependent.DateOfBirth;
                    cmd.Parameters.Add("@Phone", sqlDbType: System.Data.SqlDbType.NVarChar).Value = dependent.Phone;
                    cmd.Parameters.Add("@Email", sqlDbType: System.Data.SqlDbType.NVarChar).Value = dependent.Email;
                }
                db.Close();
            }
            return dependent;
        }
    }
}