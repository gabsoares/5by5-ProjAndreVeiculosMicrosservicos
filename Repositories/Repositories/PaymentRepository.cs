using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;

namespace Repositories.Repositories
{
    public class PaymentRepository
    {
        private string Conn { get; set; }
        public PaymentRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public async Task<List<Payment>> GetAllPayments(byte type)
        {
            List<Payment> payments = new();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                //ADO
                if (type == 1)
                {
                    var cmd = new SqlCommand(Payment.GETALL, db);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Payment payment = new();
                            payments.Add(new Payment
                            {
                                Id = reader["Id"] == DBNull.Value ? 0 : (int)reader["Id"],
                                PaymentDate = reader["PaymentDate"] == DBNull.Value ? new DateTime(1900, 01, 01) : (DateTime)reader["PaymentDate"],
                                CreditCard = new()
                                {
                                    Id = reader["CreditCardId"] == DBNull.Value ? 0 : (int)reader["CreditCardId"],
                                    CardNumber = reader["CardNumber"].ToString(),
                                    SecurityCode = reader["SecurityCode"].ToString(),
                                    ExpirationDate = reader["ExpirationDate"] == DBNull.Value ? new DateTime(1900, 01, 01) : (DateTime)reader["ExpirationDate"],
                                    CardHolderName = reader["CardHolderName"].ToString()
                                },
                                Ticket = new()
                                {
                                    Id = reader["TicketId"] == DBNull.Value ? 0 : (int)reader["TicketId"],
                                    Number = reader["Number"] == DBNull.Value ? 0 : (int)reader["Number"],
                                    ExpirationDate = reader["ExpirationDate"] == DBNull.Value ? new DateTime(1900, 01, 01) : (DateTime)reader["ExpirationDate"],
                                },
                                Pix = new()
                                {
                                    Id = reader["PixId"] == DBNull.Value ? 0 : (int)reader["PixId"],
                                    PixKey = reader["PixKey"].ToString(),
                                    PixType = new()
                                    {
                                        Id = reader["PixTypeId"] == DBNull.Value ? 0 : (int)reader["PixTypeId"],
                                        Description = reader["Description"].ToString()
                                    }
                                }
                            });
                        }
                    }
                }
                //DAPPER
                else if (type == 2)
                {
                    var query = db.Query<Payment, CreditCard, Ticket, Pix, PixType, Payment>(Payment.GETALLDapper,
                        (payment, creditCard, ticket, pix, pixType) =>
                        {
                            payment.CreditCard = creditCard;
                            payment.Ticket = ticket;
                            payment.Pix = pix;
                            if (payment.Pix != null)
                            {
                                payment.Pix.PixType = pixType;
                            }
                            return payment;
                        },
                        splitOn: "Id, Id, Id, Id"
                        ).ToList();
                    foreach (var payment in query)
                    {
                        payments.Add(payment);
                    }
                }
                db.Close();
            }
            return payments;
        }
    }
}