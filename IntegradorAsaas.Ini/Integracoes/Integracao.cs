using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorAsaas.Ini.Integracoes
{
    public class Integracao
    {
        private string Ambiente = "SANDBOX";
        //private string Ambiente = "PRODUCAO";
        private string UriApiProducao = "https://api.asaas.com/v3/";
        private string UriApiSandbox = "https://sandbox.asaas.com/api/v3/";


        public Integracao()
        {
            PreparaConexao();
        }

        // Método estático para configurar a URI da API
        public void PreparaConexao()
        {
            if (Ambiente == "SANDBOX")
            {
                UriApi = UriApiSandbox;
            }
            else
            {
                UriApi = UriApiProducao;
            }

            TOKEN = "$aact_YTU5YTE0M2M2N2I4MTliNzk0YTI5N2U5MzdjNWZmNDQ6OjAwMDAwMDAwMDAwMDAwODQ0OTQ6OiRhYWNoXzE1NWUwMWNkLTBkMzEtNDQxZi1hMGNmLWQ0YjBkZDljZGU5Nw==";

        }

        public string UriApi { get; set; }
        public string TOKEN { get; set; }
    }
}
