using Coder.Core.Models.OnlineJudges;
using Coder.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coder.WebUI.Controllers
{
    public class TempController : Controller
    {
        //
        // GET: /Temp/
        private readonly ITeamContestService itcm;
        public TempController(ITeamContestService itcm)
        {
            this.itcm = itcm;
        }

        public ActionResult Index()
        {
            TeamResultModel teamResult = new TeamResultModel()
            {
                teamResultStatus = "QUEUE",
                teamContestId = 1,
                baseProblemId = 1,
                userId = 1,
                teamId = 1,
                teamResultLanguage = "C++",
                teamResultSubmitTime = Convert.ToDateTime("2007-8-1")
            };

            itcm.saveTeamContestResult(teamResult);
            return View();
        }

    }
}
