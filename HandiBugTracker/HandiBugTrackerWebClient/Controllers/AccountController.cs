using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HandiBugTrackerWebClient.Library.Api;
using HandiBugTrackerWebClient.Models;

namespace HandiBugTrackerWebClient.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAPIHelper _apiHelper;
        private readonly IUsersEndpoint _userEndPoint;
        private readonly PeopleViewModel _peopleViewModel;
        public AccountController() { }
        public AccountController(IAPIHelper pIAPIHelper,
            IUsersEndpoint pUserEndPoint,
            PeopleViewModel pPeopleViewModel)
        {
            _apiHelper = pIAPIHelper;
            _userEndPoint = pUserEndPoint;
            _peopleViewModel = pPeopleViewModel;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(AccountViewModel pAcctViewModel)
        {
            if (ModelState.IsValid)
            {
                var success = await _apiHelper.VerifyLogin(pAcctViewModel.LoginName, pAcctViewModel.Password);
                if (success)
                {
                    _peopleViewModel.LoggedInEmailAddress = pAcctViewModel.LoginName;

                    //TODO: need to revisit later to get user Id more efficiently
                    var userList = await _userEndPoint.GetAll();
                    foreach (var user in userList)
                    {
                        if (user.EmailAddress.Equals(_peopleViewModel.LoggedInEmailAddress))
                        {
                            _peopleViewModel.LoggedInUserId = user.Id;
                            _peopleViewModel.LoggedInFirstName = user.FirstName;
                            _peopleViewModel.LoggedInLastName = user.LastName;
                            break;
                        }
                    }

                    return RedirectToRoute("Main");
                }
            }
            return RedirectToAction("Index");
        }
    }
}