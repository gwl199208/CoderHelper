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
    public class TeamContestController : Controller
    {

        
        private readonly ITeamContestService itcm;
        private readonly IUserService ius;

        public TeamContestController(ITeamContestService itcm)
        {
            this.itcm = itcm;
        }
        //
        // GET: /TeamContest/

        /// <summary>
        /// 显示个团队赛全部
        /// </summary>
        /// <returns></returns>
        public ActionResult showTCList()
        {
            if (itcm == null) return View();        //这里404页面

            List<TeamContestModel> tcList = itcm.getList();

            if (tcList != null)
            {
                //转换为json在前台处理
                return Json(tcList);
            }

            else
            {
                return View();
            }
        }


        /// <summary>
        /// 获取最新团队赛列表
        /// </summary>
        /// <returns></returns>
        public ActionResult newestList()
        {
            if (itcm == null || Session["uid"] == null) return View();        //这里404页面
            List<TeamContestModel> scList = itcm.getNewestList();

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
        /// 获取已经参加的团队赛列表
        /// </summary>
        /// <returns></returns>
        public ActionResult joinedList()
        {
            if (itcm == null || Session["uid"] == null) return View();        //这里404页面

            /////////从session中或cookie中读取当前用户id
            int uid = (int)Session["uid"];

            List<TeamContestModel> scList = itcm.getJoinedList(uid);

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
        /// 获取未参加的团队赛列表
        /// </summary>
        /// <returns></returns>
        public ActionResult unjoinedList()
        {
            if (itcm == null || Session["uid"] == null) return View();        //这里404页面

            /////////从session中或cookie中读取当前用户id
            int uid = (int)Session["uid"];


            List<TeamContestModel> scList = itcm.getUnjoinedList(uid);

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
        /// 获取正在进行中的团队赛列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ingList()
        {
            if (itcm == null || Session["uid"] == null) return View();        //这里404页面
            List<TeamContestModel> scList = itcm.getIngList();

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
            if (itcm == null || Session["uid"] == null) return View();        //这里404页面
            List<TeamContestModel> scList = itcm.getIngList();

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
        /// 团队赛列表排序
        ///  更具获取到的参数进行查询排序
        /// </summary>
        /// <returns></returns>
        public ActionResult order(string factor)
        {
            if (itcm == null || Session["uid"] == null) return View();        //这里404页面
            List<TeamContestModel> scList = itcm.getOrderList(factor);

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
        /// 参加团队赛
        /// </summary>
        /// <returns></returns>
        public ActionResult joinTeamContest(int teamContestId, int uid)
        {
            ///////
            if (itcm.addUserToTeam(teamContestId, new UserModel { uid = uid }))
                return JavaScript(string.Format("alter('{0}');", "参加团队成功"));      //提示出错
            else
                return View();
        }

        //========================================单场比赛
        /// <summary>
        /// 进入单场团队赛 
        /// </summary>
        /// <returns></returns>
        public ActionResult teamContest(string factor)
        {
            return View();
        }


    }
}
