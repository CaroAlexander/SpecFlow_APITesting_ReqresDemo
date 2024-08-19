using Newtonsoft.Json;
using NUnit.Framework;
using SpecFlow_APITesting_ReqresDemo.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
        HttpRequestMessage request;
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

        [Given(@"the user sends a post request to reqbin with url as ""([^""]*)""")]
        public async Task GivenTheUserSendsAPostRequestToReqbinWithUrlAs(string uri)
        {
            request = new HttpRequestMessage(HttpMethod.Post, uri); // Create the object of the http request message
            var stringdata = JsonConvert.SerializeObject(new Datasend() { id = 1564, quantity = 1, price = 15 }); //string value
            var stringcontent = new StringContent(stringdata, Encoding.UTF8, "application/json"); // Http value (payload)

            request.Content = stringcontent; // attach the payload to the request message


            //adding the headers
            //( client.DefaultRequestHeaders.Add("in therms of KeyValuePair") - is one option for pass the headers to the request message )
            List<NameValueHeaderValue> Listheaders = new List<NameValueHeaderValue>();
            Listheaders.Add(new NameValueHeaderValue("Encoding", "utf-8"));
            Listheaders.Add(new NameValueHeaderValue("user-agent", "x-machine"));

            foreach (var header in Listheaders)
            {
                request.Headers.Add(header.Name, header.Value);
            }

            response = await httpClient.SendAsync(request);
            responsebody = await response.Content.ReadAsStringAsync();
            outputHelper.WriteLine("post response body is: " + responsebody);
            foreach (var item in request.Headers)
            {
                Console.WriteLine("Key is  " + item.Key + " Value is " + item.Value.FirstOrDefault());
            }

            foreach (var item in response.Headers)
            {
                Console.WriteLine("Key is  " + item.Key + " Value is " + item.Value.FirstOrDefault());
            }


        }

        [Then(@"users should get a success response")]
        public void ThenUsersShouldGetASuccessResponse()
        {
            Assert.True(response.IsSuccessStatusCode);
        }

    }
}
