using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HandiBugTrackerWebClient.Library.Models;

namespace HandiBugTrackerWebClient.Library.Api
{
    public class CompBugAllOptionsEndPoint : ICompBugAllOptionsEndPoint
    {
        private readonly IAPIHelper _apiHelper;

        public CompBugAllOptionsEndPoint(IAPIHelper pAPIHelper)
        {
            this._apiHelper = pAPIHelper;
        }

        public async Task<CompBugOptionsViewModel> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/ComponentBugsOptions"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<CompBugOptionsViewModel>();
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
