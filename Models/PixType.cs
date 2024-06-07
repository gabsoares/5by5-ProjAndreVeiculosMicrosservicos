using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PixType
    {
        public static readonly string INSERT = "INSERT INTO TB_TYPE_PIX (DESCRIPTION_PIX) VALUES (@DESC); SELECT CAST(SCOPE_IDENTITY() AS INT)";
        public int Id { get; set; }
        public string? Description { get; set; }
    }
}
