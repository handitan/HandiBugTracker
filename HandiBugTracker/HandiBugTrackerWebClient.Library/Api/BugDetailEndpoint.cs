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

        public async Task Edit(CompBugViewModel pComBugViewModel)
        {
            //Based on UriComponentBugModel
            var values = new Dictionary<string, string>()
            {
                {"Id",pComBugViewModel.Id.ToString()},
                {"Name",pComBugViewModel.Name},
                {"ReporterId",pComBugViewModel.ReporterId},
                {"AssigneeId",pComBugViewModel.AssigneeId},
                {"QAContactId",pComBugViewModel.QAId},

                {"ProductId",pComBugViewModel.ProductId.ToString()},
                {"ProductVersionId",pComBugViewModel.ProdVerId.ToString()},
                {"BugStatusId",pComBugViewModel.StatusId.ToString()},

                {"BugStatusSubStateId",pComBugViewModel.SubStateId.ToString()},
                {"BugPriorityId",pComBugViewModel.BugPriorityId.ToString()},
                {"BugSeverityId",pComBugViewModel.BugSeverityId.ToString()},

                {"BugTypeId",pComBugViewModel.TypeId.ToString()},
                {"ProductHardwareId",pComBugViewModel.ProductHwId.ToString()},
                {"ProductOSId",pComBugViewModel.ProductOSId.ToString()},
                {"ComponentId",pComBugViewModel.CompId.ToString()}
            };

            var urlEncodedContent = new FormUrlEncodedContent(values);

            using (HttpResponseMessage response = await _apiHelper.ApiClient.PutAsync("/api/ComponentBugs", urlEncodedContent))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
