using Coder.Core.Models.Commons;
using Coder.Core.Models.OnlineJudges;
using Coder.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coder.WebUI.Controllers
{
    public class SingleContestController : Controller
    {
        //
        // GET: /Contest/
        private readonly ISingleContestService iscm;
        private readonly IUserService ius;

        public SingleContestController(ISingleContestService iscm)
        {
            this.iscm = iscm;
        }

        /// <summary>
        /// 显示个人赛全部
        /// </summary>
        /// <returns></returns>
        public ActionResult showSCList()
        {
            if (iscm == null) return View();        //这里404页面

            List<SingleContestModel> scList = iscm.getList();

            if (scList != null)
            {
                //转换为json在前台处理
                return Json(scList);
            }

            else
            {
                return View();
            }
        }
        

        /// <summary>
        /// 参加个人赛
        /// </summary>
        /// <returns></returns>
        public ActionResult joinSingleContest()
        {
            return View();
        }

        /// <summary>
        /// 获取最新个人比赛列表
        /// </summary>
        /// <returns></returns>
        public ActionResult newestList()
        {
            if (iscm == null || Session["uid"] == null) return View();        //这里404页面
            List<SingleContestModel> scList = iscm.getNewestList();

            if (scList != null)
            {
                //转换为json在前台处理
                return Json(scList);
            }

            else
            {
                return View();
            }
        }

        /// <summary>
        /// 获取已经参加的个人比赛列表
        /// </summary>
        /// <returns></returns>
        public ActionResult joinedList()
        {
            Session["uid"] = 1;
            if (iscm == null || Session["uid"] == null) return View();        //这里404页面

            /////////从session中或cookie中读取当前用户id
            int uid = (int)Session["uid"];
            

            List<SingleContestModel> scList = iscm.getJoinedList(uid);

            if (scList != null)
            {
                //转换为json在前台处理
                return Json(scList);
            }

            else
            {
                return View();
            }
        }

        /// <summary>
        /// 获取未参加的个人比赛列表
        /// </summary>
        /// <returns></returns>
        public ActionResult unjoinedList()
        {
            Session["uid"] = 1;
            if (iscm == null || Session["uid"] == null) return View();        //这里404页面

            /////////从session中或cookie中读取当前用户id
            int uid = (int)Session["uid"];
            

            List<SingleContestModel> scList = iscm.getUnjoinedList(uid);

            if (scList != null)
            {
                //转换为json在前台处理
                return Json(scList, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return View();
            }
            
        }

        /// <summary>
        /// 获取正在进行中的个人比赛列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ingList()
        {
            if (iscm == null || Session["uid"] == null) return View();        //这里404页面
            List<SingleContestModel> scList = iscm.getIngList();

            if (scList != null)
            {
                //转换为json在前台处理
                return Json(scList);
            }

            else
            {
                return View();
            }
        }

        /// <summary>
        /// 获取即将开始的比赛列表
        /// </summary>
        /// <returns></returns>
        public ActionResult waitList()
        {
            if (iscm == null || Session["uid"] == null) return View();        //这里404页面
            List<SingleContestModel> scList = iscm.getIngList();

            if (scList != null)
            {
                //转换为json在前台处理
                return Json(scList);
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// 个人比赛列表排序
        ///  更具获取到的参数进行查询排序
        /// </summary>
        /// <returns></returns>
        public ActionResult order(string factor)
        {
            if (iscm == null || Session["uid"] == null) return View();        //这里404页面
            List<SingleContestModel> scList = iscm.getOrderList(factor);

            if (scList != null)
            {
                //转换为json在前台处理
                return Json(scList);
            }
            else
            {
                return View();
            }
        }


        //========================================单场比赛
        /// <summary>
        /// 进入单场个人赛 
        /// </summary>
        /// <returns></returns>
        public ActionResult singleContest(int scId)
        {
            if (iscm == null || Session["uid"] == null) return View();        //这里404页面
            SingleContestModel sc = iscm.getSingleContest(scId);

            if (sc != null)
            {
                //转换为json在前台处理
                return Json(sc);
            }
            else
            {
                return View();
            }
        }
    }
}
