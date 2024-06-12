namespace Models.DTO
{
    public class DriverDTO
    {
        public string DriverName { get; set; }
        public string DriverCPF { get; set; }
        public DateTime DriverDateOfBirth { get; set; }
        public AdressDTO Adress { get; set; }
        public string DriverPhone { get; set; }
        public string DriverEmail { get; set; }
        public Cnh Cnh { get; set; }
    }
}
