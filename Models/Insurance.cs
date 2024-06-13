using Models.DTO;

namespace Models
{
    public class Insurance
    {
        public static readonly string GETALL = "SELECT Id, CustomerCPF, Franchise, CarPlate, DriverCPF FROM dbo.Insurance";
        public static readonly string INSERT = "INSERT INTO dbo.Insurance (CustomerCPF, Franchise, CarPlate, DriverCPF) VALUES (@CustomerCPF, @Franchise, @CarPlate, @DriverCPF); SELECT CAST(SCOPE_IDENTITY() AS INT)";

        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Decimal Franchise { get; set; }
        public Car Car { get; set; }
        public Driver Driver { get; set; }

        public Insurance()
        {

        }

        public Insurance(InsuranceDTO insuranceDTO)
        {
            Customer customer = new Customer { CPF = insuranceDTO.CustomerCPF };
            this.Franchise = insuranceDTO.Franchise;
            Car car = new Car { CarPlate = insuranceDTO.CarPlate };
            Driver driver = new Driver { CPF = insuranceDTO.CustomerCPF };
        }
    }
}