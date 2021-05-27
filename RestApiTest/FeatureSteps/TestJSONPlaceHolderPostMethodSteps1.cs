using NUnit.Framework;
using RestApiTest.apiMethods;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace RestApiTest.FeatureSteps
{
    [Binding]
    public class TestJSONPlaceHolderPostMethodSteps
    {

        private readonly ScenarioContext _scenariocontext;
        public TestJSONPlaceHolderPostMethodSteps(ScenarioContext scenarioContext)
        {
            _scenariocontext = scenarioContext;
        }


        [Given(@"a post request with user id as (.*) id as (.*) title as ""(.*)"" and body as ""(.*)""")]
        public void GivenAPostRequestWithUserIdAsIdAsTitleAsAndBodyAs(int p0, int p1, string p2, string p3)
        {
            _scenariocontext["userid"] = p0;
            _scenariocontext["id"] = p1;
            _scenariocontext["title"] = p2;
            _scenariocontext["body"] = p3;
        }
        
        [When(@"post request sent")]
        public void WhenPostRequestSent()
        {
            JSONPlaceHolderPostMethods jsonplaceholderpost = new JSONPlaceHolderPostMethods();
            int userid = (int)_scenariocontext["userid"];
            int id = (int)_scenariocontext["id"];
            string title = (string)_scenariocontext["title"];
            string body = (string)_scenariocontext["body"];
            _scenariocontext["response"] = jsonplaceholderpost.RequestPostMethod(userid, id, title, body);
        }
        
        [Then(@"it return the status code as (.*)")]
        public void ThenItReturnTheStatusCodeAs(int p0)
        {
            IRestResponse response = (IRestResponse)_scenariocontext["response"];
            int actualstatuscode = (int)response.StatusCode;
            Assert.AreEqual(actualstatuscode, p0);
        }
    }
}
