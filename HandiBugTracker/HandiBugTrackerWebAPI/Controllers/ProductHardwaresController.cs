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
    public class ProductHardwaresController : ApiController
    {
        private readonly IProductHardwareData _productHardwareData;

        public ProductHardwaresController() { }
        public ProductHardwaresController(IProductHardwareData pProductHardwareData)
        {
            this._productHardwareData = pProductHardwareData;
        }
        
        //GET api/ProductHardwares
        public async Task<IEnumerable<ProductHardwareModel>> Get()
        {
            var result = await _productHardwareData.GetProductHardwares();
            return result;
        }
    }
}
