using IntegradorAsaas.Dominio.Configuracoes;
using IntegradorAsaas.Repositorio.Configuracoes;
using IntegradorAsaas.Repositorio;
using System;
using IntegradorAsaas.Repositorio.Pessoas;
using IntegradorAsaas.Dominio.Pessoas;
using IntegradorAsaas.Repositorio.Contas;
using IntegradorAsaas.Dominio.Contas;

namespace IntegradorAsaas.Aplicacao.Factory
{
    public class RepositorioFactory
    {
        private static string GetTypeRepository()
        {
            string retorno = "MySQL";

            if (string.IsNullOrEmpty(retorno))
            {
                retorno = "MySQL";
            }

            return retorno;
        }

        #region Configuracoes
        public static IRepositorio<Configuracao> ConfiguracaoRepositorio()
        {
            switch (RepositorioFactory.GetTypeRepository())
            {
                case "MySQL":
                    return new ConfiguracaoRepositorio();

                default:
                    return new ConfiguracaoRepositorio();
            }
        }
        #endregion

        #region Contas
        public static IRepositorio<Conta> ContaRepositorio()
        {
            switch (RepositorioFactory.GetTypeRepository())
            {
                case "MySQL":
                    return new ContaRepositorio();

                default:
                    return new ContaRepositorio();
            }
        }
        #endregion

        #region Pessoas
        public static IRepositorio<Pessoa> PessoaRepositorio()
        {
            switch (RepositorioFactory.GetTypeRepository())
            {
                case "MySQL":
                    return new PessoaRepositorio();

                default:
                    return new PessoaRepositorio();
            }
        }
        #endregion

    }
}