using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Role
    {
        public static readonly string GETALL = "SELECT Id, Description FROM dbo.Role";
        public int Id { get; set; }
        public string? Description { get; set; }

        public Role()
        {
            
        }

        public Role(RoleDTO roleDTO)
        {
            this.Description = roleDTO.RoleDescription;
        }
    }
}