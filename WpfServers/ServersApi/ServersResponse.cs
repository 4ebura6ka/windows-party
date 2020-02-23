using Newtonsoft.Json;

namespace ServersApi
{
    public class ServersResponse
    {
        [JsonProperty(PropertyName="name")]
        public string ServerName { get; set; }

        [JsonProperty(PropertyName="distance")]
        public int Distance { get; set; }
    }
}
