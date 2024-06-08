using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CreditCard
    {
        public static readonly string INSERT = "INSERT INTO TB_CREDIT_CARD (CARD_NUMBER, SECURITY_CODE, EXPIRATION_DATE, CARD_HOLDER_NAME) VALUES (@CNumber, @SecCode, @ExpDate, @CHName)";
        public int Id { get; set; }
        public string? CardNumber { get; set; }
        public string? SecurityCode { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? CardHolderName { get; set; }
    }
}
