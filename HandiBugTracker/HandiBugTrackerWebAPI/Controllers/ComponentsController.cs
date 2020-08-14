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
    public class ComponentsController : ApiController
    {
        private readonly IComponentData _compData;

        public ComponentsController() { }
        public ComponentsController(IComponentData pCompData)
        {
            this._compData = pCompData;
        }
        
        //GET api/Components/
        public async Task<IEnumerable<ComponentModel>> Get(UriComponentModel pUriCompModel)
        {
            var result = await _compData.GetComponentByProductId(pUriCompModel.ProductId);
            return result;
        }
    }
}
