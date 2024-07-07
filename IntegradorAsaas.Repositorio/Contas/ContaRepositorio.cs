using IntegradorAsaas.Dominio.Contas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegradorAsaas.Tools;

namespace IntegradorAsaas.Repositorio.Contas
{
    public class ContaRepositorio : RepositorioAbs<Conta>, IRepositorio<Conta>
    {
        private Conexao.IConexao Conexao { get; set; }

        public ContaRepositorio()
        {
            this.Conexao = ConexoesFactory.ConexaoFactory.GetConexao();
        }

        protected override List<Conta> _Select(List<string> Parametros, int Limit = 0, string OrderBy = "", string GroupBy = "")
        {
            List<Conta> listaRegistros = new List<Conta>();

            try
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine("SELECT * FROM contas");

                if (Parametros.Count > 0)
                {
                    StringBuilder qParametros = new StringBuilder();
                    qParametros.AppendLine("WHERE ");

                    foreach (string parametro in Parametros)
                    {
                        string parm = parametro;
                        qParametros.AppendLine(parm + " AND ");
                    }

                    query.AppendLine(qParametros.ToString().Substring(0, qParametros.Length - 6));
                }

                if (GroupBy != string.Empty)
                {
                    query.AppendLine("GROUP BY " + GroupBy);
                }

                if (OrderBy == string.Empty)
                {
                    query.AppendLine("ORDER BY id");
                }
                else
                {
                    query.AppendLine("ORDER BY " + OrderBy);
                }

                if (Limit > 0)
                {
                    query.AppendLine("LIMIT " + Limit);
                }

                System.Data.DataTable dt = this.Conexao.Select(query.ToString());

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Conta registro = new Conta();
                    registro.Id = dt.Rows[i]["id"].ToString();
                    registro.Status = dt.Rows[i]["status"].ToString();
                    registro.Tipo = dt.Rows[i]["tipo"].ToString();
                    registro.Documento = dt.Rows[i]["documento"].ToString();
                    registro.Emissao = dt.Rows[i]["emissao"].ToString().GetData();
                    registro.Vencimento = dt.Rows[i]["vencimento"].ToString().GetData();
                    registro.VencimentoAtualizado = dt.Rows[i]["vencimento_atualizado"].ToString().GetData();
                    registro.Valor = dt.Rows[i]["valor"].ToString().GetDecimal();
                    registro.ValorAtualizado = dt.Rows[i]["valor_atualizado"].ToString().GetDecimal();
                    registro.Juros = dt.Rows[i]["juros"].ToString().GetDecimal();
                    registro.Taxas = dt.Rows[i]["taxas"].ToString().GetDecimal();
                    registro.Acrescimo = dt.Rows[i]["acrescimo"].ToString().GetDecimal();
                    registro.Desconto = dt.Rows[i]["desconto"].ToString().GetDecimal();
                    registro.PagamentoData = dt.Rows[i]["pagamento_data"].ToString().GetData();
                    registro.PagamentoValor = dt.Rows[i]["pagamento_valor"].ToString().GetDecimal();
                    registro.PessoaId = dt.Rows[i]["pessoa_id"].ToString();
                    registro.Observacao = dt.Rows[i]["observacao"].ToString();
                    registro.AsaasId = dt.Rows[i]["asaas_id"].ToString();
                    registro.AsaasLinkBoleto = dt.Rows[i]["asaas_link_boleto"].ToString();
                    registro.AsaasInvoceLink = dt.Rows[i]["asaas_invoce_link"].ToString();
                    listaRegistros.Add(registro);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return listaRegistros;
        }
        public Conta Select(string id)
        {
            List<string> parametros = new List<string>();
            parametros.Add("id = '" + id + "'");
            return this.Select(parametros, 1).FirstOrDefault();
        }

        public List<Conta> Select(List<string> parametros)
        {
            return this._Select(parametros);
        }

        public List<Conta> Select(List<string> parametros, int Limit)
        {
            return this._Select(parametros, Limit);
        }

        public List<Conta> Select(List<string> parametros, string OrderBy, bool Order, int Limit = 0)
        {
            return this._Select(parametros, Limit, OrderBy);
        }

        public List<Conta> Select(List<string> parametros, string GroupBy, int Limit = 0, string OrderBy = "")
        {
            return this._Select(parametros, Limit, OrderBy, GroupBy);
        }

        public List<Conta> SelectLoadAll(List<Type> Carregar, List<string> Parametros, int Limit = 0, string OrderBy = "", string GroupBy = "")
        {
            throw new NotImplementedException();
        }

