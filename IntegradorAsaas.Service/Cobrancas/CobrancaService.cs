using IntegradorAsaas.Dominio.AsaasClientes;
using IntegradorAsaas.Dominio.AsaasCobrancas;
using IntegradorAsaas.Dominio.Contas;
using IntegradorAsaas.Dominio.Pessoas;
using IntegradorAsaas.Ini.Integracoes;
using IntegradorAsaas.Tools;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorAsaas.Service.Cobrancas
{
    public class CobrancaService
    {
        private string URL;
        private string AccessToken;

        public CobrancaService()
        {
            Integracao integracao = new Integracao();
            this.URL = integracao.UriApi;
            this.AccessToken = integracao.TOKEN;
        }

        public void CriaCobranca(Conta conta, Pessoa pessoa)
        {
            try
            {
                Cobranca cobranca = new Cobranca();
                cobranca.Customer = pessoa.AsaasId;
                cobranca.BillingType = "BOLETO";
                cobranca.Value = conta.ValorAtualizado == 0M ? conta.Valor : conta.ValorAtualizado;
                cobranca.DueDate = conta.Vencimento;
                cobranca.Description = conta.Documento + " " + conta.Observacao;

                // Inicializando a propriedade Interest
                cobranca.Interest = new  Dominio.AsaasCobrancas.Interest()
                {
                    Value = 1.2M
                };

                // Inicializando a propriedade Fine
                cobranca.Fine = new Dominio.AsaasCobrancas.Fine()
                {
                    Value = 2.2M
                };

                cobranca.PostalService = false;

                string body = JsonConvert.SerializeObject(cobranca);

                var client = new RestClient($"{URL}payments");
                var request = new RestRequest()
                {
                    Method = Method.Post
                };
                request.AddHeader("accept", "application/json");
                request.AddHeader("access_token", AccessToken);
                request.AddJsonBody(body);

                RestResponse response = client.ExecuteAsync(request, Method.Post).Result;

                //if (response.Status == TaskStatus.Created)
                //{
                //    var retorno = JsonConvert.DeserializeObject<dynamic>(response.Content);

                //    JsonSerializerSettings settings = new JsonSerializerSettings
                //    {
                //        Converters = { new CustomDateConverter() }
                //    };

                //    var CobrancaAtualizado = JsonConvert.DeserializeObject<Cobranca>(response.Content, settings);
                //    cobranca.Id = CobrancaAtualizado.Id;
                //    cobranca.BankSlipUrl = CobrancaAtualizado.BankSlipUrl;
                //    cobranca.InvoiceUrl = CobrancaAtualizado.InvoiceUrl;
                //    cobranca.InvoiceNumber = CobrancaAtualizado.InvoiceNumber;
                //}
                //else
                //{
                //    // Tratamento de erro
                //}

            }
            catch (Exception)
            {
            }
        }

    }
}
