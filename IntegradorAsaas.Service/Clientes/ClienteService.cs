using IntegradorAsaas.Dominio.AsaasClientes;
using IntegradorAsaas.Dominio.Pessoas;
using IntegradorAsaas.Ini.Integracoes;
using IntegradorAsaas.Tools;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorAsaas.Service.Clientes
{
    public class ClienteService
    {
        private string URL;
        private string AccessToken;
        private string Chamada = "customers";

        public ClienteService()
        {
            Integracao integracao = new Integracao();
            this.URL = integracao.UriApi;
            this.AccessToken = integracao.TOKEN;
        }

        public async Task CriarCliente(Pessoa pessoa)
        {
            ClienteAsaas Cliente = new ClienteAsaas
            {
                Name = pessoa.Nome,
                CpfCnpj = pessoa.CpfCnpj,
                Email = pessoa.Email,
                Phone = Tools.Util.ApenasNumerosRegex(pessoa.Telefone),
                Address = pessoa.Endereco,
                AddressNumber = pessoa.EnderecoNumero,
                Complement = pessoa.Complemento,
                PostalCode = pessoa.CEP,
                ExternalReference = Tools.Util.ApenasNumerosRegex(pessoa.CpfCnpj),
                NotificationDisabled = true
            };

            string body = JsonConvert.SerializeObject(Cliente);

            var options = new RestClientOptions($"{URL}");

            var client = new RestClient(options);
            var request = new RestRequest($"{Chamada}", Method.Post);
            request.AddHeader("access_token", AccessToken);
            request.AddHeader("Content-Type", "application/json");
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);

        }
    }
}
