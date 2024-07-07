using IntegradorAsaas.Dominio.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorAsaas.Dominio.Contas
{
    public class Conta
    {
        public string? Id { get; set; }
        public string? Status { get; set; }
        /// <summary>
        /// C = Conta Receber; D = Conta Pagar
        /// </summary>
        public string? Tipo { get; set; }
        public string? Documento { get; set; }
        public DateTime Emissao { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime VencimentoAtualizado { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorAtualizado { get; set; }
        public decimal Juros { get; set; }
        public decimal Taxas { get; set; }
        public decimal Acrescimo { get; set; }
        public decimal Desconto { get; set; }
        public DateTime PagamentoData { get; set; }
        public decimal PagamentoValor { get; set; }
        public string? PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
        public string? Observacao { get; set; }
        public string? AsaasId { get; set; }
        public string? AsaasLinkBoleto { get; set; }
        public string? AsaasInvoceLink { get; set; }
        public Conta()
        {
            
        }
        public Conta(ContaDTO contaDTO)
        {
            // Aqui você pode inicializar os valores da Conta baseado no ContaDTO fornecido
            Status = contaDTO.Status;
            Tipo = contaDTO.Tipo;
            Documento = contaDTO.Documento;
            Emissao = contaDTO.Emissao;
            Vencimento = contaDTO.Vencimento;
            VencimentoAtualizado = contaDTO.VencimentoAtualizado;
            Valor = contaDTO.Valor;
            ValorAtualizado = contaDTO.ValorAtualizado;
            Juros = contaDTO.Juros;
            Taxas = contaDTO.Taxas;
            Acrescimo = contaDTO.Acrescimo;
            Desconto = contaDTO.Desconto;
            PagamentoData = contaDTO.PagamentoData;
            PagamentoValor = contaDTO.PagamentoValor;
            PessoaId = contaDTO.PessoaId;
            Observacao = contaDTO.Observacao;
            AsaasId = null; // Ou inicialize com algum valor padrão se necessário
            AsaasLinkBoleto = null; // Ou inicialize com algum valor padrão se necessário
            AsaasInvoceLink = null; // Ou inicialize com algum valor padrão se necessário
        }

    }
}
