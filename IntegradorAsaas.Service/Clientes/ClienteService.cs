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

        public void CriarCliente(Pessoa pessoa)
        {
            ClienteAsaas Cliente = new ClienteAsaas();
            Cliente.Name = pessoa.Nome;
            Cliente.CpfCnpj = pessoa.CpfCnpj;
            Cliente.Email = pessoa.Email;
            Cliente.Phone = pessoa.Telefone;
            Cliente.Address = pessoa.Endereco;
            Cliente.AddressNumber = pessoa.EnderecoNumero;
            Cliente.Complement = pessoa.Complemento;
            Cliente.PostalCode = pessoa.CEP;
            Cliente.ExternalReference = Tools.Util.ApenasNumerosRegex(pessoa.CpfCnpj);
            Cliente.NotificationDisabled = true;

            string body = JsonConvert.SerializeObject(Cliente);

            var client = new RestClient($"{URL}{Chamada}");
            var request = new RestRequest()
            {
                Method = Method.Post
            };
            request.AddHeader("accept", "application/json");
            request.AddHeader("access_token", AccessToken);
            request.AddJsonBody(body);

            RestResponse response = client.ExecuteAsync(request, Method.Post).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var retorno = JsonConvert.DeserializeObject<dynamic>(response.Content);

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Converters = { new CustomDateConverter() }
                };

                var clienteAtualizado = JsonConvert.DeserializeObject<ClienteAsaas>(response.Content.ToString(), settings);
                Cliente.Id = clienteAtualizado.Id;
            }

        }

    }
}
