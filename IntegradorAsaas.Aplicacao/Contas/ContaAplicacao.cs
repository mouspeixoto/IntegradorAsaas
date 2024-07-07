using IntegradorAsaas.Aplicacao.Factory;
using IntegradorAsaas.Dominio.Contas;
using IntegradorAsaas.Dominio.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorAsaas.Aplicacao.Contas
{
    public class ContaAplicacao : AplicacaoAbs<Conta>
    {
        public ContaAplicacao()
        {
            this.Repositorio = RepositorioFactory.ContaRepositorio();
        }

        public bool ExecuteQuery(string Query)
        {
            return this.Repositorio.ExecuteQuery(Query);
        }
    }
}
