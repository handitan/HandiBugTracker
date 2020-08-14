using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HandiBugTrackerDataManager.DataAccess;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerWebAPI.Controllers
{
    [Authorize]
    public class BugStatusesController : ApiController
    {
        private readonly IBugStatusData _bugStatusData;

        public BugStatusesController() { }
        public BugStatusesController(IBugStatusData pBugStatusData)
        {
            this._bugStatusData = pBugStatusData;
        }

        //GET api/BugStatuses
        public async Task<IEnumerable<BugStatusModel>> Get()
        {
            var result = await _bugStatusData.GetBugStatuses();
            return result;
        }
    }
}
