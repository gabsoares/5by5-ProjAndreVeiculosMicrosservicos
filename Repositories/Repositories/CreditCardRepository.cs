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
    public class CreditCardRepository
    {
        private string Conn { get; set; }
        public CreditCardRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }
        public async Task<List<CreditCard>> GetAllCreditCards(byte type)
        {
            List<CreditCard> creditCards = new();
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                //ADO
                if (type == 1)
                {
                    var cmd = new SqlCommand(CreditCard.GETALL, db);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            creditCards.Add(new CreditCard
                            {
                                Id = reader.GetInt32(0),
                                CardNumber = reader.GetString(1),
                                SecurityCode = reader.GetString(2),
                                ExpirationDate = reader.GetDateTime(3),
                                CardHolderName = reader.GetString(4)
                            });
                        }
                    }
                }
                //DAPPER
                else if (type == 2)
                {
                    var query = db.Query(CreditCard.GETALL);
                    foreach (var creditCard in query)
                    {
                        creditCards.Add(new CreditCard
                        {
                            Id = creditCard.Id,
                            CardNumber = creditCard.CardNumber,
                            SecurityCode = creditCard.SecurityCode,
                            ExpirationDate = creditCard.ExpirationDate,
                            CardHolderName = creditCard.CardHolderName,
                        });
                    }
                }
                db.Close();
            }
            return creditCards;
        }
    }
}