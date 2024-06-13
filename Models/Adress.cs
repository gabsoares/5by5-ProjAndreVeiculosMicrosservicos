using Models.DTO;
using Newtonsoft.Json;
namespace Models
{
    public class Adress
    {
        public readonly static string INSERT = "INSERT INTO dbo.Adress (PublicPlace, ZipCode, District, Complement, Number, UF, City) VALUES (@PublicPlace, @ZipCode, @District, @Complement, @Number, @UF, @City)";

    public static readonly string GETALL =
        "SELECT Id, PublicPlace, ZipCode, District, Complement, Number, UF, City FROM dbo.Adress";

    [JsonProperty("id")] public int Id { get; set; }
    [JsonProperty("publicPlace")] public string PublicPlace { get; set; }
    [JsonProperty("zipCode")] public string ZipCode { get; set; }
    [JsonProperty("district")] public string District { get; set; }
    [JsonProperty("complement")] public string? Complement { get; set; }
    [JsonProperty("number")] public int Number { get; set; }
    [JsonProperty("uf")] public string UF { get; set; }
    [JsonProperty("city")] public string City { get; set; }

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