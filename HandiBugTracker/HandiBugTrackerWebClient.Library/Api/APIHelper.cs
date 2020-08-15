using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HandiBugTrackerWebClient.Library.Models;

namespace HandiBugTrackerWebClient.Library.Api
{
    public class APIHelper : IAPIHelper
    {
        private readonly HttpClient _client;
        private TokenViewModel _token;
        public APIHelper()
        {
            string webAPIURI = ConfigurationManager.AppSettings["WebAPIUri"];
            _client = new HttpClient();
            _client.BaseAddress = new Uri(webAPIURI);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpClient ApiClient
        {
            get
            {
                _client.DefaultRequestHeaders.Clear();
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token.Access_Token);
                return _client;
            }
        }

        public async Task<bool> VerifyLogin(string pLoginName, string pPassword)
        {
            var urlEncodedContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("grant_type","password"),
                new KeyValuePair<string,string>("username",pLoginName),
                new KeyValuePair<string,string>("password",pPassword)
            });

            var response = await _client.PostAsync("/token", urlEncodedContent);
            if (response.IsSuccessStatusCode)
            {
                //var tokenJSON = await response.Content.ReadAsStringAsync();
                //var deserializedToken = JsonConvert.DeserializeObject<TokenViewModel>(tokenJSON);
                //_token = deserializedToken;
                _token = await response.Content.ReadAsAsync<TokenViewModel>();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
