using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HandiBugTrackerDataManager.DataAccess;
using HandiBugTrackerDataManager.Models;
using HandiBugTrackerWebAPI.Models;

namespace HandiBugTrackerWebAPI.Controllers
{
    [Authorize]
    public class BugCommentsController : ApiController
    {
        private readonly IBugCommentData _bugCommentData;

        public BugCommentsController() { }
        public BugCommentsController(IBugCommentData pBugCommentData)
        {
            this._bugCommentData = pBugCommentData;
        }

        //GET api/BugComments/1003
        //public async Task<IEnumerable<BugCommentModel>> Get(UriCommentBugModel pUriBugModel)
        public async Task<IEnumerable<BugCommentModel>> Get(int bugid)
        {
            var result = await _bugCommentData.GetBugCommentByBugId(bugid);
            return result;
        }

        //POST api/BugComments
        public async Task Post(UriCommentBugModel pUriBugModel)
        {
            await _bugCommentData.CreateBugCommentBy(pUriBugModel.BugId, pUriBugModel.Description, pUriBugModel.ReporterId);
        }

        //DELETE api/BugComments/1003
        public async Task Delete(int bugid)
        {
            await _bugCommentData.DeleteBugCommentBy(bugid);
        }
    }
}
