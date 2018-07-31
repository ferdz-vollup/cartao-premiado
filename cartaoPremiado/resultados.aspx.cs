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


namespace cartaoPremiado.assets
{
    public partial class resultados : System.Web.UI.Page
    {
        bd objBD = new bd();
        utils objUtils = new utils();
        private OleDbDataReader rsConcurso, rsGanhadores;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            popularGanhadores();
        }

        public void popularGanhadores()
        {
            rsConcurso = objBD.ExecutaSQL("Exec psConcursoComGanhadores");

            if (rsConcurso == null)
            {
                throw new Exception();
            }

            if (rsConcurso.HasRows)
            {
                divGanhradores.InnerHtml += "<h2 class=\"basenine text-uppercase\">Ganhadores</h2>";

                rsConcurso.Read();

                divGanhradores.InnerHtml += "<h3 class=\"basenine\">" + rsConcurso["CON_DATA"] + "</h3>";
                divGanhradores.InnerHtml += "<div class=\"traco- brancocenter\"></div>";
                divGanhradores.InnerHtml += "<ul>";

                //Loop com os nomes ganhadores
                rsGanhadores = objBD.ExecutaSQL("exec psGanhadoresPorConID '" + rsConcurso["CON_ID"] + "' ");

                if (rsGanhadores == null)
                {
                    throw new Exception();
                }
                if (rsGanhadores.HasRows)
                {
                    while (rsGanhadores.Read())
                    {
                        divGanhradores.InnerHtml += "<li>";
                        divGanhradores.InnerHtml += " " + rsGanhadores["CLI_NOME"] + " <br/>";
                        divGanhradores.InnerHtml += "cód. " + rsGanhadores["CUP_NUMERO_SORTE"] + "";
                        divGanhradores.InnerHtml += "</li> ";
                    }

                    divGanhradores.InnerHtml += "</ul>";

                }
            }
            else
            {
                divGanhradores.InnerHtml += "<h2 class=\"basenine text-uppercase\" style=\"font-size:24px;\">Primeiro Sorteio</h2>";
                divGanhradores.InnerHtml += "<h3 class=\"basenine\">01/09/2018</h3>";
            }
        }
    }
}