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
    public partial class Clientes : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsCadastros, rsUser;
        string resposta = "";
        int aux = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            carregaClientes(Convert.ToInt16(Request["pagina"]));

            string acao = Request["acao"];

            switch (acao)
            {
                case "verUser":
                    verUser(Request["CAD_CPF"]);
                    break;
                default:
                    break;
            }
        }
        public void verUser(string CAD_CPF)
        {
            try
            {
                rsUser = objBD.ExecutaSQL("EXEC psClientePorCPF " + CAD_CPF);

                if (rsUser == null)
                {
                    throw new Exception();
                }
                if (rsUser.HasRows)
                {
                    while (rsUser.Read())
                    {
                        resposta = "<div class=\"row\">";
                        resposta += "   <div class=\"col-md-12\">";
                        resposta += "       <strong class=\"labelUser\">Nome: </strong>";
                        resposta += "       <div class=\"labelUser\" id=\"txtNome\">" + rsUser["CLI_NOME"].ToString() + "</div>";
                        resposta += "   </div>";
                        resposta += "</div>";

                        resposta += "<div class=\"row\" style=\"margin-top: 10px\">";
                        resposta += "    <div class=\"col-sm-6\">";
                        resposta += "        <strong class=\"labelUser\">CPF: </strong>";
                        resposta += "        <div class=\"labelUser\">" + rsUser["CLI_CPF"].ToString() + "</div>";
                        resposta += "    </div>";
                        resposta += "</div>";

                        resposta += "<div class=\"row\" style=\"margin-top: 10px\">";
                        resposta += "    <div class=\"col-sm-6\">";
                        resposta += "       <strong class=\"labelUser\">Data de nascimento: </strong>";
                        resposta += "       <div class=\"labelUser\">" + rsUser["CLI_DT_NASCIMENTO"].ToString() + "</div>";
                        resposta += "   </div>";
                        //resposta += "   <div class=\"col-sm-6\">";
                        //resposta += "       <strong class=\"labelUser\">Sexo: </strong>";
                        //resposta += "       <div class=\"labelUser\">" + rsUser["CAD_SEXO"].ToString() + "</div>";
                        //resposta += "   </div>";
                        resposta += "</div>";

                        //resposta += "<div class=\"row\" style=\"margin-top: 10px\">";
                        //resposta += "    <div class=\"col-sm-6\">";
                        //resposta += "       <strong class=\"labelUser\">Telefone: </strong>";
                        //resposta += "       <div class=\"labelUser\">" + rsUser["CAD_TELEFONE"].ToString() + "</div>";
                        //resposta += "   </div>";
                        //resposta += "   <div class=\"col-sm-6\">";
                        //resposta += "       <strong class=\"labelUser text-center\">Celular: </strong>";
                        //resposta += "       <div class=\"labelUser\">" + rsUser["CAD_CELULAR"].ToString() + "</div>";
                        //resposta += "   </div>";
                        //resposta += "</div>";

                        ////resposta += "<div class=\"row\" style=\"margin-top: 10px\">";
                        ////resposta += "   <div class=\"col-sm-12\">";
                        ////resposta += "       <strong class=\"labelUser\">E-mail: </strong>";
                        ////resposta += "           <div class=\"labelUser\">" + rsUser["CAD_EMAIL"].ToString() + "</div>";
                        ////resposta += "   </div>";
                        ////resposta += "</div>";

                        //resposta += "<div class=\"row\" style=\"margin-top: 20px\">";
                        //resposta += "   <div class=\"col-sm-12\">";
                        //resposta += "       <strong class=\"labelUser\">Cartão Besni: </strong>";
                        //resposta += "           <div class=\"labelUser\">" + rsUser["CAD_CARTAO_BESNI"].ToString() + "</div>";
                        //resposta += "   </div>";
                        //resposta += "</div>";

                        //resposta += "<hr>";

                        //resposta += " <div class=\"row\" style=\"margin-top: 15px\">";
                        //resposta += "            <div class=\"col-md-12\">";
                        //resposta += "                <h4 class=\"text-uppercase vermelho\">Endereço</h4>";
                        //resposta += "                <br>";
                        //resposta += "            </div>";
                        //resposta += "        </div>";

                        //resposta += "        <div class=\"row\" style=\"margin-top: 10px\">";
                        //resposta += "           <div class=\"col-md-8\">";
                        //resposta += "               <strong class=\"labelUser\">CEP: </strong>";
                        //resposta += "               <div class=\"labelUser\">" + rsUser["CAD_CEP"].ToString() + "</div>";
                        //resposta += "            </div>";
                        //resposta += "        </div>";

                        //resposta += "        <div class=\"row\" style=\"margin-top: 10px\">";
                        //resposta += "            <div class=\"col-sm-12\">";
                        //resposta += "                <strong class=\"labelUser\">Endereço: </strong>";
                        //resposta += "                <div class=\"labelUser\">" + rsUser["CAD_LOGRADOURO"].ToString() + ", " + rsUser["CAD_NUMERO"].ToString() + "</div>";
                        //resposta += "            </div>";
                        //resposta += "        </div>";

                        //resposta += "        <div class=\"row\" style=\"margin-top: 10px\">";
                        //resposta += "            <div class=\"col-sm-6\">";
                        //resposta += "                <strong class=\"labelUser\">Complemento: </strong>";
                        //resposta += "                <div class=\"labelUser\">" + rsUser["CAD_COMPLEMENTO"].ToString() + "</div>";
                        //resposta += "            </div>";
                        //resposta += "            <div class=\"col-sm-6\">";
                        //resposta += "                <strong class=\"labelUser text-center\">Bairro: </strong>";
                        //resposta += "                <div class=\"labelUser\">" + rsUser["CAD_BAIRRO"].ToString() + "</div>";
                        //resposta += "            </div>";
                        //resposta += "        </div>";

                        //resposta += "        <div class=\"row\" style=\"margin-top: 10px\">";
                        //resposta += "            <div class=\"col-sm-6\">";
                        //resposta += "                <strong class=\"labelUser\">Cidade: </strong>";
                        //resposta += "                <div class=\"labelUser\">" + rsUser["CAD_CIDADE"].ToString() + "</div>";
                        //resposta += "            </div>";
                        //resposta += "            <div class=\"col-sm-6\">";
                        //resposta += "                <strong class=\"labelUser text-center\">UF: </strong>";
                        //resposta += "                <div class=\"labelUser\">" + rsUser["CAD_ESTADO"].ToString() + "</div>";
                        //resposta += "            </div>";
                        //resposta += "        </div>";
                    }
                }
                rsUser.Dispose();
                rsUser.Close();
            }
            catch (Exception)
            {
                throw;
            }

            Response.Write(resposta);
            Response.End();

        }

        public void carregaClientes(int pagina)
        {
            try
            {
                if (pagina == 0) { pagina = 1; }

                rsCadastros = objBD.ExecutaSQL("EXEC psClientesPaginados " + pagina + " ");

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
                        usuariosCadastrados.InnerHtml += "  <td>" + rsCadastros["CLI_NUMERO_CARTAO"] + "</td>";
                        usuariosCadastrados.InnerHtml += "  <td>" + rsCadastros["CLI_CPF"] + "</td>";
                        usuariosCadastrados.InnerHtml += "  <td>";
                        usuariosCadastrados.InnerHtml += "      <a href='javascript:void(0)' title='Dados do Usuário' onClick='verUser(" + rsCadastros["CLI_CPF"] + ")' data-toggle='modal' data-target='#dadosUsuario'><i class='fa fa-pencil-square-o' aria-hidden='true'></i></a> | ";
                        usuariosCadastrados.InnerHtml += "      <a href='javascript:void(0)' title='Ver Cupons' onClick='verCupons(" + rsCadastros["CLI_CPF"] + ")' data-toggle='modal' data-target='#dadosCupom'><i class='fa fa-search' aria-hidden='true'></i></a> ";
                        usuariosCadastrados.InnerHtml += "</td>";
                        usuariosCadastrados.InnerHtml += "</tr>";

                        if (aux == 0)
                        {
                            totalizador.InnerHtml = rsCadastros["TOTAL"].ToString();

                            //PAGINAÇÃO
                            if (Convert.ToInt16(rsCadastros["TOTAL_PAGINAS"]) > 1)
                            {
                                //Validações do voltar
                                if (Convert.ToInt16(rsCadastros["PAGINA"]) > 1)
                                {
                                    int pgVoltar = Convert.ToInt16(rsCadastros["PAGINA"]) - 1;
                                    paginacao.InnerHtml += "<li class=\"paginate_button previous\" aria-controls=\"dataTables-example\" tabindex=\"0\" id=\"dataTables-example_previous\"><a href=\"javascript:void(0);\" onClick=\"pagina('" + pgVoltar + "')\"> Anterior </a></ li>";
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
                                if ((cont_fim - cont_inicio) >= 2) { cont_fim = (cont_inicio + 4); }

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
                                        paginacao.InnerHtml += "   <li class=\"paginate_button\" aria-controls=\"dataTables-example\" tabindex=\"0\"><a href=\"javascript:void(0);\" onClick=\"pagina('" + aux + "')\">" + aux + "</ a ></ li >";
                                    }
                                }

                                //Validações do avançar
                                if (Convert.ToInt16(rsCadastros["PAGINA"]) < Convert.ToInt16(rsCadastros["TOTAL_PAGINAS"]))
                                {
                                    int pgAvancar = Convert.ToInt16(rsCadastros["PAGINA"]) + 1;
                                    paginacao.InnerHtml += "<li class=\"paginate_button next\" aria-controls=\"dataTables-example\" tabindex=\"0\" id=\"dataTables-example_next\"><a href=\"javascript:void(0);\" onClick=\"pagina('" + pgAvancar + "')\" > Próximo </a ></li>";

                                }
                                else
                                {
                                    paginacao.InnerHtml += "<li class=\"paginate_button next disabled\" aria-controls=\"dataTables-example\" tabindex=\"0\" id=\"dataTables-example_next\"><a href=\"javascript:void(0);\"> Próximo </a ></li>";
                                }
                            }
                        }

                        aux++;
                    }
                   //  carregarTotal();
                }
                rsCadastros.Dispose();
                rsCadastros.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public void carregarTotal()
        //{
        //    rsTotal = objBD.ExecutaSQL("select count(*) as total from Clientes");

        //    if (rsTotal == null)
        //    {
        //        throw new Exception();
        //    }
        //    if (rsTotal.HasRows)
        //    {
        //        rsTotal.Read();

        //        totalizador.InnerHtml = "Total de <strong>" + rsTotal["total"].ToString() + "</strong> clientes ativos";
        //    }
        //}

    }
}