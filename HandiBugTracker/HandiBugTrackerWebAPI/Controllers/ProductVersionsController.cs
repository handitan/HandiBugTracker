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
    public class ProductVersionsController : ApiController
    {
        private readonly IProductVersionData _prodVerData;

        public ProductVersionsController() { }
        public ProductVersionsController(IProductVersionData pProdVerData)
        {
            this._prodVerData = pProdVerData;
        }
        
        //GET api/Products/1
        //Has to use id for url param to be mapped
        public async Task<IEnumerable<ProductVersionModel>> Get(int id)
        {
            var result = await _prodVerData.GetProductVersionsByProduct(id);
            return result;
        }
    }
}
