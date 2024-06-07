using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Sale
    {
        public static readonly string INSERT = "INSERT INTO TB_SALE (CAR_ID, SALE_DATE, SALE_VALUE, CLIENT_ID, EMPLOYEE_ID, PAYMENT_ID) VALUES (@CarId, @SaleDate, @SaleValue, @ClientId, @EmpId, @PayId)";
        public int Id { get; set; }
        public Car? Car { get; set; }
        public DateTime SaleDate { get; set; }
        public Decimal SaleValue { get; set; }
        public Customer? Client { get; set; }
        public Employee? Employee { get; set; }
        public Payment? Payment { get; set; }
    }
}
