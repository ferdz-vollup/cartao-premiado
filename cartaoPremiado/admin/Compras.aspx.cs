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
    public partial class Compras : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsInicio, rsCadastros;
        int aux = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            PopularDataInicio();
            carregaCompras(Convert.ToInt16(Request["pagina"]));
        }

        public void PopularDataInicio()
        {
            rsInicio = objBD.ExecutaSQL("select convert(varchar(10),COM_DT_COMPRA, 103) as COM_DT_COMPRA from Compras Group by COM_DT_COMPRA order by COM_DT_COMPRA");
            if (rsInicio == null)
            {
                throw new Exception();
            }
            if (rsInicio.HasRows)

            {
                System.Web.UI.WebControls.ListItem S = new System.Web.UI.WebControls.ListItem();
                S.Value = "0";
                S.Text = "Data de início";
                dtInicio.Items.Add(S);

                while (rsInicio.Read())
                {
                    System.Web.UI.WebControls.ListItem R = new System.Web.UI.WebControls.ListItem();
                    R.Value = rsInicio["COM_DT_COMPRA"].ToString();
                    R.Text = rsInicio["COM_DT_COMPRA"].ToString();
                    dtInicio.Items.Add(R);
                }
            }
            rsInicio.Close();
            rsInicio.Dispose();
        }

        public void carregaCompras(int pagina)
        {
            try
            {
                if (pagina == 0) { pagina = 1; }

                rsCadastros = objBD.ExecutaSQL("EXEC psComprasPaginadas " + pagina + " ");

                if (rsCadastros == null)
                {
                    throw new Exception();
                }
                if (rsCadastros.HasRows)
                {
                    while (rsCadastros.Read())
                    {
                        usuariosCadastrados.InnerHtml += "<tr>";
                        usuariosCadastrados.InnerHtml += "  <td>" + rsCadastros["CLI_NOME"] + "</td>";
                        usuariosCadastrados.InnerHtml += "  <td>" + rsCadastros["COM_VALOR"] + "</td>";
                        usuariosCadastrados.InnerHtml += "  <td>" + rsCadastros["COM_DT_COMPRA"] + "</td>";
                       // usuariosCadastrados.InnerHtml += "  <td>";
                       // usuariosCadastrados.InnerHtml += "      <a href='javascript:void(0)' title='Dados do Usuário' onClick='verUser(" + rsCadastros["CLI_CPF"] + ")' data-toggle='modal' data-target='#dadosUsuario'><i class='fa fa-pencil-square-o' aria-hidden='true'></i></a>";
                        // usuariosCadastrados.InnerHtml += "      <a href='javascript:void(0)' title='Ver Cupons' onClick='verCupons(" + rsCadastros["CLI_CPF"] + ")' data-toggle='modal' data-target='#dadosCupom'><i class='fa fa-search' aria-hidden='true'></i></a> ";
                      //  usuariosCadastrados.InnerHtml += "</td>";
                        usuariosCadastrados.InnerHtml += "</tr>";

                        if (aux == 0)
                        {
                            totalizador.InnerHtml = rsCadastros["TOTAL"].ToString();
                            totalizador4.InnerHtml = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", rsCadastros["TOTAL_VENDAS"]);

                            //PAGINAÇÃO
                            if (Convert.ToInt16(rsCadastros["TOTAL_PAGINAS"]) > 1)
                            {
                                //Validações do voltar
                                if (Convert.ToInt16(rsCadastros["PAGINA"]) > 1)
                                {
                                    int pgVoltar = Convert.ToInt16(rsCadastros["PAGINA"]) - 1;

                                    paginacao.InnerHtml += "<li class=\"paginate_button previous\" aria-controls=\"dataTables-example\" tabindex=\"0\" id=\"dataTables-example_previous\"><a href=\"compras.aspx?pagina=1\" title=\"Primeira página\" \"> << </a></ li>";

                                    paginacao.InnerHtml += "<li class=\"paginate_button previous\" aria-controls=\"dataTables-example\" tabindex=\"0\" id=\"dataTables-example_previous\"><a href=\"compras.aspx?pagina=" + pgVoltar + "\" \"> Anterior </a></ li>";
                                }
                                else
                                {
                                    paginacao.InnerHtml += "<li class=\"paginate_button previous disabled\" aria-controls=\"dataTables-example\" tabindex=\"0\" id=\"dataTables-example_previous\"><a href=\"javascript:void(0);\"> Anterior </a></ li>";
                                }
                                //ajuste de primeira página
                                int cont_inicio = Convert.ToInt16(rsCadastros["PAGINA"]) - 1;
                                if (cont_inicio <= 0) { cont_inicio = 1; }

                                //ajueste de última página
                                int cont_fim = Convert.ToInt16(rsCadastros["TOTAL_PAGINAS"]);
                                if ((cont_fim - cont_inicio) >= 2) { cont_fim = (cont_inicio + 7); }

                                for (int aux = cont_inicio; aux < cont_fim + 1; aux++)
                                {
                                    //verificar se é a página atual
                                    if (Convert.ToInt16(rsCadastros["PAGINA"]) == aux)
                                    {
                                        //paginacao.InnerHtml += "   <li><a href=\"javascript:void(0);\" title=\"Página atual\" class=\"ativo\">" + aux + "</a></li>";
                                        paginacao.InnerHtml += "   <li class=\"paginate_button active\" aria-controls=\"dataTables-example\" tabindex=\"0\"><a href=\"#\">" + aux + "</ a ></ li >";

                                    }
                                    else
                                    {
                                        //  paginacao.InnerHtml += "   <li><a href=\"javascript:void(0);\" onClick=\"pagina('" + aux + "')\" title=\"Página " + aux + "\">" + aux + "</a></li>";
                                        paginacao.InnerHtml += "   <li class=\"paginate_button\" aria-controls=\"dataTables-example\" tabindex=\"0\"><a href=\"compras.aspx?pagina=" + aux + "\" \">" + aux + "</ a ></ li >";
                                    }
                                }

                                //Validações do avançar
                                if (Convert.ToInt16(rsCadastros["PAGINA"]) < Convert.ToInt16(rsCadastros["TOTAL_PAGINAS"]))
                                {
                                    int pgAvancar = Convert.ToInt16(rsCadastros["PAGINA"]) + 1;
                                    paginacao.InnerHtml += "<li class=\"paginate_button next\" aria-controls=\"dataTables-example\" tabindex=\"0\" id=\"dataTables-example_next\"><a href=\"compras.aspx?pagina=" + pgAvancar + "\"> Próximo </a ></li>";


                                    paginacao.InnerHtml += "<li class=\"paginate_button next\" aria-controls=\"dataTables-example\" tabindex=\"0\" id=\"dataTables-example_next\"><a href=\"compras.aspx?pagina=" + Convert.ToInt16(rsCadastros["TOTAL_PAGINAS"]) + "\" title=\"Última página\" \"> >> </a ></li>";
                                }
                                else
                                {
                                    paginacao.InnerHtml += "<li class=\"paginate_button next disabled\" aria-controls=\"dataTables-example\" tabindex=\"0\" id=\"dataTables-example_next\"><a href=\"javascript:void(0);\"> Próximo </a ></li>";
                                }
                            }
                        }

                        aux++;
                    }
                }
                rsCadastros.Dispose();
                rsCadastros.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}