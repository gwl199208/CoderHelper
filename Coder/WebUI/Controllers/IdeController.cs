using Coder.Core.Models.OnlineJudges;
using Coder.Core.Service;
using Coder.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coder.WebUI.Controllers
{
    public class IdeController : Controller
    {
        private readonly ISingleContestService iscm;
        private readonly ITeamContestService itcm;
        public IdeController(ISingleContestService iscm ,ITeamContestService itcm)
        {
            this.itcm = itcm;
            this.iscm = iscm;
        }

        /// <summary>
        /// 编辑器
        /// </summary>
        /// <returns></returns>
        public ActionResult editor()
        {

            return View();
        }

       
        /// <summary>
        /// 编译黑盒部分的action
        /// 编译的黑盒：
        /// 1.读入源码
        /// 2.对源码进行检查
        /// 3.将源码放入缓冲表，并将其编译状态确定为等待，并填写编译语言的属性（用哪种代码写的）
        /// 
        ///     
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult compile()
        {

            //接收参数
            
            string code = Request["code"];      //源码
            string uid = Request["uid"];        //谁在做题    若是多人做题按提交用户来算
            string teamId = Request["teamId"];        //哪个队在做
            string pid = Request["pid"];        //做的是哪道题
            string langue = Request["langue"];        //用什么语言
            string problemBelongs = Request["problemBelongs"];  //题目是个人赛题、团队赛题、或普通题目
            string singleContestId = Request["singleContestId"];
            string teamContestId = Request["teamContestId"];
            if (!CommonOpration.isStringValid(code) ||
                !CommonOpration.isStringValid(uid) ||
                !CommonOpration.isStringValid(teamId) ||
                !CommonOpration.isStringValid(pid) ||
                !CommonOpration.isStringValid(langue) ||
                !CommonOpration.isStringValid(problemBelongs)) 
            { return View();/*这里应该出错处理*/ }

            int _uid = Convert.ToInt32(uid);
            int _teamId = Convert.ToInt32(teamId);
            int _pid = Convert.ToInt32(pid);
            
            //这里获取提交时间
            if (problemBelongs == "TEAMP")
            { 
                int _teamContestId = Convert.ToInt32(teamContestId) ;
                if(!CommonOpration.isStringValid(teamContestId) &&
                    itcm.isCurSubmitRecodeValid(_teamContestId ,
                    _uid , _pid))
                { return View();/*这里应该出错处理*/ }
                //存储提交记录到结果表
                TeamResultModel teamResult = new TeamResultModel() {
                    teamResultStatus = "QUEUE",
                    teamContestId = _teamContestId,
                    baseProblemId = _pid , userId = _uid ,
                    teamId = _teamId , 
                    teamResultLanguage = langue
                };

            }
            else if (problemBelongs == "SINGLEP")
            {
                if (!CommonOpration.isStringValid(singleContestId) &&
                    iscm.isCurSubmitRecodeValid(Convert.ToInt32(singleContestId),
                    _uid , _pid))
                { return View();/*这里应该出错处理*/ }
                //存储提交记录到结果表

            }
            else 
            { 
            
            }

            return View();
        }



    }
}
