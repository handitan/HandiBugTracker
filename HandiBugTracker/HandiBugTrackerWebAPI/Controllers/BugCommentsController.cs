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

        //GET api/BugComments
        public async Task<IEnumerable<BugCommentModel>> Get(UriCommentBugModel pUriBugModel)
        {
            var result = await _bugCommentData.GetBugCommentByBugId(pUriBugModel.BugId);
            return result;
        }
    }
}
