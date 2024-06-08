using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Job
    {
        public readonly static string GETALL = "SELECT Id, Description FROM dbo.Job";
        public int Id { get; set; }
        public string? Description { get; set; }
    }
}
