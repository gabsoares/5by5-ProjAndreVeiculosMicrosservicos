using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee : Person
    {
        public readonly static string INSERT = "INSERT INTO TB_EMPLOYEE (CPF, EMPLOYEE_NAME, DATE_OF_BIRTH, ID_ADRESS, PHONE, EMAIL, COMISSION, COMISSION_VALUE, ID_ROLE) VALUES (@CPF, @Name, @DateBirth, @AdressId, @Phone, @Email, @Comission, @ComissionValue, @RoleId)";
        public Role? Role { get; set; }
        public Decimal ComissionValue { get; set; }
        public Decimal Comission { get; set; }
    }
}