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
    public class BugTypesController : ApiController
    {
        private readonly IBugTypeData _bugTypeData;

        public BugTypesController() { }
        public BugTypesController(IBugTypeData pBugTypeData)
        {
            this._bugTypeData = pBugTypeData;
        }

        //GET api/BugTypes
        public async Task<IEnumerable<BugTypeModel>> Get()
        {
            var result = await _bugTypeData.GetBugTypes();
            return result;
        }
    }
}
