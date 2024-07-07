using IntegradorAsaas.Dominio.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegradorAsaas.Tools;

namespace IntegradorAsaas.Repositorio.Pessoas
{
    public class PessoaRepositorio : RepositorioAbs<Pessoa>, IRepositorio<Pessoa>
    {
        private Conexao.IConexao Conexao { get; set; }

        public PessoaRepositorio()
        {
            this.Conexao = ConexoesFactory.ConexaoFactory.GetConexao();
        }

        protected override List<Pessoa> _Select(List<string> Parametros, int Limit = 0, string OrderBy = "", string GroupBy = "")
        {
            List<Pessoa> listaRegistros = new List<Pessoa>();

            try
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine("SELECT * FROM pessoas");

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
                    Pessoa registro = new Pessoa();
                    registro.Id = dt.Rows[i]["id"].ToString();
                    registro.DataCadastro = dt.Rows[i]["data_cadastro"].ToString().GetData();
                    registro.Nome = dt.Rows[i]["nome"].ToString();
                    registro.Email = dt.Rows[i]["email"].ToString();
                    registro.Telefone = dt.Rows[i]["telefone"].ToString();
                    registro.TelefoneCelular = dt.Rows[i]["telefone_celular"].ToString();
                    registro.Endereco = dt.Rows[i]["endereco"].ToString();
                    registro.EnderecoNumero = dt.Rows[i]["endereco_numero"].ToString();
                    registro.Complemento = dt.Rows[i]["complemento"].ToString();
                    registro.Cidade = dt.Rows[i]["cidade"].ToString();
                    registro.CEP = dt.Rows[i]["cep"].ToString();
                    registro.CpfCnpj = dt.Rows[i]["cpf_cnpj"].ToString();
                    registro.Tipo = dt.Rows[i]["tipo"].ToString();
                    registro.AsaasId = dt.Rows[i]["asaas_id"].ToString();
                    listaRegistros.Add(registro);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return listaRegistros;
        }
        public Pessoa Select(string id)
        {
            List<string> parametros = new List<string>();
            parametros.Add("id = '" + id + "'");
            return this.Select(parametros, 1).FirstOrDefault();
        }

        public List<Pessoa> Select(List<string> parametros)
        {
            return this._Select(parametros);
        }

        public List<Pessoa> Select(List<string> parametros, int Limit)
        {
            return this._Select(parametros, Limit);
        }

        public List<Pessoa> Select(List<string> parametros, string OrderBy, bool Order, int Limit = 0)
        {
            return this._Select(parametros, Limit, OrderBy);
        }

        public List<Pessoa> Select(List<string> parametros, string GroupBy, int Limit = 0, string OrderBy = "")
        {
            return this._Select(parametros, Limit, OrderBy, GroupBy);
        }

        public List<Pessoa> SelectLoadAll(List<Type> Carregar, List<string> Parametros, int Limit = 0, string OrderBy = "", string GroupBy = "")
        {
            throw new NotImplementedException();
        }

        public bool Save(Pessoa obj)
        {
            try
            {
                object o = (object)obj;
                Tools.PrepararDadosPBanco.Preparar(typeof(Pessoa), ref o);
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
        protected override bool Insert(Pessoa obj)
        {
            try
            {
                obj.Id = Guid.NewGuid().ToString();

                StringBuilder query = new StringBuilder();
                query.AppendLine("INSERT INTO pessoas(")
                .AppendLine("id , ")
                .AppendLine("data_cadastro , ")
                .AppendLine("nome , ")
                .AppendLine("email , ")
                .AppendLine("telefone , ")
                .AppendLine("telefone_celular , ")
                .AppendLine("endereco , ")
                .AppendLine("endereco_numero , ")
                .AppendLine("complemento , ")
                .AppendLine("cidade , ")
                .AppendLine("cep , ")
                .AppendLine("cpf_cnpj , ")
                .AppendLine("tipo , ")
                .AppendLine("asaas_id  ) VALUES(").AppendLine(" '" + obj.Id + "' ,  ")
                .AppendLine(" '" + obj.DataCadastro.GetFormatDateTime() + "' ,  ")
                .AppendLine(" '" + obj.Nome + "' ,  ")
                .AppendLine(" '" + obj.Email + "' ,  ")
                .AppendLine(" '" + obj.Telefone + "' ,  ")
                .AppendLine(" '" + obj.TelefoneCelular + "' ,  ")
                .AppendLine(" '" + obj.Endereco + "' ,  ")
                .AppendLine(" '" + obj.EnderecoNumero + "' ,  ")
                .AppendLine(" '" + obj.Complemento + "' ,  ")
                .AppendLine(" '" + obj.Cidade + "' ,  ")
                .AppendLine(" '" + obj.CEP + "' ,  ")
                .AppendLine(" '" + obj.CpfCnpj + "' ,  ")
                .AppendLine(" '" + obj.Tipo + "' ,  ")
                .AppendLine(" '" + obj.AsaasId + "' )");

                this.Conexao.ExecuteQuery(query.ToString());
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        protected override bool Update(Pessoa obj)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine("UPDATE pessoas ")
                .AppendLine("SET ")
                .AppendLine("id = '" + obj.Id + "', ")
                .AppendLine("data_cadastro = '" + obj.DataCadastro.GetFormatDateTime() + "', ")
                .AppendLine("nome = '" + obj.Nome + "', ")
                .AppendLine("email = '" + obj.Email + "', ")
                .AppendLine("telefone = '" + obj.Telefone + "', ")
                .AppendLine("telefone_celular = '" + obj.TelefoneCelular + "', ")
                .AppendLine("endereco = '" + obj.Endereco + "', ")
                .AppendLine("endereco_numero = '" + obj.EnderecoNumero + "', ")
                .AppendLine("complemento = '" + obj.Complemento + "', ")
                .AppendLine("cidade = '" + obj.Cidade + "', ")
                .AppendLine("cep = '" + obj.CEP + "', ")
                .AppendLine("cpf_cnpj = '" + obj.CpfCnpj + "', ")
                .AppendLine("tipo = '" + obj.Tipo + "', ")
                .AppendLine("asaas_id = '" + obj.AsaasId + "'")
                .AppendLine(" WHERE id = '" + obj.Id + "'");

                this.Conexao.ExecuteQuery(query.ToString());
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public bool Delete(Pessoa obj)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.AppendLine("DELETE FROM pessoas WHERE id='" + obj.Id + "'");

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
