using System;
using Xunit;
using ServersApi;
using System.Collections.Generic;

namespace ServerTests
{
    public class ApiClientTests
    {
        private ApiClient apiClient;

        [Fact]
        public async void WrongCredentialsSent()
        {
            apiClient = new ApiClient("http://playground.tesonet.lt/v1/tokens");

            Dictionary<string, string> requestParams = new Dictionary<string, string> { { "username", "dummyUsername" }, { "password", "dummyPassword" } };

            string token = await apiClient.RetrieveToken(requestParams);

            Assert.Equal(string.Empty, token);
        }

        [Fact]
        public async void ApiUrlIsEmpty()
        {
            apiClient = new ApiClient();

            Dictionary<string, string> requestParams = new Dictionary<string, string> { { "username", "dummyUsername" }, { "password", "dummyPassword" } };

            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => apiClient.RetrieveToken(requestParams));

            Assert.Equal("Api Url is not set", ex.ParamName);
        }
    }
}
