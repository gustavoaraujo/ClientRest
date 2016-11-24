using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WsReceita.Models;

namespace ClientRest.WS
{
    public class Operacoes
    {
        private RestClient restClient;
        public Operacoes()
        {
            restClient = new RestClient("http://wsreceita.gear.host");
        }

        public string CancelarReceitaMedica(NumeroReceita numeroReceita)
        {
            var request = new RestRequest("CancelarReceitaMedica", Method.POST);
            request.AddParameter("numeroReceita", numeroReceita);

            IRestResponse response = restClient.Execute(request);
            var content = response.Content;
            
            return content;
        }

        public string UtilizarReceitaMedica(NumeroReceita numeroReceita)
        {
            var request = new RestRequest("UtilizarReceitaMedica", Method.POST);
            request.AddParameter("numeroReceita", numeroReceita);

            IRestResponse response = restClient.Execute(request);
            var content = response.Content;

            return content;
        }

        public Receita ObterReceitaMedica(NumeroReceita numeroReceita)
        {
            var request = new RestRequest("ObterReceitaMedica", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(numeroReceita);
            
            var response = restClient.Execute(request);
            
            JsonDeserializer deserial = new JsonDeserializer();

            if (response.Content != "null")
            {
                var receita = deserial.Deserialize<Receita>(response);

                return receita;
            }

            return null;
        }

        public ResultCadastroReceita CadastrarReceitaMedica(Receita receita)
        {
            var request = new RestRequest("CadastrarReceitaMedica", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(receita);

            var response = restClient.Execute(request);

            JsonDeserializer deserial = new JsonDeserializer();

            if (response.Content != "null")
            {
                var rcr = deserial.Deserialize<ResultCadastroReceita>(response);

                return rcr;
            }

            return null;
        }

    }
}