using NUnit.Framework;
using RestApiTest.apiMethods;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace RestApiTest.FeatureSteps
{
    [Binding]
    public class TestJSONPlaceHolderDeleteSteps
    {
        private readonly ScenarioContext _scenariocontext;
        public TestJSONPlaceHolderDeleteSteps(ScenarioContext scenarioContext)
        {
            _scenariocontext = scenarioContext;
        }

        [Given(@"a valid ID as (.*) for Delete Method request")]
        public void GivenAValidIDAsForDeleteMethodRequest(int id)
        {
            _scenariocontext["id"] = id;
        }
        
        [When(@"a request is sent for delete")]
        public void WhenARequestIsSentForDelete()
        {
            JSONPlaceHolderDeleteMethods jsonplaceholderdeleteMethods = new JSONPlaceHolderDeleteMethods();
            int id = (int)_scenariocontext["id"];
            _scenariocontext["response"] = jsonplaceholderdeleteMethods.RequestDeleteMethodforId(id);

        }

        [Then(@"returns success with response code (.*)")]
        public void ThenReturnsSuccessWithResponseCode(int responsecode)
        {
            IRestResponse response = (IRestResponse)_scenariocontext["response"];
            int statusCode = (int)response.StatusCode;
            Assert.AreEqual(statusCode, responsecode);
        }


    }
}
