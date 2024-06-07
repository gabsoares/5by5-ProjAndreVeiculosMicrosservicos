namespace Models
{
    public class Customer : Person
    {
        public readonly static string INSERT = "INSERT INTO TB_CLIENT (CPF, CLIENT_NAME, DATE_OF_BIRTH, ID_ADRESS, PHONE, EMAIL, INCOME, PDF_DOCUMENT) VALUES (@CPF, @Name, @DateBirth, @IdAdress, @Phone, @Email, @Income, @PdfDoc)";
        public Decimal Income { get; set; }
        public string? PDFDocument { get; set; }
    }
}