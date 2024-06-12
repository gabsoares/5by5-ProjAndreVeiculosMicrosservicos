namespace Models.DTO;

public class FinancialPendingDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public Decimal Value { get; set; }
    public DateTime PendingDate { get; set; }
    public DateTime BillingDate { get; set; }
    public bool Status { get; set; }
    public string Cpf { get; set; }
}