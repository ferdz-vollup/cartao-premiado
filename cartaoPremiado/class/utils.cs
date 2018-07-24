using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.Text;
using System.Net;
using System.Xml;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace Etnia.classe
{
    public partial class utils : System.Web.UI.Page
    {
        private Int32 iexc, x;
        private int TotalTextos, TotalImagens, TotalLinks;
        private Byte[] Byte10 = { 10 };
        private Byte[] Byte13 = { 13 };
        private Byte[] Travessao = { 196 };
        private bd objBD;
        private OleDbDataReader rsIdioma, rsToken, rsNotificar;
        private String[] Textos, Imagens, Links;
        private string TipoImagem;
        public String[] TextosExibe, ImagensExibe, LinksTextoExibe, LinksImagemExibe;
        private string[] splitPalavras;
        private char[] splitter = { ' ' };
        private WebRequest RSS;
        private WebResponse RSS_Retorno;
        private Stream RSS_Stream;
        private XmlDocument XML;
        private XmlNodeList XML_Itens;
        private XmlNode rsResultado;
        private string TituloRSS = "";
        private string LinkRSS = "", DataRSS = "";
        private int i, TotalItens;

        public int GerarTokenAcesso()
        {
            objBD = new bd();
            int accessToken = 0;
            while (accessToken == 0)
            {
                Random newToken = new Random();
                accessToken = newToken.Next(1111, 999999);

                rsToken = objBD.ExecutaSQL("SELECT TOK_TOKEN FROM TokenUsuario WHERE TOK_TOKEN = " + accessToken);
                if (rsToken == null)
                {
                    throw new Exception();
                }
                if (rsToken.HasRows)
                {
                    accessToken = 0;
                }
                else
                {
                    break;
                }
            }
            return accessToken;
        }


        public void NotificacoesGaleria(string tipo, string titulo, int id, string campo)
        {
            bd banco = new bd();
            rsNotificar = banco.ExecutaSQL("EXEC admin_psNotificarGaleria " + id + ", '" + tipo + "', '" + campo + "'");
            if (rsNotificar == null)
            {
                throw new Exception();
            }
            if (rsNotificar.HasRows)
            {

                while (rsNotificar.Read())
                {
                    if (EnviaEmail(rsNotificar["USU_EMAIL"].ToString(), "Novo " + tipo + " no portal Brincadeiras Musicais", "Um(a) novo(a) " + tipo + " foi publicado(a) na Galeria Colaborativa de sua região") == false)
                    {
                        throw new Exception();
                    }
                }


            }
        }


        public bool Feedbacker(Exception erro)
        {

            //Cria objeto com dados do e-mail.
            MailMessage objEmail = new MailMessage();

            //Define o Campo From e ReplyTo do e-mail.
            objEmail.From = new System.Net.Mail.MailAddress("FEEDBACKER" + "<contato@agenciaetnia.com.br>");
            objEmail.To.Add("fernando@agenciaetnia.com.br, zonaro@outlook.com");

            //Define a prioridade do e-mail.
            objEmail.Priority = System.Net.Mail.MailPriority.High;

            //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
            objEmail.IsBodyHtml = true;

            //Define título do e-mail.
            objEmail.Subject = "Erro: " + erro.Source + " @ " + System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            //Define o corpo do e-mail.
            objEmail.Body = "Erro de execução no site: " + System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "<BR><BR> " + erro.Source + "<BR>" + erro.Message;

            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");


            // Anexa o arquivo a mensagemn
            // objEmail.Attachments.Add(new Attachment("", System.Net.Mime.MediaTypeNames.Application.Octet));

            //Cria objeto com os dados do SMTP
            System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient();

            //Alocamos o endereço do host para enviar os e-mails, localhost(recomendado) 
            objSmtp.Host = "smtp.agenciaetnia.com.br";
            objSmtp.Port = 587;
            objSmtp.EnableSsl = false;
            objSmtp.Credentials = new System.Net.NetworkCredential("contato@agenciaetnia.com.br", "Etnia123");
            try
            {
                objSmtp.Send(objEmail);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                //excluímos o objeto de e-mail da memória
                objEmail.Dispose();
            }

        }


        public  bool EnviaEmail(string destinatarios, string assunto, string mensagem, string ComCopia = "", string ComCopiaOculta = "", string[] anexos = null, string remetente = "contatopromo@lojasbesni.com.br", string nome = "Promoção Besni")
        {

            //Cria objeto com dados do e-mail.
            MailMessage objEmail = new MailMessage();
            //Define o Campo From e ReplyTo do e-mail. 
            objEmail.From = new System.Net.Mail.MailAddress("naoresponda@lojasbesni.com.br", nome);
            objEmail.ReplyToList.Add(remetente);
            if (string.IsNullOrWhiteSpace(destinatarios) == false)
            {
                foreach (string pessoa in destinatarios.Split(Convert.ToChar(",")))
                {
                    if (string.IsNullOrWhiteSpace(pessoa) == false)
                    {
                        objEmail.To.Add(pessoa);
                    }
                }
            }


            if (string.IsNullOrWhiteSpace(ComCopia) == false)
            {
                foreach (string pessoa in ComCopia.Split(Convert.ToChar(",")))
                {
                    if (string.IsNullOrWhiteSpace(pessoa) == false)
                    {
                        objEmail.CC.Add(pessoa);
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(ComCopiaOculta) == false)
            {
                foreach (string pessoa in ComCopiaOculta.Split(Convert.ToChar(",")))
                {
                    if (string.IsNullOrWhiteSpace(pessoa) == false)
                    {
                        objEmail.Bcc.Add(pessoa);
                    }
                }
            }

            //Define a prioridade do e-mail.
            objEmail.Priority = System.Net.Mail.MailPriority.High;

            //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
            objEmail.IsBodyHtml = true;

            //Define título do e-mail.
            objEmail.Subject = assunto;

            //Define o corpo do e-mail.

            string conteudoMensagem = "<center>";
            conteudoMensagem += "<table id='Tabela_01' width='450' height='217' border='0' cellpadding='0' cellspacing='0'>";
            conteudoMensagem += "   <center>";
            conteudoMensagem += "       <table width='450' border='0' cellpadding='0' cellspacing='0'>";
            conteudoMensagem += "           <tr>";
            conteudoMensagem += "               <td>";
            conteudoMensagem += "                    <a href='http://www.promocaobesni.com.br/?utm_source=autoresposta&utm_medium=email&utm_campaign=hotsite' target='blank' title='Visitar Besni website'><img src='http://vollup.servicos.ws/besni/emkts/images/index_01.jpg' width='450' height='175' alt='Besni' style='display:block; border:0px; '></a>";
            conteudoMensagem += "               </td>";
            conteudoMensagem += "           </tr>";

            conteudoMensagem += "           <tr>";
            conteudoMensagem += "               <td>";
            conteudoMensagem += "                    <a href='http://www.promocaobesni.com.br/?utm_source=autoresposta&utm_medium=email&utm_campaign=hotsite' target='blank' title='Visitar Besni website'><img src='http://vollup.servicos.ws/besni/emkts/images/index_02.jpg' width='450' height='83' alt='Besni' style=''display:block; border:0px; ></a>";
            conteudoMensagem += "               </td>";
            conteudoMensagem += "           </tr>";
            
            //TR DO CONTEÚDO
            conteudoMensagem += "    <tr style='margin: -90px auto 20px auto;>";
            conteudoMensagem += "        <td align='center' width='450' height='180' >";
            conteudoMensagem += mensagem;
            conteudoMensagem += "        </td>";
            conteudoMensagem += "    </tr>";

            conteudoMensagem += "   <tr style=\"margin-top:50px;\">";
            conteudoMensagem += "       <td>";
            conteudoMensagem += "           <table width=\"450\" height=\"179\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
            conteudoMensagem += "               <tr>";
            conteudoMensagem += "                   <td>";
            conteudoMensagem += "                       <img src=\"http://vollup.servicos.ws/besni/emkts/images/rodape_01.jpg\" width=\"44\" height=\"99\" alt=\"\"></td>";
            conteudoMensagem += "                   <td>";
            conteudoMensagem += "                       <a href=\"https://www.facebook.com/LojasBesni\" target=\"_blank\" title=\"Visitar Besni Facebook\"><img src=\"http://vollup.servicos.ws/besni/emkts/images/rodape_02.jpg\" width=\"17\" height=\"99\" alt=\"Facebook Link\"></a></td>";
            conteudoMensagem += "                   <td>";
            conteudoMensagem += "                       <a href=\"https://www.instagram.com/lojasbesni/\" target=\"_blank\" title=\"Visitar Besni Instagram\"><img src=\"http://vollup.servicos.ws/besni/emkts/images/rodape_03.jpg\" width=\"16\" height=\"99\" alt=\"Instagram Link\"></a></td>";
            conteudoMensagem += "                   <td>";
            conteudoMensagem += "                       <a href=\"https://www.youtube.com/user/LojasBesni/\" target =\"_blank\" title=\"Visitar Besni Youtube\"><img src=\"http://vollup.servicos.ws/besni/emkts/images/rodape_03-b.jpg\" width=\"16\" height=\"99\" alt=\"Youtube\"></a></td>";
            conteudoMensagem += "                   <td>";
            conteudoMensagem += "                       <img src=\"http://vollup.servicos.ws/besni/emkts/images/rodape_04.jpg\" width=\"196\" height=\"99\" alt=\"\"></td>";
            conteudoMensagem += "                   <td>";
            conteudoMensagem += "                       <a href=\"http://www.promocaobesni.com.br/?utm_source=autoresposta&utm_medium=email&utm_campaign=hotsite\" target=\"_blank\" title=\"Visitar Besni website\"><img src=\"http://vollup.servicos.ws/besni/emkts/images/rodape_05.jpg\" width=\"177\" height=\"99\" alt=\"Website Link\"></a></td>";
            conteudoMensagem += "               </tr>";
            conteudoMensagem += "           </table> ";
            conteudoMensagem += "      </td> ";
            conteudoMensagem += "   </tr>";

            conteudoMensagem += "        </table>";
            conteudoMensagem += "   </center>";

            conteudoMensagem += "</table></center>";

            // coloca no corpo do email
            objEmail.Body = conteudoMensagem;
            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");


            // Anexa o arquivo a mensagemn
            if (anexos != null)
            {
                for (int i = 0; i < anexos.Length; i++)
                {
                    objEmail.Attachments.Add(new Attachment(anexos[i], System.Net.Mime.MediaTypeNames.Application.Octet));
                }

            }

            //Cria objeto com os dados do SMTP
            System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient();
            //Alocamos o endereço do host para enviar os e-mails, localhost(recomendado) 
            objSmtp.Host = "maserati.lojasbesni.com.br";
            objSmtp.Port = 25;
            objSmtp.EnableSsl = false;
            objSmtp.Timeout = 999999;


            objSmtp.Credentials = new System.Net.NetworkCredential("naoresponda@lojasbesni.com.br", "bsn@2015*");
            try
            {
                objSmtp.Send(objEmail);
                objEmail.Dispose();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: ", e);
                return false;
            }
        }


        public string Diretorio(string nomediretorio)
        {
            nomediretorio = "/" + nomediretorio.Replace("/", "").Replace("\\", "");
            if (Directory.Exists(Server.MapPath(nomediretorio)) == false) { Directory.CreateDirectory(Server.MapPath(nomediretorio)); }
            return Server.MapPath(nomediretorio);
        }

        public string SimpleSplitter(string value, int Info_number)  //Qubra Requests de valores multiplos (ID, NOME, EMAIL) - separados por "|"
        {
            string[] newvalue = value.Split(Convert.ToChar("|"));
            return newvalue[Info_number];
        }

        public string CortarString(bool ellipsis, int length, string text)
        {
            // Valida caracteres
            if (text.Length < length || length == 0) return text;

            // Verifica espaços
            String trimmed = text.Substring(0, ellipsis ? length - 1 : length);

            Int32 i = trimmed.LastIndexOf(' ');
            if (i != -1)
                trimmed = trimmed.Substring(0, i);

            // Retorna texto
            return ellipsis ? string.Concat(trimmed, "...") : trimmed;
        }

        public bool isNumeric(string Valor)
        {
            try
            {
                Convert.ToInt32(Valor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string VerificaString(string Valor)
        {
            if (Valor.Length == 0)
            {
                return "&nbsp;";
            }
            else
            {
                return Valor;
            }
        }

        public string SemanaExtenso(int Semana)
        {
            switch (Semana)
            {
                case 1:
                    return "Domingo";
                case 2:
                    return "Segunda-Feira";
                case 3:
                    return "Terça-Feira";
                case 4:
                    return "Quarta-Feira";
                case 5:
                    return "Quinta-Feira";
                case 6:
                    return "Sexta-Feira";
                case 7:
                    return "Sábado";
                default:
                    return "";
            }
        }

        public string MesExtenso(int Mes)
        {
            switch (Mes)
            {
                case 1:
                    return "Janeiro";
                case 2:
                    return "Fevereiro";
                case 3:
                    return "Março";
                case 4:
                    return "Abril";
                case 5:
                    return "Maio";
                case 6:
                    return "Junho";
                case 7:
                    return "Julho";
                case 8:
                    return "Agosto";
                case 9:
                    return "Setembro";
                case 10:
                    return "Outubro";
                case 11:
                    return "Novembro";
                case 12:
                    return "Dezembro";
                default:
                    return "";
            }
        }

        public string RetiraCaracteres(string Palavra)
        {
            if (Palavra.Length > 0)
            {
                Palavra = Palavra.Replace("“", "&quot;").Replace("”", "&quot;").Replace("-", "-").Replace(Environment.NewLine, "").Replace("\n", "").Replace("<br />", "");
                Palavra = Palavra.Replace(Encoding.ASCII.GetString(Travessao), "-");
                char[] arr = Palavra.ToCharArray();
                Palavra = "";
                for (x = 0; x < arr.Length; x++)
                {
                    if (Convert.ToInt32(arr[x]) == 8211)
                    {
                        Palavra += "-";
                    }
                    else
                    {
                        Palavra += arr[x];
                    }
                }
            }
            return Regex.Replace(Palavra, @"<(.|\n)*?>", string.Empty);
            //return Palavra;
        }

        public string RetiraCaracteresComHTML(string Palavra)
        {
            if (Palavra.Length > 0)
            {
                Palavra = Palavra.Replace("“", "&quot;").Replace("”", "&quot;").Replace("-", "-").Replace(Environment.NewLine, "").Replace("\n", "");
                Palavra = Palavra.Replace(Encoding.ASCII.GetString(Travessao), "-");
                char[] arr = Palavra.ToCharArray();
                Palavra = "";
                for (x = 0; x < arr.Length; x++)
                {
                    if (Convert.ToInt32(arr[x]) == 8211)
                    {
                        Palavra += "-";
                    }
                    else
                    {
                        Palavra += arr[x];
                    }
                }
            }
            return Palavra;
        }

        public string FormataLink(string URL)
        {
            if (URL.Length > 0)
            {
                if (URL.IndexOf("http://") < 0)
                {
                    URL = "http://" + URL;
                }
            }
            return URL;
        }

        public string TrataUTF8(string Palavra)
        {
            return Encoding.UTF8.GetString(Encoding.GetEncoding("iso-8859-1").GetBytes(Palavra));
        }

        public string GerarURLAmigavel(string texto)
        {
            string s = RemoverAcentos(texto.Normalize(NormalizationForm.FormD));

            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < s.Length; k++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[k]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(s[k]);
                }
            }
            return sb.ToString().ToLower().Replace(" ", "-").Replace(".", "").Replace(",", "").Replace("?", "").Replace("&", "e");
        }

        public string RemoverAcentos(string texto)
        {
            string s = texto.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < s.Length; k++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[k]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(s[k]);
                }
            }
            return sb.ToString().ToLower();
        }

        public String TrataSQLInjection(String Texto)
        {
            try
            {
                if (Texto.Length > 0)
                {
                    String[] exc = { "select", "drop", ";", "--", "insert", "delete", "xp_", "'", "truncate", "\"" };
                    for (iexc = 0; iexc < exc.Length; iexc++)
                    {
                        Texto = Texto.Replace(exc[iexc], "");
                    }
                }
                else
                {
                    Texto = "";
                }
                return Texto;
            }
            catch
            {
                return "";
            }
        }

        public string removeAspas(string palavra)
        {
            palavra = palavra.Replace("'", "");
            palavra = palavra.Replace("\"", "");
            if (palavra.Length <= 0)
            {
                palavra = "0";
            }
            return palavra;
        }

        public string RetornaEstado(string estado)
        {
            string EstadoRetorno = "";
            if (estado.Equals("AC"))
            {
                EstadoRetorno = "Acre";
            }
            if (estado.Equals("AL"))
            {
                EstadoRetorno = "Alagoas";
            }

            if (estado.Equals("AP"))
            {
                EstadoRetorno = "Amapá";
            }

            if (estado.Equals("AM"))
            {
                EstadoRetorno = "Amazonas";
            }

            if (estado.Equals("BA"))
            {
                EstadoRetorno = "Bahia";
            }

            if (estado.Equals("CE"))
            {
                EstadoRetorno = "Ceará";
            }

            if (estado.Equals("DF"))
            {
                EstadoRetorno = "Distrito Federal";
            }

            if (estado.Equals("ES"))
            {
                EstadoRetorno = "Espírito Santo";
            }

            if (estado.Equals("GO"))
            {
                EstadoRetorno = "Goiás";
            }

            if (estado.Equals("MA"))
            {
                EstadoRetorno = "Maranhão";
            }
            if (estado.Equals("MT"))
            {
                EstadoRetorno = "Mato Grosso";
            }

            if (estado.Equals("MS"))
            {
                EstadoRetorno = "Mato Grosso do Sul";
            }

            if (estado.Equals("MG"))
            {
                EstadoRetorno = "Minas Gerais";
            }

            if (estado.Equals("PA"))
            {
                EstadoRetorno = "Pará";
            }

            if (estado.Equals("PB"))
            {
                EstadoRetorno = "Paraíba";
            }

            if (estado.Equals("PR"))
            {
                EstadoRetorno = "Paraná";
            }
            if (estado.Equals("PE"))
            {
                EstadoRetorno = "Pernambuco";
            }

            if (estado.Equals("PI"))
            {
                EstadoRetorno = "Piauí";
            }

            if (estado.Equals("RR"))
            {
                EstadoRetorno = "Roraima";
            }

            if (estado.Equals("RO"))
            {
                EstadoRetorno = "Rondônia";
            }

            if (estado.Equals("RJ"))
            {
                EstadoRetorno = "Rio de Janeiro";
            }

            if (estado.Equals("RN"))
            {
                EstadoRetorno = "Rio Grande do Norte";
            }

            if (estado.Equals("RS"))
            {
                EstadoRetorno = "Rio Grande do Sul";
            }

            if (estado.Equals("SC"))
            {
                EstadoRetorno = "Santa Catarina";
            }
            if (estado.Equals("SP"))
            {
                EstadoRetorno = "São Paulo";
            }
            if (estado.Equals("SE"))
            {
                EstadoRetorno = "Sergipe";
            }
            if (estado.Equals("TO"))
            {
                EstadoRetorno = "Tocantins";
            }

            return EstadoRetorno;

        }

        public String RemoveHTML(string texto)
        {
            return Regex.Replace(texto, "<[^>]*>", "");
        }

        public string getMD5Hash(string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }


        public string getYoutubeVideoId(string URL)
        {
            return Regex.Match(URL.Replace("&feature=youtu.be", ""), @"(?:https?:\/\/)?(?:www\.)?youtu(?:.be\/|be\.com\/watch\?v=|be\.com\/v\/)(.{8,})").Groups[1].Value;

        }

        public string FixSpecialCharacters(string Text)
        {
            Text = Text.Replace("Á", "&Aacute;");
            Text = Text.Replace("á", "&aacute;");
            Text = Text.Replace("Â", "&Acirc;");
            Text = Text.Replace("â", "&acirc;");
            Text = Text.Replace("À", "&Agrave;");
            Text = Text.Replace("à", "&agrave;");
            Text = Text.Replace("Å", "&Aring;");
            Text = Text.Replace("å", "&aring;");
            Text = Text.Replace("Ã", "&Atilde;");
            Text = Text.Replace("ã", "&atilde;");
            Text = Text.Replace("Ä", "&Auml;");
            Text = Text.Replace("ä", "&auml;");
            Text = Text.Replace("ä", "&auml;");
            Text = Text.Replace("É", "&Eacute;");
            Text = Text.Replace("é", "&eacute;");
            Text = Text.Replace("Ê", "&Ecirc;");
            Text = Text.Replace("ê", "&ecirc;");
            Text = Text.Replace("È", "&Egrave;");
            Text = Text.Replace("è", "&egrave;");
            Text = Text.Replace("Ë", "&Euml;");
            Text = Text.Replace("ë", "&euml;");
            Text = Text.Replace("Í", "&Iacute;");
            Text = Text.Replace("í", "&iacute;");
            Text = Text.Replace("Î", "&Icirc;");
            Text = Text.Replace("î", "&icirc;");
            Text = Text.Replace("Ì", "&Igrave;");
            Text = Text.Replace("ì", "&igrave;");
            Text = Text.Replace("Ï", "&Iuml;");
            Text = Text.Replace("ï", "&iuml;");
            Text = Text.Replace("Ó", "&Oacute;");
            Text = Text.Replace("ó", "&oacute;");
            Text = Text.Replace("Ô", "&Ocirc;");
            Text = Text.Replace("ô", "&ocirc;");
            Text = Text.Replace("Ò", "&Ograve;");
            Text = Text.Replace("ò", "&ograve;");
            Text = Text.Replace("Ø", "&Oslash;");
            Text = Text.Replace("ø", "&oslash;");
            Text = Text.Replace("Õ", "&Otilde;");
            Text = Text.Replace("õ", "&otilde;");
            Text = Text.Replace("Ö", "&Ouml;");
            Text = Text.Replace("ö", "&ouml;");
            Text = Text.Replace("Ú", "&Uacute;");
            Text = Text.Replace("ú", "&uacute;");
            Text = Text.Replace("Û", "&Ucirc;");
            Text = Text.Replace("û", "&ucirc;");
            Text = Text.Replace("Ù", "&Ugrave;");
            Text = Text.Replace("ù", "&ugrave;");
            Text = Text.Replace("Ü", "&Uuml;");
            Text = Text.Replace("ü", "&uuml;");
            Text = Text.Replace("Ç", "&Ccedil;");
            Text = Text.Replace("ç", "&ccedil;");
            Text = Text.Replace("Ñ", "&Ntilde");
            Text = Text.Replace("ñ", "&ntilde;");
            Text = Text.Replace("®", "&reg;");
            Text = Text.Replace("©", "&copy;");
            Text = Text.Replace("Ý", "&Yacute;");
            Text = Text.Replace("ý", "&yacute;");
            Text = Text.Replace("Ω", "&Omega;");
            return Text;

        }

        public string ImageToBase64(Stream input)
        {
            try
            {
                byte[] buffer = new byte[16 * 1024];
                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
            catch (Exception)
            {
                return "";
            }

        }

        public string ImageToBase64(string ImagePath)
        {
            try
            {
                using (System.Drawing.Image image = System.Drawing.Image.FromFile(ImagePath))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();

                        // Convert byte[] to Base64 String
                        string base64String = Convert.ToBase64String(imageBytes);
                        return base64String;
                    }
                }
            }
            catch (Exception)
            {

                return "";
            }

        }

        public string RetornarUsuarioPorURL(string Usuario, string nome)
        {

            bd banco = new bd();
            OleDbDataReader resposta = banco.ExecutaSQL("SELECT * FROM Usuario where USU_USUARIO = '" + Usuario + "'");
            if (resposta.HasRows)
            {
                resposta.Read();
                return resposta[nome].ToString();
            }
            else
            {

                switch (nome)
                {
                    case "USU_ID":
                        return Session["usuID"].ToString();
                    default:
                        return Session["nomeUsuario"].ToString();
                        break;
                }

            }

        }


        public string Delimitar(OleDbDataReader rsEditar, string DelimitadorColuna = "|", string DelimitadorLinha = "§")
        {
            string Delimitado = "";
            if (rsEditar == null) { return new Exception().Message; }
            List<string> colunas = Enumerable.Range(0, rsEditar.FieldCount).Select(rsEditar.GetName).ToList();

            if (rsEditar.HasRows)
            {
                while (rsEditar.Read())
                {
                    foreach (var coluna in colunas)
                    {
                        Delimitado += (rsEditar[coluna] + DelimitadorColuna);
                    }
                    Delimitado += DelimitadorLinha;
                }

            }
            return Delimitado;
        }


    }

    public static class ZUtils
    {
        public static string isNull(this string Text, string NullValue = "NULL", bool Quotes = true)
        {
            return string.IsNullOrWhiteSpace(Text) ? NullValue : Quotes ? "'" + Text + "'" : Text;
        }

        public static bool isBlank(this object Text)
        {
            return string.IsNullOrWhiteSpace("" + Text);
        }
         
        public static string toDelimitedString(this OleDbDataReader Reader, string ColDelimitator = "|", string RowDelimitator = "§", string TableDelimitator = "♠")
        {
            string DelimitedString = "";
            try
            {
                do
                {
                    List<string> cols = Enumerable.Range(0, Reader.FieldCount).Select(Reader.GetName).ToList();
                    while (Reader.Read())
                    {
                        foreach (var col in cols)
                        {
                            DelimitedString += (Reader[col] + ColDelimitator);
                        }
                        DelimitedString += RowDelimitator;
                    }
                    DelimitedString += TableDelimitator;
                } while (Reader.NextResult());
            }
            catch (Exception ex)
            {
                DelimitedString += ex.Message;
            }

            return DelimitedString;
        }

        public static string ToBase64(this HttpPostedFile PostedFile)
        {
            try
            {
                if (PostedFile.ContentType.ToLower() == "image/jpg" || PostedFile.ContentType.ToLower() == "image/jpeg" || PostedFile.ContentType.ToLower() == "image/pjpeg" || PostedFile.ContentType.ToLower() == "image/gif" || PostedFile.ContentType.ToLower() == "image/x-png" || PostedFile.ContentType.ToLower() == "image/png")
                {
                    Stream stream = PostedFile.InputStream;
                    byte[] fileBytes = new byte[stream.Length];
                    int byteCount = stream.Read(fileBytes, 0, (int)stream.Length);
                    return Convert.ToBase64String(fileBytes);

                }
                else
                {
                    throw new Exception(PostedFile.FileName + " não é Imagem.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         
        public static void RedirectWWW(this HttpRequest Request)
        {
            string theURL = Request.Url.ToString();
            if (!theURL.StartsWith("http://www") && !theURL.StartsWith("http://localhost"))
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location", "http://www." + theURL.Replace("http://", ""));
                HttpContext.Current.Response.End();
            }

        }

    }


}

