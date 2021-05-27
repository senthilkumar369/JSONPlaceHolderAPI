using RestApiTest.Configs;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiTest.apiMethods
{
    class JSONPlaceHolderDeleteMethods
    {

        public IRestResponse RequestDeleteMethodforId(int id)
        {
            /*
                    This is to retrive all the resources / data 

            */

            JsonPlaceHolderServices _jsonplaceholder = new JsonPlaceHolderServices();
            var client = new RestClient(_jsonplaceholder.url);

            var request = new RestRequest("/posts", Method.DELETE);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("id", id);
            request.Timeout = 5000;
            IRestResponse response = client.Execute(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }
            return response;


        }
    }
}
