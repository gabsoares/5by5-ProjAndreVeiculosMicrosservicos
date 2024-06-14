using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Models
{
    public class Bank
    {
        [Key]
        [BsonId]
        [JsonProperty("cnpj")]public string CNPJ { get; set; }
        [JsonProperty("bankName")]public string BankName { get; set; }
        [JsonProperty("foundationDate")]public DateTime FoundationDate { get; set; }
    }
}
