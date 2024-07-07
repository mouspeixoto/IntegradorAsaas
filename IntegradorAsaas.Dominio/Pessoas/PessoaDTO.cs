using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorAsaas.Dominio.Pessoas
{
    public class PessoaDTO
    {
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

    }
}
