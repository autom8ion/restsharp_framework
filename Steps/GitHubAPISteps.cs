using ApprovalTests;
using ApprovalTests.Reporters;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using RestSharp;
using RESTSharpFW.Data;
using RESTSharpFW.Helpers;
using System;
using System.Dynamic;
using System.Net;
using TechTalk.SpecFlow;

namespace RESTSharpFW.Steps
{
    [UseReporter(typeof(DiffReporter))]
    [Binding]
    public sealed class StepDefinition
    {

        private readonly ScenarioContext context;

        public StepDefinition(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }


        [Given(@"the user has a Github account")]
        public void GivenTheUserHasAGithubAccount()
        {

        }

        [When(@"the user executes a GET User call")]
        public void WhenTheUserExecutesAGETUserCall()
        {
            var response = RESTHelpers.Request(Method.GET,
                context.Get<string>("BASE_URL"),
                context.Get<string>("UserResource"),
                context.Get<string>("UserName"),
                context.Get<string>("Token"),
                null, null, null);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            context.Add("GitHub", response);
        }

        [Then(@"the user receives a response with the correct github project details")]
        public void ThenTheUserReceivesAResponseWithTheCorrectGithubProjectDetails()
        {
            context.Get<IRestResponse>("GitHub").IsSuccessful.Should().BeTrue();

            Console.WriteLine(context.Get<IRestResponse>("GitHub").Content);

        }

        [When(@"the user Creates a new GitHub Repository")]
        public void WhenTheUserCreatesANewGitHubRepository()
        {
            var repositoryJSONObject = RepositoryBuilder.BuildRepository();

            var response = RESTHelpers.Request(Method.POST,
                context.Get<string>("BASE_URL"),
                context.Get<string>("RepositoryResource"),
                context.Get<string>("UserName"),
                context.Get<string>("Token"),
                null, null, repositoryJSONObject);

            context.Add("GitHubRepository", response);
            context.Add("RepositoryObject", repositoryJSONObject);

        }

        [Then(@"the github repository is created in the system")]
        public void ThenTheGithubRepositoryIsCreatedInTheSystem()
        {
            context.Get<IRestResponse>("GitHubRepository").StatusCode.Should().Be(HttpStatusCode.Created);

            var response = context.Get<IRestResponse>("GitHubRepository").Content;

            //Remove Dynamic Elements
            JObject jo = JObject.Parse(response);
            jo.Property("name").Remove();
            jo.Property("updated_at").Remove();

            var json = JsonConvert.SerializeObject(jo);

            Approvals.VerifyJson(json);

        }


        [Then(@"the github repository is created successfully")]
        public void ThenTheGithubRepositoryIsCreatedSuccessfully()
        {

            context.Get<IRestResponse>("GitHubRepository").StatusCode.Should().Be(HttpStatusCode.Created);

            var response = context.Get<IRestResponse>("GitHubRepository").Content;

            var expConverter = new ExpandoObjectConverter();
            dynamic dynObj = JsonConvert.DeserializeObject<ExpandoObject>(response, expConverter);

            string login = dynObj.owner.login;
            login.Should().Be("KTJ-Demo");

        }


    }
}
