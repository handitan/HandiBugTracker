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
    public class BugStatusSubStatesController : ApiController
    {
        private readonly IBugStatusSubStateData _bugStatusSubStateData;

        public BugStatusSubStatesController() { }
        public BugStatusSubStatesController(IBugStatusSubStateData pBugStatusSubStateData)
        {
            this._bugStatusSubStateData = pBugStatusSubStateData;
        }

        //GET api/BugTypes
        public async Task<IEnumerable<BugStatusSubStateModel>> Get()
        {
            var result = await _bugStatusSubStateData.GetBugStatusSubStates();
            return result;
        }
    }
}
