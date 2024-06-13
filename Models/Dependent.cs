using Models.DTO;

namespace Models
{
    public class Dependent : Person
    {
        public Customer Customer { get; set; }

        public Dependent()
        {

        }

        public Dependent(DependentDTO dependentDTO)
        {
            this.CPF = dependentDTO.DependentCPF;
            this.Customer = new Customer { CPF = dependentDTO.CustomerCPF };
            this.Name = dependentDTO.Name;
            this.DateOfBirth = dependentDTO.DateOfBirth;
            this.Phone = dependentDTO.Phone;
            this.Email = dependentDTO.Email;
            this.CPF = dependentDTO.DependentCPF;
        }
    }
}