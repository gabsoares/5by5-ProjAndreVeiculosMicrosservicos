using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Payment
    {
        public static readonly string INSERT = "INSERT INTO TB_PAYMENT (CREDIT_CARD_ID, TICKET_ID, PIX_ID, PAYMENT_DATE) VALUES (@CCId, @TicketId, @PixId, @PayDate)";
        public int Id { get; set; }
        public CreditCard? CreditCard { get; set; }
        public Ticket? Ticket { get; set; }
        public Pix? Pix { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
