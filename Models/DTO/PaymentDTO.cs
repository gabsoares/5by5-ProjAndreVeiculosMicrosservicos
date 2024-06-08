namespace Models.DTO
{
    public class PaymentDTO
    {
        public int CreditCardId { get; set; }
        public int TicketId { get; set; }
        public int PixId { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}