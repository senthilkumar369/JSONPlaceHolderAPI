using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharp.Deserializers;
using RestApiTest.Configs;
using Newtonsoft.Json.Linq;

namespace RestApiTest.apiMethods
{
    class JSONPlaceHolderGetMethods
    {

        public IRestResponse RequestGetMethodforAllResources()
        {
        /*
                This is to retrive all the resources / data 

        */

            JsonPlaceHolderServices _jsonplaceholder = new JsonPlaceHolderServices();
            var client = new RestClient(_jsonplaceholder.url);

            var request = new RestRequest("/posts", Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.Timeout = 5000;
            IRestResponse response = client.Execute(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }
            return response;

        }

     
    public IRestResponse RequestGetMethod(int id)
        {
            /*
              validates with ID ex 1,2,3 .. 100  

           */

            JsonPlaceHolderServices _jsonplaceholder = new JsonPlaceHolderServices();
                var client = new RestClient(_jsonplaceholder.url);

                var request = new RestRequest("/posts", Method.GET);
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

        public IRestResponse RequestGetMethodInvalidId()
        {
            /*
              Test id that doesnt exist 

           */

            JsonPlaceHolderServices _jsonplaceholder = new JsonPlaceHolderServices();
            var client = new RestClient(_jsonplaceholder.url);
            var request = new RestRequest("/posts/idontexist", Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.Timeout = 5000;
            IRestResponse response = client.Execute(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }
            return response;

        }



        public JArray ResponseGetMethod(IRestResponse response)
        {
            var result = response.Content;
            JArray jsonOutput = JArray.Parse(result);
            return jsonOutput;

        }

        public int GetHttpResponseStatusCode(int id)
        {
            var response = RequestGetMethod(id);
            int statusCode = (int)response.StatusCode;
            return statusCode;
        }
      
        public void GetAllResponseData()
        {
            IRestResponse response = RequestGetMethodforAllResources();
            var jj = ResponseGetMethod(response);
            Console.WriteLine(jj.ToString());
        }
    }
}
