using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data.SqlClient;
using Etnia.classe;
using System.IO;
using InnerLibs;
using System.Drawing.Imaging;
using System.Data.OleDb;
using System.Threading;
using System.Text;

namespace cartaoPremiado.ajax
{
    public partial class acoes : System.Web.UI.Page
    {
        bd objBD = new bd();
        utils objUtils = new utils();
        private OleDbDataReader rsLogin, rsCadastros, rsIdade, rsEmail;

        string retorno = "", retorno2 = "";

        int total = 0, aux = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            string acao = Request["acao"];

            switch (acao)
            {
                //ADMINISTRACAO
                case "loginAdministrador":
                    loginAdministrador(Request["email"].ToString(), Request["password"].ToString());
                    break;

                case "filtrarClientes":
                    filtrarClientes(Request["cpf"]);
                    break;
                case "filtrarCuponsPorCPF":
                    filtrarCuponsPorCPF(Request["cpf"]);
                    break;
                case "rangeIdade":
                    rangeIdade();
                    break;
                case "totalEmail":
                    totalEmail();
                    break;
                default:
                    break;
            }
        }

        //ADMINISTRACAO
        public void loginAdministrador(string email, string senha)
        {
            //Verificar se o usuário existe (comparando usuário e senha)
            rsLogin = objBD.ExecutaSQL("select ADM_ID from administradores where ADM_EMAIL = '" + email + "' AND ADM_SENHA = '" + senha + "' AND ADM_ATIVO = 1");

            if (rsLogin == null)
            {
                throw new Exception();
            }
            if (rsLogin.HasRows)
            {
                rsLogin.Read();

                //Salvando as Session do usuário
                Session["ADM_ID"] = rsLogin["ADM_ID"].ToString();

                Response.Redirect("/admin/index.aspx");
                Response.End();

                Response.End();
            }
            else
            {
                Response.Redirect("/admin/login.aspx?msg=erroLogin");
            }

            rsLogin.Dispose();
            rsLogin.Close();
        }

        public void filtrarClientes(string cpf)
        {
            try
            {
                rsCadastros = objBD.ExecutaSQL("select CLI_NOME, CLI_NUMERO_CARTAO, CLI_CPF, count(CLI_CPF) as total from clientes where CLI_CPF LIKE '%" + cpf + "%' group by CLI_NOME, CLI_NUMERO_CARTAO, CLI_CPF");

                if (rsCadastros == null)
                {
                    throw new Exception();
                }
                if (rsCadastros.HasRows)
                {
                    while (rsCadastros.Read())
                    {
                        retorno += "<tr>";
                        retorno += "  <td>" + rsCadastros["CLI_NOME"] + "</td>";
                        retorno += "  <td>" + rsCadastros["CLI_NUMERO_CARTAO"] + "</td>";
                        retorno += "  <td>" + rsCadastros["CLI_CPF"] + "</td>";
                        retorno += "  <td>";
                        retorno += "    <a href='javascript:void(0)' onClick='verUser(" + rsCadastros["CLI_CPF"] + ")' data-toggle='modal' data-target='#dadosUsuario'><i class='fa fa-pencil-square-o' aria-hidden='true'></i></a> | ";
                        retorno += "    <a href='javascript:void(0)' title='Ver Cupons' onClick='verCupons(" + rsCadastros["CLI_CPF"] + ")' data-toggle='modal' data-target='#dadosCupom'><i class='fa fa-search' aria-hidden='true'></i></a> ";
                        retorno += "</td>";
                        retorno += "</tr>";

                        retorno2 = rsCadastros["TOTAL"].ToString();
                    }

                    Response.Write(retorno + "Ø" + retorno2);
                    Response.End();
                }
                rsCadastros.Dispose();
                rsCadastros.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void filtrarCuponsPorCPF(string cpf)
        {
            try
            {
                rsCadastros = objBD.ExecutaSQL("select CLI_NOME, P.CUP_NUMERO_SORTE, P.CUP_VALOR, CLI_CPF, P.CUP_DH_COMPRA, count(CLI_CPF) as TOTAL from clientes C INNER JOIN Cupons P ON (P.CLI_ID = C.CLI_ID) where CLI_CPF LIKE '%" + cpf + "%' group by CLI_NOME, CUP_NUMERO_SORTE, CLI_CPF, CUP_VALOR, CUP_DH_COMPRA");

                if (rsCadastros == null)
                {
                    throw new Exception();
                }
                if (rsCadastros.HasRows)
                {
                    while (rsCadastros.Read())
                    {
                        retorno += "<tr>";
                        retorno += "  <td>" + rsCadastros["CLI_NOME"] + "</td>";
                        retorno += "  <td>" + rsCadastros["CUP_NUMERO_SORTE"] + "</td>";
                        retorno += "  <td>" + rsCadastros["CUP_VALOR"] + "</td>";
                        retorno += "  <td>" + rsCadastros["CUP_DH_COMPRA"] + "</td>";
                        retorno += "  <td>";
                        retorno += "    <a href='javascript:void(0)' onClick='verUser(" + rsCadastros["CLI_CPF"] + ")' data-toggle='modal' data-target='#dadosUsuario'><i class='fa fa-pencil-square-o' aria-hidden='true'></i></a> | ";
                        retorno += "    <a href='javascript:void(0)' title='Ver Cupons' onClick='verCupons(" + rsCadastros["CLI_CPF"] + ")' data-toggle='modal' data-target='#dadosCupom'><i class='fa fa-search' aria-hidden='true'></i></a> ";
                        retorno += "</td>";
                        retorno += "</tr>";

                        retorno2 = rsCadastros["TOTAL"].ToString();
                    }

                    Response.Write(retorno + "Ø" + retorno2);
                    Response.End();
                }
                rsCadastros.Dispose();
                rsCadastros.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void rangeIdade()
        {
            rsIdade = objBD.ExecutaSQL("EXEC totalPorIdade");
            if (rsIdade == null)
            {
                throw new Exception();
            }
            if (rsIdade.HasRows)
            {
                rsIdade.Read();
                retorno = " " + rsIdade["18"] + "|" + rsIdade["25"] + "|" + rsIdade["35"] + "|" + rsIdade["45"] + "|" + rsIdade["55"] + "|" + rsIdade["65"] + "";
                Response.Write(retorno);
                Response.End();
            }
            rsIdade.Dispose();
            rsIdade.Close();
        }

        public void totalEmail()
        {
            rsEmail = objBD.ExecutaSQL("EXEC totalEmail");
            if (rsEmail == null)
            {
                throw new Exception();
            }
            if (rsEmail.HasRows)
            {
                rsEmail.Read();
                retorno = " " + rsEmail["SEM_EMAIL"] + "|" + rsEmail["COM_EMAIL"] + "";
                Response.Write(retorno);
                Response.End();
            }
            rsEmail.Dispose();
            rsEmail.Close();
        }

    }
}