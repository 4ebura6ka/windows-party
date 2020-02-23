using Newtonsoft.Json;

namespace ServersApi
{
    public class AuthorizationResponse
    {
        [JsonProperty(PropertyName="token")]
        public string Token { get; set; }
    }
}
