namespace Models.DTO
{
    public class InsuranceDTO
    {
        public int Id { get; set; }
        public string CustomerCPF { get; set; }
        public Decimal Franchise { get; set; }
        public string CarPlate { get; set; }
        public string DriverCPF { get; set; }
    }
}