using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace My.NetCore.Helpers
{
    public class HttpClientHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HttpResponseMessage> Post(string url,string body,string contentType= "application/x-www-form-urlencoded" )
        {
            var content = new StringContent(body);
            var client = _httpClientFactory.CreateClient();
            content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            return await client.PostAsync(url, content);
        }

        public async Task<HttpResponseMessage> Post(string url, Dictionary<string, string> param = null, string contentType = "application/x-www-form-urlencoded")
        {
            string body = "";

            if (param != null && param.Count > 0)
            {
                foreach (var item in param)
                {
                    body += $"{item.Key}={item.Value}&";
                }
            }

            var content = new StringContent(body.TrimEnd('&'));
            content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            var client = _httpClientFactory.CreateClient();
            return await client.PostAsync(url, content);
        }
    }
}
