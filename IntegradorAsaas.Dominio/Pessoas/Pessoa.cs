using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorAsaas.Dominio.Pessoas
{
    public class Pessoa
    {
        public string? Id { get; set; }

        public DateTime DataCadastro { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Telefone { get; set; }

        public string? TelefoneCelular { get; set; }

        public string? Endereco { get; set; }

        public string? EnderecoNumero { get; set; }

        public string? Complemento { get; set; }

        public string? Cidade { get; set; }

        public string? CEP { get; set; }

        public string? CpfCnpj { get; set; }

        public string? Tipo { get; set; }

        public string? AsaasId { get; set; }

        public Pessoa(PessoaDTO pessoaDTO)
        {
            DataCadastro = DateTime.Now;
            Nome = pessoaDTO.Nome;
            Email = pessoaDTO.Email;
            Telefone = pessoaDTO.Telefone;
            TelefoneCelular = pessoaDTO.TelefoneCelular;
            Endereco = pessoaDTO.Endereco;
            EnderecoNumero = pessoaDTO.EnderecoNumero;
            Complemento = pessoaDTO.Complemento;
            Cidade = pessoaDTO.Cidade;
            CEP = pessoaDTO.CEP;
            CpfCnpj = pessoaDTO.CpfCnpj;
            Tipo = pessoaDTO.Tipo;
            AsaasId = "";
        }

        public Pessoa()
        {
        }

    }
}
