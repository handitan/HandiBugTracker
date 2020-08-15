using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HandiBugTrackerWebClient.Library.Api;
using X.PagedList;

namespace HandiBugTrackerWebClient.Controllers
{
    public class BugListController : Controller
    {
        private readonly IBugListEndpoint _bugListEndpoint;

        public BugListController(){}
        public BugListController(IBugListEndpoint pBugListEndpoint)
        {
            this._bugListEndpoint = pBugListEndpoint;
        }
        // GET: BugList
        public async Task<ActionResult> Index()
        {
            var bugList = await _bugListEndpoint.GetAll();
            int pageSize = 3;
            int pageNumber = 1;// (page ?? 1);
            var pagedList = await bugList.ToPagedListAsync(pageNumber, pageSize);
            return View(pagedList);
        }
    }
}