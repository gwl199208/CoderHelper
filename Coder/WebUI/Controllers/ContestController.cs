using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coder.WebUI.Controllers
{
    public class ContestController : Controller
    {
        //
        // GET: /Contest/

        /// <summary>
        /// 比赛页
        /// </summary>
        /// <returns></returns>
        public ActionResult ContestContent()
        {
            return View();
        }


        /// <summary>
        /// 比赛列表页
        /// </summary>
        /// <returns></returns>
        public ActionResult ContestList()
        {
            return View();
        }

    }
}
