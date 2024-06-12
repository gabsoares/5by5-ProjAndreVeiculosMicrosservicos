using Models;
using Models.DTO;
using Newtonsoft.Json;

namespace APIAndreVeiculosMicrosservicos.Adress.Services
{
    public class AdressService
    {
        private readonly string BaseUrl = "https://viacep.com.br/ws";

        public async Task<Models.Adress> GetAdressData(string cep, AdressDTO adressDTO)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{BaseUrl}/{cep}/json/";

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        ViaCepDTO correios = JsonConvert.DeserializeObject<ViaCepDTO>(json);
                        return new Models.Adress
                        {
                            PublicPlace = correios.PublicPlace,
                            District = correios.District,
                            City = correios.City,
                            UF = correios.UF,
                            Complement = adressDTO.Complement,
                            ZipCode = adressDTO.ZipCode,
                            Number = adressDTO.Number
                        };
                    }
                    else
                    {
                        Console.WriteLine("Erro na requisicao, Status " + response.StatusCode);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
    }
}