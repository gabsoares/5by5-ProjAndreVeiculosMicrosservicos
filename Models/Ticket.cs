namespace Models
{
    public class Ticket
    {
        public static readonly string INSERT = "INSERT INTO TB_TICKET (TICKET_NUMBER, EXPIRATION_DATE) VALUES (@TNumber, @ExpDate)";
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}