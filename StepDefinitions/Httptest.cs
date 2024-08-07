using Newtonsoft.Json;
using NUnit.Framework;
using SpecFlow_APITesting_ReqresDemo.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace RyderDemo_SpecFlow.StepDefinitions
{
    [Binding]
    internal class Httptest
    {
        HttpClient httpClient;
        HttpResponseMessage response;
        string responsebody;
        private readonly ISpecFlowOutputHelper specFlowOutputHelper;
        public Httptest(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            httpClient = new HttpClient();
            this.specFlowOutputHelper = specFlowOutputHelper;
        }

        [Given(@"the user sends a get request with url as ""([^""]*)""")]
        public async Task GivenTheUserSendsAGetRequestWithUrlAs(string uri)
        {
            response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            responsebody = await response.Content.ReadAsStringAsync();
            specFlowOutputHelper.WriteLine(responsebody);

            var desdata = JsonConvert.DeserializeObject<Datamodel>(responsebody);

            specFlowOutputHelper.WriteLine("after deserialization value is: " + desdata.page.ToString());
            foreach (var item in desdata.data)
            {

                specFlowOutputHelper.WriteLine(item.id.ToString());

            }

        }

        [Then(@"request should be a success with (.*)s codes")]
        public void ThenRequestShouldBeASuccessWithS(int p0)
        {
            //throw new PendingStepException();
            Assert.True(response.IsSuccessStatusCode);
        }


    }
}