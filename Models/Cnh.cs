using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Cnh
    {
        [Key]
        public long CnhNumber { get; set; }
        public DateTime DueDate { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string DadName { get; set; }
        public string MotherName { get; set; }
        public CnhCategory Category { get; set; }
    }
}