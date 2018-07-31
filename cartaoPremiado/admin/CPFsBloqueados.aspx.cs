using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Etnia.classe;
using InnerLibs;
using System.Data.OleDb;

namespace cartaoPremiado.admin
{
    public partial class CPFsBloqueados : System.Web.UI.Page
    {
        bd objBD = new bd();
        utils objUtils = new utils();
        private OleDbDataReader rsCpfs;

        protected void Page_Load(object sender, EventArgs e)
        {
            carregaCpfs();
            objUtils = new utils();
            objBD = new bd();

            string acao = Request["acao"];

            switch (acao)
            {
                case "novoCPF":
                    novoCPF(Request["cpf"]);
                    break;
                default:
                    break;
            }
        }

        public void novoCPF(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");
            objBD.ExecutaSQL("exec piCpfBloqueado '" + cpf + "'");
            carregaCpfs();
        }
        public void carregaCpfs()
        {
            try
            {
                rsCpfs = objBD.ExecutaSQL("exec psCpfsBloqueados");

                if (rsCpfs == null)
                {
                    throw new Exception();
                }
                if (rsCpfs.HasRows)
                {
                    cpfsBloqueados.InnerHtml = "";
                    while (rsCpfs.Read())
                    {
                        cpfsBloqueados.InnerHtml += "<tr>";
                        cpfsBloqueados.InnerHtml += "<td>" + rsCpfs["C_CPF"] + "</td>";
                        cpfsBloqueados.InnerHtml += "</tr>";
                    }
                }
                rsCpfs.Dispose();
                rsCpfs.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}