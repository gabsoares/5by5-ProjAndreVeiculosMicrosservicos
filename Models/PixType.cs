using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PixType
    {
        public static readonly string GETALL = "SELECT Id, Description FROM dbo.PixType";
        public int Id { get; set; }
        public string? Description { get; set; }

        public PixType()
        {
            
        }

        public PixType(PixTypeDTO pixTypeDTO)
        {
            this.Description = pixTypeDTO.PixDescription;
        }
    }
}
