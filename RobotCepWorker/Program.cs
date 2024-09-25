using org.bouncycastle.asn1.ocsp;
using RobotCepWorker;
using RobotCepWorker.Driver;
using RobotCepWorker.Models;
using static sun.awt.geom.AreaOp;

const string BASE_URL = "https://localhost:7102/Endereco/";
//EnderecoSolicitadoModel dados = new EnderecoSolicitadoModel();
var request = new RequestProvider();
while (true)
{
    var dados = await request.GetAsync<EnderecoSolicitadoModel>(BASE_URL + "ObterCepParaTratamento?robot0=dev1");
    //if (dados != null && string.IsNullOrEmpty(dados.CEP))
        //{
        // teste   dados.CEP =  "13481620";
        EnderecoObtidoModel endereco = CepService.BuscarEndereco(dados);

        dados.UF = endereco.Uf;
        dados.Logadouro = endereco.Logradouro;
        dados.Bairro = endereco.Bairro;

        await request.PutAsync(BASE_URL + "AtualizarDados", dados);
      // }
    Thread.Sleep(TimeSpan.FromSeconds(10));
}
/*Console.WriteLine($"CEP: {endereco.Cep}");
Console.WriteLine($"Logradouro: {endereco.Logradouro}");
Console.WriteLine($"Complemento: {endereco.Complemento}");
Console.WriteLine($"Bairro: {endereco.Bairro}");
Console.WriteLine($"Localidade: {endereco.Localidade}");
Console.WriteLine($"UF: {endereco.Uf}");
Console.WriteLine($"IBGE: {endereco.Ibge}");
Console.WriteLine($"GIA: {endereco.Gia}");
Console.WriteLine($"DDD: {endereco.Ddd}");
Console.WriteLine($"SIAFI: {endereco.Siafi}");*/
