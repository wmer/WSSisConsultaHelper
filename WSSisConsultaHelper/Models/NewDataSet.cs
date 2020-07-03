using System;
using System.Collections.Generic;
using System.Text;

namespace WSSisConsultaHelper.Models {
    public class NewDataSet {
        public Pf Pf { get; set; }
        public Telefones Telefones { get; set; }
        public List<Celulare> Celulares { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public Retorno Retorno { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public ConsumoPF ConsumoPF { get; set; }
        public PartEmpresas PartEmpresas { get; set; }

    }
}
