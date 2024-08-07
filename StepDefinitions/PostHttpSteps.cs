using Newtonsoft.Json;
using NUnit.Framework;
using SpecFlow_APITesting_ReqresDemo.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlow_APITesting_ReqresDemo.StepDefinitions
{
    [Binding]
    public class PostHttpSteps
    {

        HttpClient httpClient;
        HttpResponseMessage response;
        string responsebody;
        private readonly ISpecFlowOutputHelper outputHelper;

        public PostHttpSteps(ISpecFlowOutputHelper outputHelper)
        {
            httpClient = new HttpClient();
            this.outputHelper = outputHelper;
        }

        [Given(@"the user sends a post request with url as ""([^""]*)""")]
        public async Task GivenTheUserSendsAPostRequestWithUrlAs(string uri)
        {
            PostData postData = new PostData()
            {
                name = "morpheus",
                job = "leader"
            };

            string data = JsonConvert.SerializeObject(postData);
            var contentdata = new StringContent(data);

            response = await httpClient.PostAsync(uri, contentdata);

            responsebody = await response.Content.ReadAsStringAsync();
            outputHelper.WriteLine("post response is" + responsebody);

        }

        [Then(@"user should get a success response")]
        public void ThenUserShouldGetASuccessResponse()
        {
            Assert.True(response.IsSuccessStatusCode);
        }

    }
}
