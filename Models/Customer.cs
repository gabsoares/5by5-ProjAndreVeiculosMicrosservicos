using Models.DTO;
using Newtonsoft.Json;

namespace Models
{
    public class Customer : Person
    {
        public readonly static string GETALL = "SELECT [c].[CPF], [c].[AdressId], [c].[DateOfBirth], [c].[Email], [c].[Income], [c].[Name], [c].[PDFDocument], [c].[Phone], [a].[Id] AS Id, [a].[City], [a].[Complement], [a].[District], [a].[Number], [a].[PublicPlace], [a].[UF], [a].[ZipCode] FROM [Customer] AS [c] LEFT JOIN [Adress] AS [a] ON [c].[AdressId] = [a].[Id]";

        public readonly static string GETONE = "SELECT [c].[CPF], [c].[AdressId], [c].[DateOfBirth], [c].[Email], [c].[Income], [c].[Name], [c].[PDFDocument], [c].[Phone], [a].[Id] AS Id, [a].[City], [a].[Complement], [a].[District], [a].[Number], [a].[PublicPlace], [a].[UF], [a].[ZipCode] FROM [Customer] AS [c] LEFT JOIN [Adress] AS [a] ON [c].[AdressId] = [a].[Id] WHERE c.[CPF] = @Cpf";

        [JsonProperty("income")]
        public Decimal Income { get; set; }

        [JsonProperty("pdfDocument")]
        public string? PDFDocument { get; set; }

        public Customer()
        {

        }

        public Customer(CustomerDTO customerDTO)
        {
            this.Name = customerDTO.CustomerName;
            this.CPF = customerDTO.CustomerCPF;
            this.DateOfBirth = customerDTO.CustomerDateOfBirth;
            this.Phone = customerDTO.CustomerPhone;
            this.Email = customerDTO.CustomerEmail;
            this.Income = customerDTO.CustomerIncome;
            this.PDFDocument = customerDTO.CustomerPDFDoc;
        }
    }
}