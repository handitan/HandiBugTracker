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
    public class ComponentBugsController : ApiController
    {
        private readonly IComponentBugData _compBugData;

        public ComponentBugsController() { }
        public ComponentBugsController(IComponentBugData pCompBugData)
        {
            this._compBugData = pCompBugData;
        }
        
        //GET api/Components
        public async Task<IEnumerable<ComponentBugModel>> Get(UriBugFilterModel pBugFilterModel)
        {
            var result = await _compBugData.GetComponentBugFilterBy(pBugFilterModel.BugId, pBugFilterModel.AssigneeId);
            return result;
        }
    }
}
