using System.ComponentModel.DataAnnotations;

namespace Models
{
    public abstract class Person
    {
        [Key]
        public string CPF { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Adress? Adress { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}