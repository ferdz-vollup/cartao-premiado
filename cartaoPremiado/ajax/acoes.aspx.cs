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
        private OleDbDataReader rsLogin;

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

    }
}