        public bool Save(Conta obj)
        {
            try
            {
                object o = (object)obj;
                Tools.PrepararDadosPBanco.Preparar(typeof(Conta), ref o);
            }
            catch (Exception)
            {
                throw new Exception("Problemas ao preparar o registro para salvar!");
            }

            if (string.IsNullOrEmpty(obj.Id))
            {
                return this.Insert(obj);
            }
            else
            {
                return this.Update(obj);
            }
        }
        protected override bool Insert(Conta obj)
        {
            try
            {
                obj.Id = Guid.NewGuid().ToString();

                StringBuilder query = new StringBuilder();
                query.AppendLine("INSERT INTO contas(")
                .AppendLine("id , ")
                .AppendLine("status , ")
                .AppendLine("tipo , ")
                .AppendLine("documento , ")
                .AppendLine("emissao , ")
                .AppendLine("vencimento , ")
                .AppendLine("vencimento_atualizado , ")
                .AppendLine("valor , ")
                .AppendLine("valor_atualizado , ")
                .AppendLine("juros , ")
                .AppendLine("taxas , ")
                .AppendLine("acrescimo , ")
                .AppendLine("desconto , ")
                .AppendLine("pagamento_data , ")
                .AppendLine("pagamento_valor , ")
                .AppendLine("pessoa_id , ")
                .AppendLine("observacao , ")
                .AppendLine("asaas_id , ")
                .AppendLine("asaas_link_boleto , ")
                .AppendLine("asaas_invoce_link  ) VALUES(").AppendLine(" '" + obj.Id + "' ,  ")
                .AppendLine(" '" + obj.Status + "' ,  ")
                .AppendLine(" '" + obj.Tipo + "' ,  ")
                .AppendLine(" '" + obj.Documento + "' ,  ")
                .AppendLine(" '" + obj.Emissao.GetFormatDate() + "' ,  ")
                .AppendLine(" '" + obj.Vencimento.GetFormatDate() + "' ,  ")
                .AppendLine(" '" + obj.VencimentoAtualizado.GetFormatDate() + "' ,  ")
                .AppendLine(" '" + obj.Valor.GetStringDB() + "' ,  ")
                .AppendLine(" '" + obj.ValorAtualizado.GetStringDB() + "' ,  ")
                .AppendLine(" '" + obj.Juros.GetStringDB() + "' ,  ")
                .AppendLine(" '" + obj.Taxas.GetStringDB() + "' ,  ")
                .AppendLine(" '" + obj.Acrescimo.GetStringDB() + "' ,  ")
                .AppendLine(" '" + obj.Desconto.GetStringDB() + "' ,  ")
                .AppendLine(" '" + obj.PagamentoData.GetFormatDate() + "' ,  ")
                .AppendLine(" '" + obj.PagamentoValor.GetStringDB() + "' ,  ")
                .AppendLine(" '" + obj.PessoaId + "' ,  ")
                .AppendLine(" '" + obj.Observacao + "' ,  ")
                .AppendLine(" '" + obj.AsaasId + "' ,  ")
                .AppendLine(" '" + obj.AsaasLinkBoleto + "' ,  ")
                .AppendLine(" '" + obj.AsaasInvoceLink + "' )");

                this.Conexao.ExecuteQuery(query.ToString());
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        protected override bool Update(Conta obj)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine("UPDATE contas ")
                .AppendLine("SET ")
                .AppendLine("id = '" + obj.Id + "', ")
                .AppendLine("status = '" + obj.Status + "', ")
                .AppendLine("tipo = '" + obj.Tipo + "', ")
                .AppendLine("documento = '" + obj.Documento + "', ")
                .AppendLine("emissao = '" + obj.Emissao.GetFormatDate() + "', ")
                .AppendLine("vencimento = '" + obj.Vencimento.GetFormatDate() + "', ")
                .AppendLine("vencimento_atualizado = '" + obj.VencimentoAtualizado.GetFormatDate() + "', ")
                .AppendLine("valor = '" + obj.Valor.GetStringDB() + "', ")
                .AppendLine("valor_atualizado = '" + obj.ValorAtualizado.GetStringDB() + "', ")
                .AppendLine("juros = '" + obj.Juros.GetStringDB() + "', ")
                .AppendLine("taxas = '" + obj.Taxas.GetStringDB() + "', ")
                .AppendLine("acrescimo = '" + obj.Acrescimo.GetStringDB() + "', ")
                .AppendLine("desconto = '" + obj.Desconto.GetStringDB() + "', ")
                .AppendLine("pagamento_data = '" + obj.PagamentoData.GetFormatDate() + "', ")
                .AppendLine("pagamento_valor = '" + obj.PagamentoValor.GetStringDB() + "', ")
                .AppendLine("pessoa_id = '" + obj.PessoaId + "', ")
                .AppendLine("observacao = '" + obj.Observacao + "', ")
                .AppendLine("asaas_id = '" + obj.AsaasId + "', ")
                .AppendLine("asaas_link_boleto = '" + obj.AsaasLinkBoleto + "', ")
                .AppendLine("asaas_invoce_link = '" + obj.AsaasInvoceLink + "'")
                .AppendLine(" WHERE id = '" + obj.Id + "'");

                this.Conexao.ExecuteQuery(query.ToString());
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public bool Delete(Conta obj)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine("DELETE FROM contas WHERE id='" + obj.Id + "'");

                this.Conexao.ExecuteQuery(query.ToString());
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Count(List<string> parametros)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable Query(string query)
        {
            return this.Conexao.Select(query);
        }

        public bool ExecuteQuery(string query)
        {
            return this.Conexao.ExecuteQuery(query);
        }

        public bool IniciarTransaction()
        {
            throw new NotImplementedException();
        }

        public bool ComitTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
