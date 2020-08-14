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
    public class UsersController : ApiController
    {
        private readonly IUserData _userData;

        public UsersController() { }
        public UsersController(IUserData pUserData)
        {
            this._userData = pUserData;
        }
        
        //GET api/Users
        public async Task<IEnumerable<UserModel>> Get()
        {
            var result = await _userData.GetUsers();
            return result;
        }
    }
}
