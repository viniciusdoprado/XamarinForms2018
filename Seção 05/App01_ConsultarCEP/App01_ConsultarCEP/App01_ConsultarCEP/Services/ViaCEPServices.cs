using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Services.Model;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Services
{
    public class ViaCEPServices
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (endereco.cep == null)
                return null;

            return endereco;
        }
    }
}