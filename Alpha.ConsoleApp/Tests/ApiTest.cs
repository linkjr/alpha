using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Alpha.ConsoleApp.Tests
{
    public class ApiTest : BaseTest
    {
        public override void Init()
        {
            var client = new HttpClient();
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://www.algraph.com/rest/rest/Values/1");

            //The same as
            //client.DefaultRequestHeaders.Add("Authorization", "Basic admin");
            //requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "admin");
            requestMessage.Headers.Add("Authorization", "Basic admin:pwd");

            var task = client.SendAsync(requestMessage, CancellationToken.None)
                .ContinueWith(m =>
                {
                    var result = m.Result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(result);
                });
            task.Wait();
        }
    }
}
