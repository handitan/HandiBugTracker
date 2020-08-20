using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HandiBugTrackerWebClient.Library.Models;

namespace HandiBugTrackerWebClient.Library.Api
{
    public class UsersEndpoint : IUsersEndpoint
    {
        private readonly IAPIHelper _apiHelper;

        public UsersEndpoint(IAPIHelper pAPIHelper)
        {
            this._apiHelper = pAPIHelper;
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/Users"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<IEnumerable<UserViewModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
