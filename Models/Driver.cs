using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Driver : Person
    {
        public Cnh Cnh {  get; set; }

        public Driver()
        {
            
        }

        public Driver(DriverDTO driverDTO)
        {
            this.Name = driverDTO.DriverName;
            this.CPF = driverDTO.DriverCPF;
            this.DateOfBirth = driverDTO.DriverDateOfBirth;
            this.Phone = driverDTO.DriverPhone;
            this.Email = driverDTO.DriverEmail;
            this.Cnh = driverDTO.Cnh;
        }
    }
}