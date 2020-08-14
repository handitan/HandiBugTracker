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
    public class BugSeveritiesController : ApiController
    {
        private readonly IBugSeverityData _bugSeverityData;

        public BugSeveritiesController() { }
        public BugSeveritiesController(IBugSeverityData pBugSeverityData)
        {
            this._bugSeverityData = pBugSeverityData;
        }

        //GET api/BugSeverities
        public async Task<IEnumerable<BugSeverityModel>> Get()
        {
            var result = await _bugSeverityData.GetBugSeverities();
            return result;
        }
    }
}
