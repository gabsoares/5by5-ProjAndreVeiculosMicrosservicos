using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public abstract class Person
    {
        [Key]
        [BsonId]
        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("adress")]
        public Adress? Adress { get; set; }

        [JsonProperty("phone")]
        public string? Phone { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }
    }
}