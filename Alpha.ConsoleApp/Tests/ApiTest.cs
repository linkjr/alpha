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
            var url = "http://www.algraph.com/rest/rest/Values/1";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            url = "http://www.algraph.com/rest/rest/Values";
            requestMessage = new HttpRequestMessage(HttpMethod.Post, url);

            //url = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=wx7992ee166b073b06&corpsecret=PeEzkTVMQeBDIm91i7mohjCQH4Q8RvUhVOdUyy4hCT8fJQKHDUxnYtM-l7LQz6wr";
            //requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            url = "http://95599-h.cn/zhuche.jsp";
            requestMessage = new HttpRequestMessage(HttpMethod.Post, url);

            #region Header

            //The same as
            //client.DefaultRequestHeaders.Add("Authorization", "Basic admin");
            //requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "admin");
            requestMessage.Headers.Add("Authorization", "Basic admin:pwd");
            requestMessage.Headers.Add("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1");

            #endregion

            #region Content

            //var args = new Dictionary<string, object>
            //{
            //    {"key", "value"},
            //    {"model", new Dictionary<string,object>
            //        {
            //            {"key","value"}
            //        }
            //    },
            //    {"list", new List<object>
            //        {
            //            new Dictionary<string,object>
            //            {
            //                {"key","value"}
            //            },
            //            new Dictionary<string,object>
            //            {
            //                {"key","value"}
            //            }
            //        }
            //    }
            //};

            //var args = new
            //{
            //    key = "value",
            //    model = new
            //    {
            //        key = "value"
            //    },
            //    list = new List<object>
            //    {
            //        new {key="value"},
            //        new {key="value"}
            //    }
            //};
            //requestMessage.Content = new StringContent(JsonConvert.SerializeObject(args));

            var args = new Dictionary<string, string>
            {
                {"key","value"}
            };
            requestMessage.Content = new FormUrlEncodedContent(args);

            #endregion

            var task = client.SendAsync(requestMessage, CancellationToken.None)
                .ContinueWith(m =>
                {
                    m.Result.Content.Headers.ContentType.CharSet = "GBK";
                    var result = m.Result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(result);
                });
            task.Wait();
        }
    }
}
