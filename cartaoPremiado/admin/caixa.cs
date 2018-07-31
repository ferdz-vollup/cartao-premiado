using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Besni_Caixa
{
    public class Premio_1
    {
        public string bilhete { get; set; }
    }
    public class Premio_2
    {
        public string bilhete { get; set; }
    }
    public class Premio_3
    {
        public string bilhete { get; set; }
    }
    public class Premio_4
    {
        public string bilhete { get; set; }
    }
    public class Premio_5
    {
        public string bilhete { get; set; }
    }

    public class Premiacao
    {
        public Premio_1 premio_1 { get; set; }
        public Premio_2 premio_2 { get; set; }
        public Premio_3 premio_3 { get; set; }
        public Premio_4 premio_4 { get; set; }
        public Premio_5 premio_5 { get; set; }
    }

    public class Concurso
    {
        public string data { get; set; }
        public string numero { get; set; }
        public string cidade { get; set; }
        public string local { get; set; }
        public Premiacao premiacao { get; set; }
    }

    public class Caixa
    {
        public Concurso concurso { get; set; }
    }
}