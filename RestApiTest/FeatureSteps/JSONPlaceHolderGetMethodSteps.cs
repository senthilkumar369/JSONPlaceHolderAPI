using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestApiTest.apiMethods;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace RestApiTest.FeatureSteps
{
    [Binding]
    public class JSONPlaceHolderGetMethodSteps
    {


        private readonly ScenarioContext _scenariocontext;

        public JSONPlaceHolderGetMethodSteps(ScenarioContext scenarioContext)
        {
            _scenariocontext = scenarioContext;
        }

        [Given(@"a valid ID as (.*) for Get Method request")]
       
        public void GivenAValidIDAsForGetMethod(int id)
        {
            _scenariocontext["id"] = id;
        }

        [When(@"a request is sent")]
        public void WhenARequestIsSent()
        {
            JSONPlaceHolderGetMethods _JSONPlaceHolderGetMethod = new JSONPlaceHolderGetMethods();
            int id = (int)_scenariocontext["id"];
            _scenariocontext["response"] = _JSONPlaceHolderGetMethod.RequestGetMethod(id);

        }

        [Then(@"it returns response as (.*)")]
        public void ThenItReturnsResponseAs(int resp_code)
        {
            IRestResponse response =(IRestResponse) _scenariocontext["response"];
            int statusCode = (int)response.StatusCode;
            Assert.AreEqual(statusCode, resp_code);
        }



        [Given(@"a valid Get Method request")]
        public void GivenAValidGetMethodRequest()
        {
            JSONPlaceHolderGetMethods _JSONPlaceHolderGetMethod = new JSONPlaceHolderGetMethods();
            _scenariocontext["response"]=_JSONPlaceHolderGetMethod.RequestGetMethodforAllResources();
        }

        [When(@"it is success (.*)")]
        public void WhenItIsSuccess(int resp_code)
        {
            IRestResponse response = (IRestResponse)_scenariocontext["response"];
            int statusCode = (int)response.StatusCode;
            Assert.AreEqual(statusCode, resp_code);

        }

        [Then(@"it returns all the resources")]
        public void ThenItReturnsAllTheResources()
        {
            int expectedcount = 100;
            JSONPlaceHolderGetMethods _JSONPlaceHolderGetMethod = new JSONPlaceHolderGetMethods();
            IRestResponse response = (IRestResponse)_scenariocontext["response"];
            JArray output= _JSONPlaceHolderGetMethod.ResponseGetMethod(response);
            int actualcount = output.Count;
            Assert.AreEqual(expectedcount, actualcount);
        }

        /*
                    Test case 3 - Send Get Method request with invalid id
        */
        [Given(@"a invalid ID as (.*) for Get Method request")]
        public void GivenAInvalidIDAsForGetMethodRequest(string invalid_id)
        {
            _scenariocontext["invald_id"] = invalid_id;
        }

        




        [When(@"a request is sent with Invalid id")]
        public void WhenARequestIsSentWithInvalidId()
        {
            string exp_val= "idontexist";
            JSONPlaceHolderGetMethods _JSONPlaceHolderGetMethod = new JSONPlaceHolderGetMethods();
            string invalid_id = (string)_scenariocontext["invald_id"];
            if (invalid_id == exp_val)
            {
                _scenariocontext["response"] = _JSONPlaceHolderGetMethod.RequestGetMethodInvalidId();
            }
        }


    }
}
