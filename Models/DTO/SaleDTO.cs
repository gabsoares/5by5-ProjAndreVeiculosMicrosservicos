namespace Models.DTO
{
    public class SaleDTO
    {
        public string CarPlate { get; set; }
        public string CustomerCPF { get; set; }
        public string EmployeeCPF { get; set; }
        public int PaymentId { get; set; }
        public DateTime SaleDate { get; set; }
        public Decimal SaleValue { get; set; }
    }
}
