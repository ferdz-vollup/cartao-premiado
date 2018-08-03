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
        private OleDbDataReader rsLogin, rsCadastros, rsIdade, rsEmail, rs;

        string retorno = "", retorno2 = "", concurso = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            string acao = Request["acao"];

            switch (acao)
            {
                //SITE
                case "buscarCupons":
                    buscarCupons(Request["cpf"].ToString(), Request["nascimento"].ToString());
                    break;
                case "atualizaEmail":
                    atualizaEmail(Request["cpf"].ToString(), Request["email"].ToString());
                    break;

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
                case "donwloadGanhadores":
                    donwloadGanhadores();
                    break;
                case "donwloadCupons":
                    donwloadCupons();
                    break;
                default:
                    break;
            }
        }

        //SITE
        public void buscarCupons(string cpf, string nascimento)
        {
            rs = objBD.ExecutaSQL("EXEC psuCuponsPorCPF '" + cpf.Replace(".","").Replace("-", "") + "','" + nascimento + "'");

            if (rs == null)
            {
                throw new Exception();
            }

            if (rs.HasRows)
            {
                retorno += "<div class=\"ganhadores\">";
                retorno += "<h2 class=\"basenine text-uppercase\">Cupons</h2>";
                retorno += "<div class=\"traco-branco center\"></div>";

                retorno += "<ul>";

                while (rs.Read())
                {
                    if(rs["CUP_NUMERO_SORTE"].ToString() =="vazio")
                    {
                        Response.Write("vazio");
                        Response.End();
                    }

                    retorno += "<li>cód. " + rs["CUP_NUMERO_SORTE"] +"</li>";
                }
                retorno += "</ul>";
                retorno += "</div>";

                Response.Write(retorno);
                Response.End();

            }
            rs.Close();
            rs.Dispose();
        }

        public void atualizaEmail(string cpf, string email)
        {

            objBD.ExecutaSQL("EXEC puClienteEmail '" + cpf.Replace(".", "").Replace("-", "") + "','" + email + "'");

            Response.Write("Seu e-mail foi registrado e em breve receberá uma cópia de seus números da sorte!");
            Response.End();

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
                        retorno += "    <a href='javascript:void(0)' onClick='verUser(" + rsCadastros["CLI_CPF"] + ")' data-toggle='modal' data-target='#dadosUsuario'><i class='fa fa-pencil-square-o' aria-hidden='true'></i></a> ";
                       // retorno += "    <a href='javascript:void(0)' title='Ver Cupons' onClick='verCupons(" + rsCadastros["CLI_CPF"] + ")' data-toggle='modal' data-target='#dadosCupom'><i class='fa fa-search' aria-hidden='true'></i></a> ";
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

        public void donwloadGanhadores()
        {
            {
                Response.Clear();
                Response.AddHeader("content-disposition", string.Format("attachment;filename=Ganhadores.xls", "xyz"));

                Response.ContentType = "application/ms-excel";
                Response.ContentEncoding = System.Text.Encoding.Default;

                StringBuilder sb = new StringBuilder();

                sb.Append("<style type=\"text/css\">\r\n");
                sb.Append(".tabHead\r\n");
                sb.Append("{\r\n");
                sb.Append("   background-color: #cccccc;\r\n");
                sb.Append("   border: solid 1px black;\r\n");
                sb.Append("}\r\n");
                sb.Append(".tabRow\r\n");
                sb.Append("{\r\n");
                sb.Append("   border: solid 1px black;\r\n");
                sb.Append("}\r\n");
                sb.Append("</style>\r\n\r\n");

                //SORTEIO E NÚMEROS
                //Header
                sb.AppendFormat("<table>\r\n");
                sb.AppendFormat("<thead>\r\n");
                sb.AppendFormat("<tr>\r\n");
                sb.AppendFormat("\t<td colspan='2' class=\"tabHead\">Extração da Loteria Federal</td>\r\n");
                sb.AppendFormat("</tr>\r\n");

                //sb.AppendFormat("<tr>\r\n");
                //sb.AppendFormat("\t<td>&nbsp;</td>\r\n");
                //sb.AppendFormat("\t<td>&nbsp;</td>\r\n");
                //sb.AppendFormat("\t<td>&nbsp;</td>\r\n");
                //sb.AppendFormat("\t<td>&nbsp;</td>\r\n");
                //sb.AppendFormat("\t<td>&nbsp;</td>\r\n");
                //sb.AppendFormat("\t<td>&nbsp;</td>\r\n");
                //sb.AppendFormat("\t<td ><img src=\"http://www.promocaobesni.com.br/assets/imagens/logo-rodape.png\" style=\"width:140px; margin-left:35px;\"></td>\r\n");
                //sb.AppendFormat("</tr>\r\n");

                sb.AppendFormat("</thead>\r\n");
                sb.AppendFormat("<tbody>\r\n");

                rs = objBD.ExecutaSQL("EXEC psConcursoPremiacao");
                if (rs == null)
                {
                    throw new Exception();
                }

                if (rs.HasRows)
                {
                    rs.Read();

                    concurso = rs["CON_NUMERO"].ToString();

                    //Row
                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td colspan='2'>Concurso: " + rs["CON_NUMERO"] + " (" + rs["CON_DATA"] + ")</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");

                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td colspan='2'>&nbsp;</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");
                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td class=\"tabHead\">Prêmio</td>\r\n");
                    sb.AppendFormat("\t<td class=\"tabHead\">Bilhete</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");

                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">1º</td>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">" + rs["PRE_BILHETE_1"] + "</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");

                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">2º</td>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">" + rs["PRE_BILHETE_2"] + "</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");

                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">3º</td>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">" + rs["PRE_BILHETE_3"] + "</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");

                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">4º</td>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">" + rs["PRE_BILHETE_4"] + "</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");

                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">5º</td>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">" + rs["PRE_BILHETE_5"] + "</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");

                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td colspan='18'>&nbsp;</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");

                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td colspan='2' class=\"tabHead\">Sorteio Periódico</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");

                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">Série</td>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">" + rs["PRE_BESNI"].ToString().Substring(0, 1) + "</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");

                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">Número</td>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">" + rs["PRE_BESNI"].ToString().Substring(2, 5) + "</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");

                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td colspan='5'>&nbsp;</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");

                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td colspan='5'><b>Apuração da série</b></td>\r\n");
                    sb.AppendFormat("</tr>\r\n");

                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td td colspan='5'>A definição da série participante se dará a partir dos prêmios da Extração da Loteria Federal, lidos de cima para baixo, por meio da combinação das dezenas simples do primeiro ao terceiro prêmio.</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");

                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td colspan='5'>&nbsp;</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");

                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td colspan='5'>Caso o número de série encontrado seja superior à maior série da apuração, deverá ser subtraída a quantidade de séries da apuração, do número de série encontrado, tantas vezes quantas forem necessárias, até que o número obtido esteja dentro do intervalo de séries da apuração. Caso o número de série encontrado seja inferior à menor série da apuração, deverá ser adicionada a quantidade de séries da apuração, do número de série encontrado, tantas vezes quantas forem necessárias, até que o número obtido esteja dentro do intervalo de séries da apuração.</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");

                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td colspan='5'>&nbsp;</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");

                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td colspan='5'>&nbsp;</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");
                }
                rs.Close();
                rs.Dispose();

                //Footer
                sb.AppendFormat("</tbody>\r\n");
                sb.AppendFormat("</table>\r\n");

                //QUEBRA DE TABLELA
                //Row
                sb.AppendFormat("<tr>\r\n");
                sb.AppendFormat("\t<td colspan='5'>&nbsp;</td>\r\n");
                sb.AppendFormat("</tr>\r\n");

                //GANHADORES
                //Header
                sb.AppendFormat("<table>\r\n");
                sb.AppendFormat("<thead>\r\n");
                sb.AppendFormat("<tr>\r\n");
                sb.AppendFormat("\t<td colspan='5' class=\"tabHead\"><b>GANHADORES</b></td>\r\n");
                sb.AppendFormat("</tr>\r\n");
                sb.AppendFormat("</thead>\r\n");
                sb.AppendFormat("<tbody>\r\n");

                //Row
                sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">Número da Sorte</td>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">Nome</td>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">CPF</td>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">Nascimento</td>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">E-mail</td>\r\n");
                sb.AppendFormat("</tr>\r\n");

                //TIRAR PARAMETRO FIXO
                rs = objBD.ExecutaSQL("Select P.CUP_NUMERO_SORTE, C.CLI_NOME, C.CLI_CPF, Convert(varchar(10), C.CLI_DT_NASCIMENTO, 103) as CLI_DT_NASCIMENTO, C.CLI_EMAIL from Ganhadores G INNER JOIN Cupons P ON (P.CUP_ID = G.CUP_ID) INNER JOIN Clientes C ON (C.CLI_ID = G.CLI_ID) Where G.CON_ID IN (Select  CON_ID from Concursos where CON_NUMERO = "+ concurso + ")");

                if (rs == null)
                {
                    throw new Exception();
                }

                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        sb.AppendFormat("<tr>\r\n");
                            sb.AppendFormat("\t<td >" + rs["CUP_NUMERO_SORTE"] + "</td>\r\n");
                            sb.AppendFormat("\t<td >" + rs["CLI_NOME"] + "</td>\r\n");
                            sb.AppendFormat("\t<td >" + rs["CLI_CPF"] + "</td>\r\n");
                            sb.AppendFormat("\t<td >" + rs["CLI_DT_NASCIMENTO"] + "</td>\r\n");
                            sb.AppendFormat("\t<td >" + rs["CLI_EMAIL"] + "</td>\r\n");
                        sb.AppendFormat("</tr>\r\n");

                    }

                    rs.Close();
                    rs.Dispose();
                }

                //Footer
                sb.AppendFormat("</tbody>\r\n");
                sb.AppendFormat("</table>\r\n");

                //FIM GANHADORES

                rs.Close();
                rs.Dispose();
                
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(sb.ToString());
                Response.End();

                // return null;
            }
        }

        public void donwloadCupons()
        {
            Response.Clear();
            Response.AddHeader("content-disposition", string.Format("attachment;filename=Cupons.xls", "xyz"));

            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Default;

            StringBuilder sb = new StringBuilder();

            sb.Append("<style type=\"text/css\">\r\n");
            sb.Append(".tabHead\r\n");
            sb.Append("{\r\n");
            sb.Append("   background-color: #cccccc;\r\n");
            sb.Append("   border: solid 1px black;\r\n");
            sb.Append("}\r\n");
            sb.Append(".tabRow\r\n");
            sb.Append("{\r\n");
            sb.Append("   border: solid 1px black;\r\n");
            sb.Append("}\r\n");
            sb.Append("</style>\r\n\r\n");

            //SORTEIO E NÚMEROS
            //Header
            sb.AppendFormat("<table>\r\n");
            sb.AppendFormat("<thead>\r\n");
            sb.AppendFormat("<tr>\r\n");
            sb.AppendFormat("\t<td colspan='2' class=\"tabHead\">LISTA DE CUPONS GERADOS</td>\r\n");
            sb.AppendFormat("</tr>\r\n");

            sb.AppendFormat("</thead>\r\n");
            sb.AppendFormat("<tbody>\r\n");


            sb.AppendFormat("<tr>\r\n");
            sb.AppendFormat("\t<td colspan='2'>&nbsp;</td>\r\n");
            sb.AppendFormat("</tr>\r\n");
            sb.AppendFormat("<tr>\r\n");
            sb.AppendFormat("\t<td class=\"tabHead\">Número da Sorte</td>\r\n");
            sb.AppendFormat("\t<td class=\"tabHead\">Nome do Cliente</td>\r\n");
            sb.AppendFormat("</tr>\r\n");

            rs = objBD.ExecutaSQL("select DISTINCT CUP_NUMERO_SORTE, (select CLI_NOME FROM Clientes WHERE CLI_ID = Cupons.CLI_ID) as Nome from Cupons ORDER BY CUP_NUMERO_SORTE");

            if (rs == null)
            {
                throw new Exception();
            }
            if (rs.HasRows)
            {
                while (rs.Read())
                {
                    sb.AppendFormat("<tr>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">" + rs["CUP_NUMERO_SORTE"] + "</td>\r\n");
                    sb.AppendFormat("\t<td class=\"tabRow\">" + rs["Nome"] + "</td>\r\n");
                    sb.AppendFormat("</tr>\r\n");
                }

            }

            //Footer
            sb.AppendFormat("</tbody>\r\n");
            sb.AppendFormat("</table>\r\n");

            rs.Close();
            rs.Dispose();

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(sb.ToString());
            Response.End();
        }

    }
}