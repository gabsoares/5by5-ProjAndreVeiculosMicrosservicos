using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class EmployeeDTO
    {
        public string EmployeeName { get; set; }
        public string EmployeeCPF { get; set; }
        public DateTime EmployeeDateOfBirth { get; set; }
        public AdressDTO Adress { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeEmail { get; set; }
        public int RoleId { get; set; }
        public Decimal ComissionValue { get; set; }
        public Decimal Comission { get; set; }
    }
}
