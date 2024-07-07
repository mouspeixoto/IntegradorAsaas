using IntegradorAsaas.Dominio.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorAsaas.Dominio.Contas
{
    public class ContaDTO
    {
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
        public string? Observacao { get; set; }
    }
}
