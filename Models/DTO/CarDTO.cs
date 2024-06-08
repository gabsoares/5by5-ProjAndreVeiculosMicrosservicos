using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class CarDTO
    {
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public int FabricationYear { get; set; }
        public string CarColor { get; set; }
    }
}