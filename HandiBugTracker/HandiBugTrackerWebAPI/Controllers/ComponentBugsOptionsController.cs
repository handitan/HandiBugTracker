using System.Threading.Tasks;
using System.Web.Http;
using HandiBugTrackerDataManager.DataAccess;
using HandiBugTrackerDataManager.Models;

namespace HandiBugTrackerWebAPI.Controllers
{
    [Authorize]
    public class ComponentBugsOptionsController : ApiController
    {
        private readonly IComponentBugOptionsData _compBugOptionsData;

        public ComponentBugsOptionsController() { }
        public ComponentBugsOptionsController(IComponentBugOptionsData pCompBugOptionsData)
        {
            this._compBugOptionsData = pCompBugOptionsData;
        }

        //GET api/ComponentBugsOptions
        public async Task<ComponentBugOptionsModel> Get()
        {
            var result = await _compBugOptionsData.GetComponentBugOptions();
            return result;
        }
    }
}
