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
        private OleDbDataReader rsContagem, rsConcurso, rsSerie, rsResultado, rsGanhadores;

        string numeroSorte = "", numeroSerie = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            objUtils = new utils();
            objBD = new bd();

            Contagem();
            PegarResultado();
            ExbirResultado();
            resumoImportacao();
        }

        public void Contagem()
        {
            rsContagem = objBD.ExecutaSQL("EXEC pContagem");
            if (rsContagem == null)
            {
                throw new Exception();
            }

            if (rsContagem.HasRows)
            {
                rsContagem.Read();
                contagemCadastros.InnerHtml = "" + rsContagem["total_clientes"];
                //contagemInstagram.InnerHtml = "" + rsContagem["total_instagram"];
                contagemGastos.InnerHtml = "" + string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", rsContagem["total_gasto"]);
                contagemCupons.InnerHtml = "" + rsContagem["total_cupons"];
            }
            rsContagem.Close();
            rsContagem.Dispose();
        }

        public void PegarResultado()
        {
            //VERIFICAR NO BD O NÚMERO DO CONCURSO COM A COLUNA VAZIA E SE A DATA DELE É MAIOR DO QUE HOJE
            Besni_Caixa.Caixa response = AJAX.GET<Besni_Caixa.Caixa>("http://confiraloterias.com.br/api0/json.php?loteria=federal&token=fwjSAAWIwhyYh3V");

            try
            {

                DateTime dataSorteio = Convert.ToDateTime(response.concurso.data);
                String diaSemana = dataSorteio.DayOfWeek.ToString();

                //Response.Write("EXEC psConcursoPorDataSorteio '" + response.concurso.data + "'");
                //Response.End();

                rsSerie = objBD.ExecutaSQL("EXEC psConcursoPorDataSorteio '" + response.concurso.data+"'");

                if (rsSerie == null)
                {
                    throw new Exception();
                }

                if (rsSerie.HasRows)
                {
                    rsSerie.Read();

                    //Gerando a série
                    numeroSerie = rsSerie["SER_NUMERO"].ToString(); 

                    //Gerando número da sorte Besni
                    numeroSorte = numeroSorte += response.concurso.premiacao.premio_1.bilhete[4];
                    numeroSorte = numeroSorte += response.concurso.premiacao.premio_2.bilhete[4];
                    numeroSorte = numeroSorte += response.concurso.premiacao.premio_3.bilhete[4];
                    numeroSorte = numeroSorte += response.concurso.premiacao.premio_4.bilhete[4];
                    numeroSorte = numeroSorte += response.concurso.premiacao.premio_5.bilhete[4];

                    numeroSorte = numeroSerie + "-" + numeroSorte;

                      //Response.Write("Exec piuConcurso '" + response.concurso.numero + "', '" + response.concurso.data + "', '" + response.concurso.cidade + "',  '" + response.concurso.local + "',NULL,'" + response.concurso.premiacao.premio_1.bilhete + "', '" + response.concurso.premiacao.premio_2.bilhete + "', '" + response.concurso.premiacao.premio_3.bilhete + "', '" + response.concurso.premiacao.premio_4.bilhete + "', '" + response.concurso.premiacao.premio_5.bilhete + "', '" + numeroSorte + "'");
                      //Response.End();

                    //Salva os dados do Concurso
                    rsConcurso = objBD.ExecutaSQL("Exec piuConcurso '" + response.concurso.numero + "', '" + response.concurso.data + "', '" + response.concurso.cidade + "',  '" + response.concurso.local + "',NULL,'" + response.concurso.premiacao.premio_1.bilhete + "', '" + response.concurso.premiacao.premio_2.bilhete + "', '" + response.concurso.premiacao.premio_3.bilhete + "', '" + response.concurso.premiacao.premio_4.bilhete + "', '" + response.concurso.premiacao.premio_5.bilhete + "', '" + numeroSorte + "'");

                    if (rsConcurso == null)
                    {
                        throw new Exception();
                    }
                    if (rsConcurso.HasRows)
                    {
                        rsConcurso.Read();

                        //objUtils.EnviaEmail(rsLogin["CAD_EMAIL"].ToString(), "Esqueci a Senha | Promoção Besni", conteudo, "", "", null, "contatopromo@lojasbesni.com.br", null);

                       // objUtils.EnviaEmail("fernando.santos@vollupp.com", "Esqueci a Senha | Promoção Besni", "conteudo", "", "", null, "contatopromo@lojasbesni.com.br", null);

                    }
                    rsConcurso.Close();
                    rsConcurso.Dispose();

                    //GERAR GANHADORES
                    rsGanhadores = objBD.ExecutaSQL("exec psGanhadores " + response.concurso.numero);

                    if (rsGanhadores == null)
                    {
                        throw new Exception();
                    }

                    if (rsGanhadores.HasRows)
                    {
                        while (rsGanhadores.Read())
                        {
                            objBD.ExecutaSQL("EXEC piGanhadoers '" + rsGanhadores["CON_ID"] + "','" + rsGanhadores["CLI_ID"] + "','" + rsGanhadores["CUP_ID"] + "' ");
                        }
                    }

                    rsGanhadores.Dispose();
                    rsGanhadores.Close();

                }
                else
                {
                   // objUtils.EnviaEmail("fernando.santos@vollup.com", "Esqueci a Senha | Promoção Besni", "conteudo", "", "", null, "no-reply@vollup.com", null);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ExbirResultado()
        {
            //MUDAR POR PROCEDURE
            rsResultado = objBD.ExecutaSQL("EXEC psConcursoPremiacao");
            if (rsResultado == null)
            {
                throw new Exception();
            }

            if (rsResultado.HasRows)
            {
                rsResultado.Read();

                linha1.InnerHtml = "Concursos: " + rsResultado["CON_NUMERO"] + " | " + rsResultado["CON_DATA"] + " ";
                premio1.InnerHtml = "<em>" + rsResultado["PRE_BILHETE_1"] + "</em>";
                premio2.InnerHtml = "<em>" + rsResultado["PRE_BILHETE_2"] + "</em>";
                premio3.InnerHtml = "<em>" + rsResultado["PRE_BILHETE_3"] + "</em>";
                premio4.InnerHtml = "<em>" + rsResultado["PRE_BILHETE_4"] + "</em>";
                premio5.InnerHtml = "<em>" + rsResultado["PRE_BILHETE_5"] + "</em>";
                premioBesni.InnerHtml = "<strong><em>" + rsResultado["PRE_BESNI"] + "</em></strong>";
            }
            rsResultado.Close();
            rsResultado.Dispose();
        }

        public void resumoImportacao()
        {
            //MUDAR POR PROCEDURE
            rsResultado = objBD.ExecutaSQL("EXEC resumoImportacao");
            if (rsResultado == null)
            {
                throw new Exception();
            }

            if (rsResultado.HasRows)
            {
                rsResultado.Read();

                Span1.InnerHtml = "<em>" + rsResultado["NOME_PLANILHA"] + "</em>";
                Span2.InnerHtml = "<em>" + rsResultado["DAD_DH_IMPORTACAO"] + "</em>";
                Span3.InnerHtml = "<em>" + string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", rsResultado["TOTAL_COMPRA"]) + "</em>";
                Span4.InnerHtml = "<em>" + rsResultado["TOTAL_CLIENTES"] + "</em>";
                Span5.InnerHtml = "<em>" + string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", rsResultado["TICKET_MEDIO"]) + "</em>";
            }
            rsResultado.Close();
            rsResultado.Dispose();
        }
    }
}