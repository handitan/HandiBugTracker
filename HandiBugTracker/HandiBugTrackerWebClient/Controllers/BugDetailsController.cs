using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HandiBugTrackerWebClient.Library.Api;
using HandiBugTrackerWebClient.Library.Models;

namespace HandiBugTrackerWebClient.Controllers
{
    public class BugDetailsController : Controller
    {
        private readonly IBugDetailEndpoint _bugDetailsEndPoint;

        public BugDetailsController(){}
        public BugDetailsController(IBugDetailEndpoint pBugDetailsEndPoint)
        {
            this._bugDetailsEndPoint = pBugDetailsEndPoint;
        }
        // GET: BugDetails
        public async Task<ActionResult> Index(int id)
        {
            var results = await _bugDetailsEndPoint.GetByBugId(id);
            if (results != null && results.Count > 0)
            {
                return View(results[0]);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(CompBugViewModel pComBugViewModel)
        {
            return RedirectToAction("Index", "SaveBug");
        }
    }
}