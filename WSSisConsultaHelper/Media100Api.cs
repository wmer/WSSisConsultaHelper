using System;
using WSSisConsultaHelper.Helpers;
using WSSisConsultaHelper.Models;

namespace WSSisConsultaHelper {
    public class Media100Api {
        private string _cliente;
        private string _chaveKey;

        public Media100Api(string cliente, string chaveKey) {
            _cliente = cliente;
            _chaveKey = chaveKey;
        }

        public Pessoa BuscarPessoa(string docTipo, string doc) {
            var stringSearch = $"/ApiSisConsulta/Bases/LocalizacaoCompleta?documento={doc}&tipoDoc={docTipo}&cliente={_cliente}&chavekey={_chaveKey}"; 
            var consumer = new ApiConsumerHelper("https://api.sisconsulta.com");
            var result = consumer.Get<Pessoa>(stringSearch);

            if (result.result.NewDataSet == null || result.result.NewDataSet.ConsumoPF == null) {
                consumer = new ApiConsumerHelper("https://api2.sisconsulta.com");
                result = consumer.Get<Pessoa>(stringSearch);
            }

            return result.result;
        }

    }
}
