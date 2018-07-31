using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data.SqlClient;
using Etnia.classe;
using InnerLibs;
using System.Data.OleDb;
using System.Threading;


namespace cartaoPremiado.admin
{
    public partial class Ganhadores : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rs;
        int aux = 1;
        string classe = "", retorno = "", trava = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            string acao = Request["acao"];

            switch (acao)
            {
                case "aprovar":
                    aprovar(Request["id"], Request["valor"]);
                    break;
                case "publicar":
                    puclicar(Request["CON_ID"]);
                    break;
                default:
                    carregaUsuarios();
                   // carregaAprovados();
                    carregaPublicados();
                    break;
            }

        }

        public void carregaUsuarios()
        {
            rs = objBD.ExecutaSQL("select G.GAN_ID, C.CLI_NOME, C.CLI_CPF, p.CUP_NUMERO_SORTE,(select count(*) from Ganhadores where GAN_STATUS in(0,1)) as TOTAL, GAN_STATUS from Ganhadores G INNER JOIN Clientes c on(c.CLI_ID = g.CLI_ID) INNER JOIN Cupons p on (p.CLI_ID = g.CLI_ID) where GAN_STATUS is null or GAN_STATUS in(0,1)");

            if (rs == null)
            {
                throw new Exception();
            }
            if (rs.HasRows)
            {
                idAguardando.InnerHtml = "";

                while (rs.Read())
                {
                    if (aux % 2 == 0)

                    {
                        classe = "style=\"background-color:#f5f5f5\"";
                    }

                    //Travar aprovações após atigir limite
                    if (Convert.ToInt16(rs["TOTAL"]) > 9)

                    {
                        trava = "disabled";
                    }

                    idAguardando.InnerHtml += "<tr " + classe + ">";
                    idAguardando.InnerHtml += " <td height=\"30\">" + rs["CLI_NOME"] + "</td>";
                    idAguardando.InnerHtml += " <td style=\"text-align:center\">" + rs["CLI_CPF"] + "</td>";
                    idAguardando.InnerHtml += " <td style=\"text-align:center\">" + rs["CUP_NUMERO_SORTE"] + "</td>";
                    idAguardando.InnerHtml += " <td style=\"text-align:center\">";
                    idAguardando.InnerHtml += " <input " + trava + " onClick=\"aprovar(" + rs["GAN_ID"] + " ,this.value)\" type=\"radio\" name=\"" + rs["GAN_ID"] + "\" value=\"2\" /> Aprovar | <input  onClick=\"aprovar(" + rs["GAN_ID"] + " ,this.value)\" type=\"radio\" name=\"" + rs["GAN_ID"] + "\" value=\"1\" /> Reprovar </td>";
                    idAguardando.InnerHtml += "</tr>";

                    aux++;
                    classe = "";
                }
            }

            rs.Dispose();
            rs.Close();
        }

        public void aprovar(string id, string value)
        {

            //Verificar se limete foi atigindo
            rs = objBD.ExecutaSQL("select count(*) as TOTAL from ganhadores where GAN_sTATUS = 2");
            if (rs == null)
            {
                throw new Exception();
            }
            if (rs.HasRows)
            {
                rs.Read();

                if (Convert.ToInt16(rs["TOTAL"]) > 502 && value == "2")

                {
                    Response.Write("LIMITE");
                    Response.End();
                }
            }

            objBD.ExecutaSQL("update ganhadores set GAN_STATUS = '" + value + "' WHERE GAN_ID = '" + id + "'");

            rs = objBD.ExecutaSQL("select G.GAN_ID, G.CON_ID, C.CLI_NOME, C.CLI_CPF, (select CUP_NUMERO_SORTE from Cupons where CUP_ID = G.CUP_ID) AS CUP_NUMERO_SORTE,(select count(*) from Ganhadores where GAN_STATUS in(2)) as TOTAL, GAN_STATUS from Ganhadores G INNER JOIN Clientes c on(c.CLI_ID = g.CLI_ID) where GAN_STATUS is null or GAN_STATUS in(2)");

            if (rs == null)
            {
                throw new Exception();
            }
            if (rs.HasRows)
            {
                aux = 1;

                while (rs.Read())
                {
                    if (aux % 2 == 0)

                    {
                        classe = "style=\"background-color:#f5f5f5\"";
                    }

                    retorno += "<tr " + classe + ">";
                    retorno += " <td height=\"30\">" + rs["CLI_NOME"] + "</td>";
                    retorno += " <td style=\"text-align:center\">" + rs["CLI_CPF"] + "</td>";
                    retorno += " <td style=\"text-align:center\">" + rs["CUP_NUMERO_SORTE"] + "</td>";
                    retorno += "</tr>";

                    if (aux > 5)
                    {
                        retorno += "<tr>";
                        retorno += "<td colspan='4'>&nbsp;</td>";
                        retorno += "</tr>";

                        retorno += "<tr>";
                        retorno += "<td colspan='4' align=right><input onClick=\"puclicar(" + rs["CON_ID"] + ")\" type =\"button\" class=\"btn btn-lg btn-success btn-block\" value=\"Publicar Resultado\"></td>";
                        retorno += "</tr>";
                    }

                    aux++;
                    classe = "";

                }

            }

            Response.Write(retorno);
            Response.End();

            rs.Dispose();
            rs.Close();
        }

        public void puclicar(string CON_ID)
        {
            rs = objBD.ExecutaSQL("exec publicarGanhadores " + CON_ID + " ");

            if (rs == null)
            {
                throw new Exception();
            }
            if (rs.HasRows)
            {
                aux = 1;

                while (rs.Read())
                {
                    if (aux % 2 == 0)

                    {
                        classe = "style=\"background-color:#f5f5f5\"";
                    }

                    retorno += "<tr " + classe + ">";
                    retorno += " <td height=\"30\">" + rs["CLI_NOME"] + "</td>";
                    retorno += " <td style=\"text-align:center\">" + rs["CLI_CPF"] + " </td>";
                    retorno += " <td style=\"text-align:center\">Concurso: " + rs["CON_NUMERO"] + " | " + rs["CON_DATA"] + " </td>";
                    retorno += "</tr>";

                    aux++;
                    classe = "";

                }

            }

            Response.Write(retorno);
            Response.End();

            rs.Dispose();
            rs.Close();
        }

        public void carregaPublicados()
        {
            rs = objBD.ExecutaSQL("select G.GAN_ID, C.CLI_NOME, C.CLI_CPF, p.CUP_NUMERO_SORTE,(select count(*) from Ganhadores where GAN_STATUS in(3)) as TOTAL, GAN_STATUS, S.CON_NUMERO, S.CON_DATA from Ganhadores G  INNER JOIN Clientes c on(c.CLI_ID = g.CLI_ID)  INNER JOIN Cupons p on (p.CLI_ID = g.CLI_ID)  INNER JOIN Concursos S ON (S.CON_ID = G.CON_ID) where GAN_STATUS is null or GAN_STATUS in(3) ");

            if (rs == null)
            {
                throw new Exception();
            }
            if (rs.HasRows)
            {
                aux = 1;

                while (rs.Read())
                {
                    if (aux % 2 == 0)
                    {
                        classe = "style=\"background-color:#f5f5f5\"";
                    }

                    idPublicado.InnerHtml += "<tr " + classe + ">";
                    idPublicado.InnerHtml += " <td height=\"30\">" + rs["CLI_NOME"] + "</td>";
                    idPublicado.InnerHtml += " <td style=\"text-align:center\">" + rs["CLI_CPF"] + " </td>";
                    idPublicado.InnerHtml += " <td style=\"text-align:center\">Concurso: " + rs["CON_NUMERO"] + " | " + rs["CON_DATA"] + " </td>";
                    idPublicado.InnerHtml += "</tr>";

                    aux++;
                    classe = "";

                }

            }
            rs.Dispose();
            rs.Close();
        }
    }
}