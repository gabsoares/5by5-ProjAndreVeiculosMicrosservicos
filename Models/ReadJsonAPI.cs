using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ReadJsonAPI
    {
        public async Task<Adress> GetApiData(string cep)
        {
            string urlAPI = $"https://viacep.com.br/ws/{cep}/json/";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(urlAPI);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        var lst = JsonConvert.DeserializeObject<Adress>(json);

                        if (lst != null) return lst;
                    }
                    else
                    {
                        Console.WriteLine("Erro na requisicao: " + response.StatusCode);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;
        }
    }
}