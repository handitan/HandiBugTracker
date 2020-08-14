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
    public class ProductOsesController : ApiController
    {
        private readonly IProductOSData _productOSData;

        public ProductOsesController() { }
        public ProductOsesController(IProductOSData pProductOSData)
        {
            this._productOSData = pProductOSData;
        }

        //GET api/ProductOses
        public async Task<IEnumerable<ProductOSModel>> Get()
        {
            var result = await _productOSData.GetProductOSes();
            return result;
        }
    }
}
