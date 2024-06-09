namespace Models
{
    public class Ticket
    {
        public static readonly string GETALL = "SELECT Id, Number, ExpirationDate FROM dbo.Ticket";
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}