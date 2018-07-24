using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PromocaoBesni.admin.inc
{
    public partial class head : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verificar se ainda está logado
            if (Session["ADM_ID"] != null)
            {
                //objUtils = new utils();
                //string acao = Request["acao"];

                //trazerCupons(Convert.ToInt16(Request["total"]));
            }
            else
            {
                //DESLOGADO
                Response.Redirect("/admin/login.aspx");
            }
        }
    }
}