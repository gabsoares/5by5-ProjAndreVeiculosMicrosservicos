using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class AdressDTO
    {
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }
        public int Number { get; set; }
    }
}