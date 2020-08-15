using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HandiBugTrackerWebClient.Library.Models;

namespace HandiBugTrackerWebClient.Library.Api
{
    public class BugListEndpoint : IBugListEndpoint
    {
        private readonly IAPIHelper _apiHelper;

        public BugListEndpoint(IAPIHelper pAPIHelper)
        {
            this._apiHelper = pAPIHelper;
        }

        public async Task<IEnumerable<CompBugViewModel>> GetAll()
        {
            string allUriFormat = string.Format("api/ComponentBugs?bugid={0}", -1);
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync(allUriFormat))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<IEnumerable<CompBugViewModel>>();
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
