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
    public class ProductsController : ApiController
    {
        private readonly IProductData _productData;

        public ProductsController() { }
        public ProductsController(IProductData pProductData)
        {
            this._productData = pProductData;
        }
        
        //GET api/Products
        public async Task<IEnumerable<ProductModel>> Get()
        {
            var result = await _productData.GetProducts();
            return result;
        }
    }
}
