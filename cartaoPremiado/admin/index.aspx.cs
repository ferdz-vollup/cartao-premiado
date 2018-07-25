using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data.SqlClient;
using Etnia.classe;
using System.Data.OleDb;
using InnerLibs;

namespace cartaoPremiado.admin
{
    public partial class index : System.Web.UI.Page
    {
        bd objBD = new bd();
        utils objUtils = new utils();
        private OleDbDataReader rsContagem;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}