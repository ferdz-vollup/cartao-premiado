using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.Web.Configuration;

namespace Etnia.classe
{
    public partial class bd : System.Web.UI.Page
    {
        private OleDbConnection Conexao;
        private OleDbCommand DataSet;
        private OleDbDataReader rsSQL;
        // private OleDbTransaction Transacao;
        private string StringConexao = ConfigurationManager.AppSettings["ConnectionString"];
        public string Erro_Mensagem;

        public bd()
        {
        }

        public OleDbDataReader ExecutaSQL(string strSQL)
        {
            DataSet = new OleDbCommand(strSQL, AbreConexao());
            try
            {
                DataSet.CommandTimeout = 99999;
                rsSQL = DataSet.ExecuteReader();
                return rsSQL;
            }
            catch (Exception erro)
            {
                CancelaGravacaoDados();
                if (rsSQL != null)
                {
                    rsSQL.Close();
                }

                ExibeErro(erro);
                return null;
                throw;
            }
        }

        public void LiberaGravacaoDados()
        {
            if (Conexao != null)
            {
                //Transacao.Commit();
            }
        }

        public void CancelaGravacaoDados()
        {
            if (Conexao != null)
            {
                //Transacao.Rollback();
            }
        }

        public void FechaConexao()
        {
            if (Conexao != null)
            {
                if (Conexao.State == ConnectionState.Open)
                {
                    Conexao.Close();
                }
            }
        }

        private OleDbConnection AbreConexao()
        {
            if (Conexao == null)
            {
                Conexao = new OleDbConnection(StringConexao);
            }
            try
            {
                if (Conexao.State != ConnectionState.Open)
                {
                    Conexao.Open();
                }
                return Conexao;
            }
            catch (Exception erro)
            {
                Conexao.Close();
                throw erro;
            }
        }

        public string ErroSessao()
        {
            return Erro_Mensagem;
        }

        private void ExibeErro(Exception erro)
        {

            Erro_Mensagem = erro.Message;
            Session["Erro_Mensagem"] = Erro_Mensagem;
        }
    }
}