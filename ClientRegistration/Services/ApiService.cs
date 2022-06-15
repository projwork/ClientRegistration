using ClientRegistration.Contract.DataContract;
using ClientRegistration.Contract.ServiceContract;
using ClientRegistration.Repository.Interface;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ClientRegistration.Services
{
    public class ApiService : IApiService
    {
        private readonly AuthSetting _cssSettings;
        private string _accessToken;


        public ApiService(IOptions<AuthSetting> cssSettings)
        {
            _cssSettings = cssSettings.Value;
        }

        public async Task<ResponseModel> MakeCssRequest()
        {
            var token = await Initialize();
            var request = new HttpRequestMessage(HttpMethod.Post, $"{ _cssSettings.BaseUrl}" + "/api/Person/PersonFind");
            request.Content = new StringContent("{\"personalN\":\"01401401401\"}",
                                    Encoding.UTF8,
                                    "application/json");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    // deserializing the response
                    var apiContent = JsonConvert.DeserializeObject<UserResponseModel>(content);
                    return new ResponseModel
                    {
                        HasValue = true,
                        Result = apiContent
                    };
                }
            }
            return null;
        }

        #region private
        private async Task<string> Initialize()
        {
            var uri = _cssSettings.Uri;
            string grant_type = _cssSettings.GrantType;
            string client_id = _cssSettings.ClientId;
            string client_secret = _cssSettings.ClientSecret;
            string user_name = _cssSettings.UserName;
            string password = _cssSettings.Password;

            var form = new Dictionary<string, string>
            {
                {"grant_type", grant_type },
                {"client_id", client_id },
                {"client_secret", client_secret },
                {"username", user_name },
                {"password", password},
            };

            var client = new HttpClient();
            HttpResponseMessage tokenResponse = await client.PostAsync(uri, new FormUrlEncodedContent(form));
            var jsonContent = await tokenResponse.Content.ReadAsStringAsync();
            if (jsonContent != null)
            {
                Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);
                _accessToken = tok.AccessToken;
            }
            return _accessToken;
        }
        internal class Token
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }

            [JsonProperty("token_type")]
            public string TokenType { get; set; }

            [JsonProperty("expires_in")]
            public int ExpiresIn { get; set; }

            [JsonProperty("refresh_token")]
            public string RefreshToken { get; set; }
        }
        #endregion
    }
}
