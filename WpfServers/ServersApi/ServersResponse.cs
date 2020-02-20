using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
