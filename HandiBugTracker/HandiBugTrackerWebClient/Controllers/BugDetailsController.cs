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
        private readonly PeopleViewModel _peopleViewModel;

        public BugDetailsController(){}
        public BugDetailsController(
            IBugDetailEndpoint pBugDetailsEndPoint, 
            ICompBugAllOptionsEndPoint pCompBugAllOptionsEndPoint,
            PeopleViewModel pPeopleViewModel)
        {
            this._bugDetailsEndPoint = pBugDetailsEndPoint;
            this._compBugAllOptionsEndPoint = pCompBugAllOptionsEndPoint;
            this._peopleViewModel = pPeopleViewModel;
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var bugOptions = await _compBugAllOptionsEndPoint.GetAll();
            var bugAllDetails = new BugAllDetailsViewModel()
            {
                CompBug = new CompBugViewModel(),
                CompBugOptions = bugOptions
            };

            //TODO revisit this later
            bugAllDetails.CompBug.AssigneeName = _peopleViewModel.LoggedInFullName;
            TempData["ReporterId"] = _peopleViewModel.LoggedInUserId;
            TempData["AssigneeId"] = _peopleViewModel.LoggedInUserId;
            TempData["QAId"] = _peopleViewModel.LoggedInUserId;

            return View(bugAllDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BugAllDetailsViewModel pBugAllDetailsViewModel)
        {
            try
            {
                pBugAllDetailsViewModel.CompBug.ReporterId = TempData["ReporterId"].ToString();
                pBugAllDetailsViewModel.CompBug.AssigneeId = TempData["AssigneeId"].ToString();
                pBugAllDetailsViewModel.CompBug.QAId = TempData["QAId"].ToString();

                await _bugDetailsEndPoint.Create(pBugAllDetailsViewModel.CompBug);
                return RedirectToAction("Index", "SaveBug");
            }
            catch
            {
                return View("Error");
            }
        }


        // GET: BugDetails
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var bugDetails = await _bugDetailsEndPoint.GetByBugId(id);
            var bugOptions = await _compBugAllOptionsEndPoint.GetAll();
            if (bugDetails != null && bugDetails.Count > 0)
            {
                var bugAllDetails = new BugAllDetailsViewModel();
                bugAllDetails.CompBug = bugDetails[0];
                bugAllDetails.CompBugOptions = bugOptions;

                TempData["ReporterId"] = bugAllDetails.CompBug.ReporterId;
                TempData["AssigneeId"] = bugAllDetails.CompBug.AssigneeId;
                TempData["QAId"] = bugAllDetails.CompBug.QAId;
                return View(bugAllDetails);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BugAllDetailsViewModel pBugAllDetailsViewModel)
        {
            try
            {
                pBugAllDetailsViewModel.CompBug.ReporterId = TempData["ReporterId"].ToString();
                pBugAllDetailsViewModel.CompBug.AssigneeId = TempData["AssigneeId"].ToString();
                pBugAllDetailsViewModel.CompBug.QAId = TempData["QAId"].ToString();

                await _bugDetailsEndPoint.Edit(pBugAllDetailsViewModel.CompBug);
                return RedirectToAction("Index", "SaveBug");
            }
            catch
            {
                return View("Error");
            }
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _bugDetailsEndPoint.Delete(id);
                //return RedirectToAction("Index", "SaveBug");
                return Json(new { success = true, redirectUrl = "/SaveBug/Index" });
            }
            catch
            {
                return View("Error");
            }
        }
    }
}