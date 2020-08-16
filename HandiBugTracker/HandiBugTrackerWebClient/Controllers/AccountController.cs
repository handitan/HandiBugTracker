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
        public AccountController() { }
        public AccountController(IAPIHelper pIAPIHelper)
        {
            _apiHelper = pIAPIHelper;
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
                    return RedirectToRoute("Main");
                }
            }
            return RedirectToAction("Index");
        }
    }
}