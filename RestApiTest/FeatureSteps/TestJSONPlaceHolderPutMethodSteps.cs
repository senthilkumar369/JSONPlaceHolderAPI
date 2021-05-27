using RestApiTest.apiMethods;
using System;
using TechTalk.SpecFlow;

namespace RestApiTest.FeatureSteps
{
    [Binding]
    public class TestJSONPlaceHolderPutMethodSteps
    {
        private readonly ScenarioContext _scenariocontext;
        public TestJSONPlaceHolderPutMethodSteps(ScenarioContext scenarioContext)
        {
            _scenariocontext = scenarioContext;
        }


        [When(@"put request sent")]
        public void WhenPutRequestSent()
        {
            JSONPlaceHolderPutMethods jsonplaceholderput = new JSONPlaceHolderPutMethods();
            int userid = (int)_scenariocontext["userid"];
            int id = (int)_scenariocontext["id"];
            string title = (string)_scenariocontext["title"];
            string body = (string)_scenariocontext["body"];
            _scenariocontext["response"] = jsonplaceholderput.RequestPutMethod(userid, id, title, body);
        }

    }
}
