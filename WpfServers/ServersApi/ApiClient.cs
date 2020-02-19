using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace ServersApi
{
    public class ApiClient
    {
        private string basePath;

        private HttpClient client;

        public ApiClient(string basePath)
        {
            this.basePath = basePath;
            client = new HttpClient();
        }

        public async Task<HttpStatusCode> ApiCall (Dictionary<string, string> parameters)
        {
            client.BaseAddress = new Uri(basePath);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string requestJson = JsonConvert.SerializeObject(parameters);
            HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(basePath, httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.ToString());
            }
            return response.StatusCode;
        }
    }
}
