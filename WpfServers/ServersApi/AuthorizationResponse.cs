using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServersApi
{
    public class AuthorizationResponse
    {
        [JsonProperty(PropertyName="token")]
        public string Token { get; set; }
    }
}
