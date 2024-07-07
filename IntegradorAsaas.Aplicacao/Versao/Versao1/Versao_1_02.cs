using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorAsaas.Aplicacao.Versao.Versao1
{
    class Versao_1_02
    {
        public static System.Data.DataTable RetornaComandos()
        {
            System.Data.DataTable dtTab = new System.Data.DataTable("sqls");

            dtTab.Clear();

            try
            {
                dtTab.Columns.Add("comando", typeof(string));

                System.Data.DataRow row;

                row = dtTab.NewRow();
                row["comando"] = "CREATE TABLE `pessoas` (`id` VARCHAR(37) NOT NULL, `data_cadastro` DATETIME NULL, `nome` VARCHAR(50) NULL, `email` VARCHAR(75) NULL, `telefone` VARCHAR(50) NOT NULL, `telefone_celular` VARCHAR(50) NULL, `endereco` VARCHAR(50) NULL, `endereco_numero` VARCHAR(50) NULL, `complemento` VARCHAR(50) NULL, `cidade` VARCHAR(50) NULL, `cep` VARCHAR(50) NULL, `cpf_cnpj` VARCHAR(50) NULL, `tipo` VARCHAR(1) NULL, `asaas_id` VARCHAR(37) NULL, PRIMARY KEY (`id`)) ENGINE = MyISAM;";
                dtTab.Rows.Add(row);

                row = dtTab.NewRow();
                row["comando"] = "CREATE TABLE IF NOT EXISTS `contas` (  `id` varchar(37) NOT NULL,  `status` varchar(20) NOT NULL,  `tipo` varchar(1) NOT NULL,  `documento` varchar(20) DEFAULT NULL,  `emissao` date DEFAULT NULL,  `vencimento` date DEFAULT NULL,  `vencimento_atualizado` date DEFAULT NULL,  `valor` decimal(16,2) DEFAULT NULL,  `valor_atualizado` decimal(16,2) DEFAULT NULL,  `juros` decimal(16,2) DEFAULT NULL,  `taxas` decimal(16,2) DEFAULT NULL,  `acrescimo` decimal(16,2) DEFAULT NULL,  `desconto` decimal(16,2) DEFAULT NULL,  `pagamento_data` date DEFAULT NULL,  `pagamento_valor` decimal(16,2) DEFAULT NULL,  `pessoa_id` varchar(37) DEFAULT NULL,  `observacao` text,  `asaas_id` varchar(37) DEFAULT NULL,  `asaas_link_boleto` text,  `asaas_invoce_link` text,  PRIMARY KEY (`id`)) ENGINE=MyISAM";
                dtTab.Rows.Add(row);

                row = dtTab.NewRow();
                row["comando"] = "";
                dtTab.Rows.Add(row);

                row = dtTab.NewRow();
                row["comando"] = "";
                dtTab.Rows.Add(row);

                row = dtTab.NewRow();
                row["comando"] = "";
                dtTab.Rows.Add(row);

                row = dtTab.NewRow();
                row["comando"] = "";
                dtTab.Rows.Add(row);

                row = dtTab.NewRow();
                row["comando"] = "";
                dtTab.Rows.Add(row);

                row = dtTab.NewRow();
                row["comando"] = "";
                dtTab.Rows.Add(row);

                row = dtTab.NewRow();
                row["comando"] = "";
                dtTab.Rows.Add(row);

                row = dtTab.NewRow();
                row["comando"] = "";
                dtTab.Rows.Add(row);

            }
            catch (Exception)
            {
            }

            return dtTab;
        }
    }
}
