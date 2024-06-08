using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Payment
    {
        public static readonly string GETALL = "SELECT [p].[Id], [p].[CreditCardId], [p].[PaymentDate], [p].[PixId], [p].[TicketId], [c].[Id] AS CreditCardId, [c].[CardHolderName], [c].[CardNumber], [c].[ExpirationDate], [c].[SecurityCode], [t].[Id] AS TicketId, [t].[ExpirationDate], [t].[Number], [p0].[Id] AS PixId, [p0].[PixKey], [p0].[PixTypeId], [p1].[Id] AS PixTypeId, [p1].[Description] FROM [Payment] AS [p] LEFT JOIN [CreditCard] AS [c] ON [p].[CreditCardId] = [c].[Id] LEFT JOIN [Ticket] AS [t] ON [p].[TicketId] = [t].[Id] LEFT JOIN [Pix] AS [p0] ON [p].[PixId] = [p0].[Id] LEFT JOIN [PixType] AS [p1] ON [p0].[PixTypeId] = [p1].[Id]";

        public static readonly string GETALLDapper = "SELECT [p].[Id], [p].[CreditCardId], [p].[PaymentDate], [p].[PixId], [p].[TicketId], [c].[Id] AS Id, [c].[CardHolderName], [c].[CardNumber], [c].[ExpirationDate], [c].[SecurityCode], [t].[Id] AS Id, [t].[ExpirationDate], [t].[Number], [p0].[Id] AS Id, [p0].[PixKey], [p0].[PixTypeId], [p1].[Id] AS Id, [p1].[Description] FROM [Payment] AS [p] LEFT JOIN [CreditCard] AS [c] ON [p].[CreditCardId] = [c].[Id] LEFT JOIN [Ticket] AS [t] ON [p].[TicketId] = [t].[Id] LEFT JOIN [Pix] AS [p0] ON [p].[PixId] = [p0].[Id] LEFT JOIN [PixType] AS [p1] ON [p0].[PixTypeId] = [p1].[Id]";
        public int Id { get; set; }
        public CreditCard? CreditCard { get; set; }
        public Ticket? Ticket { get; set; }
        public Pix? Pix { get; set; }
        public DateTime PaymentDate { get; set; }

        public Payment()
        {

        }

        public Payment(PaymentDTO paymentDTO)
        {
            CreditCard creditCard = new() { Id = paymentDTO.CreditCardId };
            Ticket ticket = new Ticket() { Id = paymentDTO.TicketId };
            Pix pix = new Pix() { Id = paymentDTO.PixId };
            this.CreditCard = creditCard;
            this.Ticket = ticket;
            this.Pix = pix;
            this.PaymentDate = paymentDTO.PaymentDate;
        }
    }
}