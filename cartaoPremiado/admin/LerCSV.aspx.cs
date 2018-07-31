using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using Etnia.classe;
using InnerLibs;
using System.Data.OleDb;
using System.Threading;

namespace cartaoPremiado.admin
{
    public partial class LerCSV : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rs, rsClientes;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            /*INICIO DOS TESTES*/
            DirectoryInfo dirInfo = new DirectoryInfo(@"e:\home\promocaobesni\web\arquivos");

            BuscaArquivos(dirInfo);

            /*FIM DOS TESTES*/


        }

        private void BuscaArquivos(DirectoryInfo dir)
        {
            // lista arquivos do diretorio corrente
            foreach (FileInfo file in dir.GetFiles())
            {

                ImportarDados(file.Name);

                // aqui no caso estou guardando o nome completo do arquivo em em controle ListBox
                // voce faz como quiser
                //lbxResultado.Items.Add(file.FullName);
                // if (file.Name != "amend_campanhajulho_2_newsmobile_11.07.png")
                // {
                //    Response.Write(file.FullName + " | " + file.Name + " | " + file.Extension + "<br/>");

                // string sourceFile = @file.FullName;
                // string destinationFile = @"e:\home\promocaobesni\web\arquivos\backup\" + file.Name;

                //System.IO.File.Move(sourceFile, destinationFile);

                // }
            }
        }


        private void ImportarDados(string arquivo)
        {

            string linha = "";
            string[] linhaseparada = null;

            // StreamReader reader = new StreamReader(@"C:\svn\cartao-premiado\trunk\cartaoPremiado\arquivos\CAMPANHASORTEIO_0001_20180708_161827.csv", Encoding.UTF8, true);
            StreamReader reader = new StreamReader(@"e:\home\promocaobesni\web\arquivos\" + arquivo + "", Encoding.UTF8, true);

            //LIMPAR A TABELA ANTES DE IMPORTAR
            rs = objBD.ExecutaSQL("truncate table DadosImportados");

            while (true)
            {
                linha = reader.ReadLine();
                if (linha == null) break;
                linhaseparada = linha.Split(';');

                try
                {
                    //IMPORTAR PARA PLANILHA TEMPORARIA
                    rs = objBD.ExecutaSQL("exec piuAtualizacaoDiaria '" + linhaseparada[0] + "','" + linhaseparada[2] + "','" + linhaseparada[3].TrimStart('0') + "','" + linhaseparada[5] + "','" + linhaseparada[8] + "','" + linhaseparada[1] + "','" + linhaseparada[6] + "','" + linhaseparada[7] + "' ");
                }
                catch (Exception)
                {
                    throw;
                }

            }

            reader.Close();
            // reader.Dispose();

            //ENVIAR DADOS IMPORTADO PARA TABELA CLIENTES
            //rsClientes = 

            rsClientes = objBD.ExecutaSQL("select * from DadosImportados");

            if (rsClientes == null)
            {
                throw new Exception();
            }
            if (rsClientes.HasRows)
            {
                while (rsClientes.Read())
                {

                    //Response.Write("EXEC piuClientes '" + rsClientes["DAD_NUMERO_CARTAO"] + "', '" + rsClientes["DAD_NOME_CLIENTE"] + "', '" + rsClientes["DAD_CPF"] + "', '" + rsClientes["DAD_DT_NASCIMENTO"] + "', '" + rsClientes["DAD_VALOR_COMPRA"].ToString().Replace(",", ".") + "','" + rsClientes["DAD_DT_COMPRA"] + "', '" + rsClientes["DAD_NUMERO_SORTE"] + "' <br/> ");
                    //Response.End();


                    objBD.ExecutaSQL("EXEC piuClientes '" + rsClientes["DAD_NUMERO_CARTAO"] + "', '" + rsClientes["DAD_NOME_CLIENTE"] + "', '" + rsClientes["DAD_CPF"] + "', '" + rsClientes["DAD_DT_NASCIMENTO"] + "', '" + rsClientes["DAD_VALOR_COMPRA"].ToString().Replace(",", ".") + "','" + rsClientes["DAD_DT_COMPRA"] + "', '" + rsClientes["DAD_NUMERO_SORTE"] + "' ");
                }
            }
            
            Response.Redirect("login.aspx");

            Response.Write("Finalizado");
            Response.End();

            rs.Dispose();
            rs.Close();
        }
    }
}