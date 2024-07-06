using IntegradorAsaas.Dominio.Configuracoes;
using IntegradorAsaas.Repositorio.Configuracoes;
using IntegradorAsaas.Repositorio;
using System;

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

    }
}