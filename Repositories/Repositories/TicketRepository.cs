using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;

namespace Repositories.Repositories
{
    public class TicketRepository
    {
        private string Conn { get; set; }
        public TicketRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }
        public async Task<List<Ticket>> GetAllTickets(byte type)
        {
            List<Ticket> tickets = new();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                //ADO
                if (type == 1)
                {
                    var cmd = new SqlCommand(Ticket.GETALL, db);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tickets.Add(new Ticket
                            {
                                Id = reader.GetInt32(0),
                                Number = reader.GetInt32(1),
                                ExpirationDate = reader.GetDateTime(2)
                            });
                        }
                    }
                }
                //DAPPER
                else if (type == 2)
                {
                    var query = db.Query(Ticket.GETALL);
                    foreach (var ticket in query)
                    {
                        tickets.Add(new Ticket
                        {
                            Id = ticket.Id,
                            Number = ticket.Number,
                            ExpirationDate = ticket.ExpirationDate
                        });
                    }
                }
                db.Close();
            }
            return tickets;
        }
    }
}