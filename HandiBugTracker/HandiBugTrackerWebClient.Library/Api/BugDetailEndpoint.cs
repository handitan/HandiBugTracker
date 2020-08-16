using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HandiBugTrackerWebClient.Library.Models;

namespace HandiBugTrackerWebClient.Library.Api
{
    public class BugDetailEndpoint : IBugDetailEndpoint
    {
        private readonly IAPIHelper _apiHelper;

        public BugDetailEndpoint(IAPIHelper pAPIHelper)
        {
            this._apiHelper = pAPIHelper;
        }

        public async Task<IList<CompBugViewModel>> GetByBugId(int pId)
        {
            string bugIdUriFormat = string.Format("api/ComponentBugs?bugid={0}", pId);
            IList<CompBugViewModel> result = null;
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync(bugIdUriFormat))
            {
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<IList<CompBugViewModel>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

            string bugCommentsUriFormat = string.Format("api/BugComments?bugid={0}", pId);
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync(bugCommentsUriFormat))
            {
                if (response.IsSuccessStatusCode)
                {
                    var bugComments = await response.Content.ReadAsAsync<IList<BugCommentViewModel>>();
                    if (result.Count > 0)
                    {
                        result[0].BugComments = bugComments;
                    }
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

            return result;
        }
    }
}
