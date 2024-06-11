namespace Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Decimal Franchise { get; set; }
        public Car Car { get; set; }
        public Driver Driver { get; set; }
    }
}
