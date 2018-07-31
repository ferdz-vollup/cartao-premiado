using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace cartaoPremiado.admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"e:\home\promocaobesni\web\arquivos");
           // MoverArquivos(dirInfo);
        }

        private void MoverArquivos(DirectoryInfo dir)
        {
            // lista arquivos do diretorio corrente
            foreach (FileInfo file in dir.GetFiles())
            {
                string sourceFile = @file.FullName;
                string destinationFile = @"e:\home\promocaobesni\web\arquivos\backup\" + file.Name;

                System.IO.File.Move(sourceFile, destinationFile);

                //if (System.IO.File.Exists(@"e:\home\promocaobesni\web\arquivos\" + file.Name))
                //{
                //    System.IO.File.Delete(@"e:\home\promocaobesni\web\arquivos\" + file.Name);
                //}
            }
        }
    }
}