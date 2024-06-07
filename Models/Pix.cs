using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Pix
    {
        public static readonly string INSERT = "INSERT INTO TB_PIX (TYPE_PIX_ID, PIX_KEY) VALUES (@TpPixId, @PixKey) SELECT CAST(SCOPE_IDENTITY() AS INT)";
        public int Id { get; set; }
        public PixType? PixType { get; set; }
        public string? PixKey { get; set; }
    }
}