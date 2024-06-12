using Newtonsoft.Json;

namespace Models.DTO;

public class ViaCepDTO
{
    [JsonProperty("logradouro")] public string PublicPlace { get; set; }
    [JsonProperty("bairro")] public string District { get; set; }
    [JsonProperty("localidade")] public string City { get; set; }
    [JsonProperty("uf")] public string UF { get; set; }
}