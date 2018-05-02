using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Serviço.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Serviço
{
    public class ViaCepServico
    {
        private static string enderecoUrl = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            try
            {
                string novoEnderecoUrl = string.Format(enderecoUrl, cep);

                WebClient wc = new WebClient();
                var conteudo = wc.DownloadString(novoEnderecoUrl);

                Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

                if (end.Cep == null)
                    return null;

                return end;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
