using Models.DTO;
using Newtonsoft.Json;
namespace Models
{
    public class Adress
    {
        public readonly static string INSERT = "INSERT INTO dbo.Adress (PublicPlace, ZipCode, District, Complement, Number, UF, City) VALUES (@PublicPlace, @ZipCode, @District, @Complement, @Number, @UF, @City)";

        public readonly static string GETALL = "SELECT Id, PublicPlace, ZipCode, District, Complement, Number, UF, City FROM dbo.Adress";
        public int Id { get; set; }
        [JsonProperty("logradouro")]
        public string PublicPlace { get; set; }
        [JsonProperty("cep")]
        public string ZipCode { get; set; }
        [JsonProperty("bairro")]
        public string District { get; set; }
        [JsonProperty("complemento")]
        public string? Complement { get; set; }
        [JsonProperty("numero")]
        public int Number { get; set; }
        [JsonProperty("uf")]
        public string UF { get; set; }
        [JsonProperty("localidade")]
        public string City { get; set; }

        public Adress()
        {

        }

        public Adress(AdressDTO adressDTO)
        {
            this.Id = adressDTO.Id;
            this.ZipCode = adressDTO.ZipCode;
            this.Complement = adressDTO.Complement;
            this.Number = adressDTO.Number;
        }
    }
}