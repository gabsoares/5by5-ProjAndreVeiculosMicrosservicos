using Models.DTO;
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

        public Cnh()
        {

        }

        public Cnh(CnhDTO cnhDTO)
        {
            this.CnhNumber = cnhDTO.CnhNumber;
            this.DueDate = cnhDTO.DueDate;
            this.RG = cnhDTO.RG;
            this.CPF = cnhDTO.CPF;
            this.DadName = cnhDTO.DadName;
            this.MotherName = cnhDTO.MotherName;
            CnhCategory category = new CnhCategory() { Id = cnhDTO.CategoryId };
        }
    }
}