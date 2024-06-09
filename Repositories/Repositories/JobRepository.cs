using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;

namespace Repositories.Repositories_DAPPER
{
    public class JobRepository
    {
        private string Conn { get; set; }
        public JobRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }
        public async Task<List<Job>> GetAllJobs(byte type)
        {
            List<Job> jobs = new();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                //ADO
                if (type == 1)
                {
                    var cmd = new SqlCommand(Job.GETALL, db);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            jobs.Add(new Job
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
                    var query = db.Query(Job.GETALL);
                    foreach (var job in query)
                    {
                        jobs.Add(new Job
                        {
                            Id = job.Id,
                            Description = job.Description
                        });
                    }
                }
                db.Close();
            }
            return jobs;
        }
    }
}
