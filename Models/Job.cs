using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Job
    {
        public readonly static string INSERT = "INSERT INTO TB_JOB (DESCRIPTION_JOB) VALUES (@Desc)";
        public int Id { get; set; }
        public string? Description { get; set; }
    }
}
