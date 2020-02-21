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
        public string ApiUrl { get; set; }

        private HttpClient client;

        public ApiClient(string basePath = null)
        {
            ApiUrl = basePath;
            client = new HttpClient();
        }
         
        public async Task<string> RetrieveToken(Dictionary<string, string> jsonParams)
        {
            var jsonString = await ApiCall(jsonParams);
            AuthorizationResponse authResponse = JsonConvert.DeserializeObject<AuthorizationResponse>(jsonString);

            if (authResponse != null)
            {
                return authResponse.Token;
            }
            return string.Empty;
        }

        public async Task<ICollection<ServersResponse>> RetrieveServers(string token)
        {
            var jsonString = await ApiCall(authParam: token);
            var serversResponse = JsonConvert.DeserializeObject<ICollection<ServersResponse>>(jsonString);

            return serversResponse;
        }

        public async Task<string> ApiCall (Dictionary<string, string> jsonParams = null, string authParam = null)
        {
            if (ApiUrl == null)
            {
                throw new ArgumentNullException("Api Url is not set");
            }
            
            if (authParam != null)
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authParam);
            }

            HttpResponseMessage response;

            if (jsonParams != null)
            {
                string requestJson = JsonConvert.SerializeObject(jsonParams);
                HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

                response = await client.PostAsync(ApiUrl, httpContent);
            }
            else
            { 
                response = await client.GetAsync(ApiUrl);
            }

            var jsonString = string.Empty;

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }
            else
            {
               // throw new Exception($"Error receiving response: {response.Content}");
            }

            return jsonString;
        }
    }
}
