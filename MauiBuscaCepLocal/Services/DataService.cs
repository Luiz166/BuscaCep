using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MauiAppBuscaCepLocal.Model;

namespace MauiBuscaCepLocal.Services
{
    public class DataService
    {
        public static async Task<Endereco?> GetEnderecoByCep(string cep)
        {
            Endereco? end;
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage res = await client.GetAsync("http://localhost:8000/endereco/by-cep?cep=" + cep);

                if (res.IsSuccessStatusCode)
                {
                    string json = res.Content.ReadAsStringAsync().Result;

                    end = JsonConvert.DeserializeObject<Endereco>(json);
                }
                else
                {
                    throw new Exception(res.RequestMessage.Content.ToString());
                }
                return end;
            } 
        }
    }
}
