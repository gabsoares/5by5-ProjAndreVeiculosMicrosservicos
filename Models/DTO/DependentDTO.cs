using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class DependentDTO
    {
        public string DependentCPF { get; set; }
        public string Name { get; set; }
        public string CustomerCPF { get; set; }
        public DateTime DateOfBirth { get; set; }
        public AdressDTO Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}