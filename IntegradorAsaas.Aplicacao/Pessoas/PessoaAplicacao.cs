using IntegradorAsaas.Aplicacao.Factory;
using IntegradorAsaas.Dominio.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorAsaas.Aplicacao.Pessoas
{
    public class PessoaAplicacao : AplicacaoAbs<Pessoa>
    {
        public PessoaAplicacao()
        {
            this.Repositorio = RepositorioFactory.PessoaRepositorio();
        }

        public bool ExecuteQuery(string Query)
        {
            return this.Repositorio.ExecuteQuery(Query);
        }
    }
}
