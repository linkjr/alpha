using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Alpha.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            //var requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:32186/api/Values/1");

            //The same as
            //client.DefaultRequestHeaders.Add("Authorization", "Basic admin");
            //requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "admin");
            //requestMessage.Headers.Add("Authorization", "Basic admin:pwd");

            //var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://sc.122.gov.cn/m/publicquery/vio");
            //var dicts = new Dictionary<string, string>();
            //dicts.Add("hpzl", "02");//号牌种类
            //dicts.Add("hphm", "川A201AP");//号牌号码
            //dicts.Add("fdjh", "842531");//发动机号后6位
            //dicts.Add("captcha", "pm2v");//验证码
            //dicts.Add("qm", "wf");
            //requestMessage.Content = new FormUrlEncodedContent(dicts);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://pan.baidu.com/share/verify?shareid=4180024020&uk=178447432&t=1488379291740&bdstoken=7611ff4279c2c4ef37069456f30d3d82&channel=chunlei&clienttype=0&web=1&app_id=250528&logid=MTQ4ODM3OTI5MTc1NDAuMDY3ODExNjQ4MzYxMzg0ODc=");
            //requestMessage.Content = new FormUrlEncodedContent(dicts);

            var task = client.SendAsync(requestMessage, CancellationToken.None)
                .ContinueWith(m =>
                {
                    var result = m.Result.Content.ReadAsStringAsync().Result;
                    var s = JsonConvert.DeserializeObject<requestSer>(result);
                    Thread.Sleep(3000);
                });
            task.Wait();
            Console.ReadLine();
        }
    }

    public class requestSer
    {
        public int errno { get; set; }
    }
}
