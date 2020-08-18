using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HandiBugTrackerWebClient.Library.Api;
using HandiBugTrackerWebClient.Library.Models;
using HandiBugTrackerWebClient.Models;

namespace HandiBugTrackerWebClient.Controllers
{
    public class BugDetailsController : Controller
    {
        private readonly IBugDetailEndpoint _bugDetailsEndPoint;
        private readonly ICompBugAllOptionsEndPoint _compBugAllOptionsEndPoint;

        public BugDetailsController(){}
        public BugDetailsController(IBugDetailEndpoint pBugDetailsEndPoint, ICompBugAllOptionsEndPoint pCompBugAllOptionsEndPoint)
        {
            this._bugDetailsEndPoint = pBugDetailsEndPoint;
            this._compBugAllOptionsEndPoint = pCompBugAllOptionsEndPoint;
        }
        // GET: BugDetails
        public async Task<ActionResult> Index(int id)
        {
            var bugDetails = await _bugDetailsEndPoint.GetByBugId(id);
            var bugOptions = await _compBugAllOptionsEndPoint.GetAll();
            if (bugDetails != null && bugDetails.Count > 0)
            {
                var bugAllDetails = new BugAllDetailsViewModel();
                bugAllDetails.CompBug = bugDetails[0];
                bugAllDetails.CompBugOptions = bugOptions;
                return View(bugAllDetails);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(BugAllDetailsViewModel pBugAllDetailsViewModel)
        {
            return RedirectToAction("Index", "SaveBug");
        }
    }
}