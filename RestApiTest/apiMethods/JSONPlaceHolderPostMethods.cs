using RestApiTest.Configs;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiTest.apiMethods
{
    public class JSONPlaceHolderPostMethods
    {
        public IRestResponse RequestPostMethod(int userid,int id,string title,string body)
        {
            

                JsonPlaceHolderServices _jsonplaceholder = new JsonPlaceHolderServices();
                var client = new RestClient(_jsonplaceholder.url);
                var request = new RestRequest("/posts", Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.RequestFormat = DataFormat.Json;
                request.Timeout = 5000;
                //request.AddBody(new { userid = userid, id = id, title = title, body = body });
                request.AddJsonBody(new { userid = userid, id = id, title = title, body = body });
            IRestResponse response = client.Execute(request);
            return response;
                 
                

            }


        }
    
}
