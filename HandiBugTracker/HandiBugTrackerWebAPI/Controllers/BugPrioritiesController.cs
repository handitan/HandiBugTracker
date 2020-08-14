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
    public class BugPrioritiesController : ApiController
    {
        private readonly IBugPriorityData _bugPriorityData;

        public BugPrioritiesController() { }
        public BugPrioritiesController(IBugPriorityData pBugPriorityData)
        {
            this._bugPriorityData = pBugPriorityData;
        }

        //GET api/BugPriorities
        public async Task<IEnumerable<BugPriorityModel>> Get()
        {
            var result = await _bugPriorityData.GetBugPriorities();
            return result;
        }
    }
}
