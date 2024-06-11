namespace Models.DTO
{
    public class CustomerDTO
    {
        public string CustomerName { get; set; }
        public string CustomerCPF { get; set; }
        public DateTime CustomerDateOfBirth { get; set; }
        public AdressDTO Adress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public Decimal CustomerIncome { get; set; }
        public string CustomerPDFDoc { get; set; }
    }
}