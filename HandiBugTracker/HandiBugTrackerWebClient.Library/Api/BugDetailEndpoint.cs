using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HandiBugTrackerWebClient.Library.Models;
using Newtonsoft.Json;

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

            //====================

            if (!string.IsNullOrWhiteSpace(pComBugViewModel.ClientNewComment) &&
                    !string.IsNullOrEmpty(pComBugViewModel.ClientNewComment))
            {
                var commentValues = new Dictionary<string, string>()
                {
                    {"BugId", pComBugViewModel.Id.ToString()},
                    {"Description", pComBugViewModel.ClientNewComment},
                    {"ReporterId", pComBugViewModel.ReporterId}
                };
                var urlEncodedConment = new FormUrlEncodedContent(commentValues);
                string bugCommentsUriFormat = string.Format("api/BugComments?bugid={0}", pComBugViewModel.Id);
                using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsync(bugCommentsUriFormat, urlEncodedConment))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
        }

        public async Task Create(CompBugViewModel pComBugViewModel)
        {
            //Based on UriComponentBugModel
            var values = new Dictionary<string, string>()
            {
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

            IList<int> newIdList;
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsync("/api/ComponentBugs", urlEncodedContent))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);
                }
                else
                {
                    var valuesJSON = await response.Content.ReadAsStringAsync();
                    newIdList = JsonConvert.DeserializeObject<IList<int>>(valuesJSON);
                    
                }
            }

            //====================

            if (newIdList != null && newIdList.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(pComBugViewModel.ClientNewComment) &&
                        !string.IsNullOrEmpty(pComBugViewModel.ClientNewComment))
                {
                    var commentValues = new Dictionary<string, string>()
                    {
                        {"BugId", newIdList[0].ToString()},
                        {"Description", pComBugViewModel.ClientNewComment},
                        {"ReporterId", pComBugViewModel.ReporterId}
                    };
                    var urlEncodedConment = new FormUrlEncodedContent(commentValues);
                    using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsync("api/BugComments", urlEncodedConment))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            throw new Exception(response.ReasonPhrase);
                        }
                    }
                }
            }
        }

    }
}
