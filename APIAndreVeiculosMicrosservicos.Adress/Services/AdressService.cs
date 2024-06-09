using Models;
using Models.DTO;
using Newtonsoft.Json;

namespace APIAndreVeiculosMicrosservicos.Adress.Services
{
    public class AdressService
    {
        private readonly string BaseUrl = "https://viacep.com.br/ws";

        public async Task<Models.Adress> GetAdressData(string cep)
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
                        Models.Adress adress = JsonConvert.DeserializeObject<Models.Adress>(json);
                        return adress;
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

        public async Task RetrieveAdressData(AdressDTO adressDTO, string cep, Models.Adress adress)
        {
            Models.Adress adressFilledWithCorreiosAPI = await GetAdressData(cep);

            if (adressFilledWithCorreiosAPI != null)
            {
                adress.PublicPlace = adressFilledWithCorreiosAPI.PublicPlace;
                adress.UF = adressFilledWithCorreiosAPI.UF;
                adress.City = adressFilledWithCorreiosAPI.City;
                adress.District = adressFilledWithCorreiosAPI.District;
            }
        }
    }
}