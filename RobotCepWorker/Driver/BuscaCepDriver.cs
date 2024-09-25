
using System;
using System.Globalization;
using System.Net.Http;
using Newtonsoft.Json;
using RobotCepWorker.Models;

namespace RobotCepWorker.Driver
{
    public class CepService
    {
        private static readonly HttpClient client = new HttpClient();

        public static EnderecoObtidoModel BuscarEndereco(EnderecoSolicitadoModel dados)
        {
            string url = $"https://viacep.com.br/ws/{dados.CEP}/json/";
            HttpResponseMessage response = client.GetAsync(url).Result;
            
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;

            EnderecoObtidoModel endereco = JsonConvert.DeserializeObject<EnderecoObtidoModel>(responseBody);

     

            return endereco;
        }
    }
}
