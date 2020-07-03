using System;
using System.Collections.Generic;
using System.Text;

namespace WSSisConsultaHelper.Models {
    public class Pf {
        public string Cpf { get; set; }
        public string ufFiscal { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string DtNasc { get; set; }
        public string NomeMae { get; set; }
        public string SituacaoRFB { get; set; }
        public DateTime DtSituacaoRFB { get; set; }
        public string TituloEleitor { get; set; }
        public string Rg { get; set; }
        public string RendaPresumida { get; set; }

    }
}
