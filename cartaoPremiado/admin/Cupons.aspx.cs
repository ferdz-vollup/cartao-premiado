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
    public partial class Cupons : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsCupons;
        //string resposta = "";
        int aux = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            string acao = Request["acao"];

            switch (acao)
            {
                default:
                    carregaCupons(Convert.ToInt16(Request["pagina"]));
                    break;
            }

        }

        public void carregaCupons(int pagina)
        {
            try
            {
                if (pagina == 0) { pagina = 1; }

                rsCupons = objBD.ExecutaSQL("EXEC psCuponsPaginados " + pagina + " ");

                if (rsCupons == null)
                {
                    throw new Exception();
                }
                if (rsCupons.HasRows)
                {
                    while (rsCupons.Read())
                    {
                        cuponsCadastrados.InnerHtml += "<tr>";
                        cuponsCadastrados.InnerHtml += "  <td>" + rsCupons["CLI_NOME"] + "</td>";
                        cuponsCadastrados.InnerHtml += "  <td>" + rsCupons["CUP_NUMERO_SORTE"] + "</td>";
                        cuponsCadastrados.InnerHtml += "  <td>" + rsCupons["CUP_VALOR"] + "</td>";
                        cuponsCadastrados.InnerHtml += "  <td>" + rsCupons["CUP_DH_COMPRA"] + "</td>";
                        //cuponsCadastrados.InnerHtml += "  <td>";
                        //cuponsCadastrados.InnerHtml += "      <a href='javascript:void(0)' title='Dados do Usuário' onClick='verUser(" + rsCupons["CLI_CPF"] + ")' data-toggle='modal' data-target='#dadosUsuario'><i class='fa fa-pencil-square-o' aria-hidden='true'></i></a> | ";
                        //cuponsCadastrados.InnerHtml += "      <a href='javascript:void(0)' title='Ver Cupons' onClick='verCupons(" + rsCupons["CLI_CPF"] + ")' data-toggle='modal' data-target='#dadosCupom'><i class='fa fa-search' aria-hidden='true'></i></a> ";
                        //cuponsCadastrados.InnerHtml += "</td>";
                        cuponsCadastrados.InnerHtml += "</tr>";

                        if (aux == 0)
                        {
                            totalizador.InnerHtml = rsCupons["TOTAL"].ToString();

                            //PAGINAÇÃO
                            if (Convert.ToInt16(rsCupons["TOTAL_PAGINAS"]) > 1)
                            {
                                //Validações do voltar
                                if (Convert.ToInt16(rsCupons["PAGINA"]) > 1)
                                {
                                    int pgVoltar = Convert.ToInt16(rsCupons["PAGINA"]) - 1;
                                    paginacao.InnerHtml += "<li class=\"paginate_button previous\" aria-controls=\"dataTables-example\" tabindex=\"0\" id=\"dataTables-example_previous\"><a href=\"cupons.aspx?pagina=" + pgVoltar + "\" onClick=\"pagina('" + pgVoltar + "')\"> Anterior </a></ li>";
                                }
                                else
                                {
                                    paginacao.InnerHtml += "<li class=\"paginate_button previous disabled\" aria-controls=\"dataTables-example\" tabindex=\"0\" id=\"dataTables-example_previous\"><a href=\"javascript:void(0);\"> Anterior </a></ li>";
                                }
                                //ajuste de primeira página
                                int cont_inicio = Convert.ToInt16(rsCupons["PAGINA"]) - 1;
                                if (cont_inicio <= 0) { cont_inicio = 1; }

                                //ajueste de última página
                                int cont_fim = Convert.ToInt16(rsCupons["TOTAL_PAGINAS"]);
                                if ((cont_fim - cont_inicio) >= 2) { cont_fim = (cont_inicio + 7); }

                                for (int aux = cont_inicio; aux < cont_fim + 1; aux++)
                                {
                                    //verificar se é a página atual
                                    if (Convert.ToInt16(rsCupons["PAGINA"]) == aux)
                                    {
                                        //paginacao.InnerHtml += "   <li><a href=\"javascript:void(0);\" title=\"Página atual\" class=\"ativo\">" + aux + "</a></li>";
                                        paginacao.InnerHtml += "   <li class=\"paginate_button active\" aria-controls=\"dataTables-example\" tabindex=\"0\"><a href=\"#\">" + aux + "</ a ></ li >";

                                    }
                                    else
                                    {
                                        //  paginacao.InnerHtml += "   <li><a href=\"javascript:void(0);\" onClick=\"pagina('" + aux + "')\" title=\"Página " + aux + "\">" + aux + "</a></li>";
                                        paginacao.InnerHtml += "   <li class=\"paginate_button\" aria-controls=\"dataTables-example\" tabindex=\"0\"><a href=\"cupons.aspx?pagina=" + aux + "\" onClick=\"pagina('" + aux + "')\">" + aux + "</ a ></ li >";
                                    }
                                }

                                //Validações do avançar
                                if (Convert.ToInt16(rsCupons["PAGINA"]) < Convert.ToInt16(rsCupons["TOTAL_PAGINAS"]))
                                {
                                    int pgAvancar = Convert.ToInt16(rsCupons["PAGINA"]) + 1;
                                    paginacao.InnerHtml += "<li class=\"paginate_button next\" aria-controls=\"dataTables-example\" tabindex=\"0\" id=\"dataTables-example_next\"><a href=\"cupons.aspx?pagina=" + pgAvancar + "\" onClick=\"pagina('" + pgAvancar + "')\" > Próximo </a ></li>";

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
                rsCupons.Dispose();
                rsCupons.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}