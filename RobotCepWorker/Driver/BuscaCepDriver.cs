using com.sun.security.ntlm;
using EasyAutomationFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCepWorker.Driver
{
    private static readonly HttpClient endereco = new HttpClient();

    public static async Task<EnderecoModel> BuscarEnderecoAsync(string cep)
    {
        string url = $"https://viacep.com.br/ws/{cep}/json/";
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        EnderecoModel endereco = JsonConvert.DeserializeObject<EnderecoModel>(responseBody);
        return endereco;
    }
}