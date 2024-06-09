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
        public static readonly string GETALL = "SELECT Id, CardNumber, SecurityCode, ExpirationDate, CardHolderName FROM dbo.CreditCard";
        public int Id { get; set; }
        public string? CardNumber { get; set; }
        public string? SecurityCode { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? CardHolderName { get; set; }
    }
}
