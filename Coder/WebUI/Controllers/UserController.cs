using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coder.WebUI.Dto.Input.User;
using Coder.Core.Service;
using Coder.Service;

namespace Coder.WebUI.Controllers.User
{
    public class UserController : Controller
    {
        private readonly IUserService ius;
        public UserController(IUserService ius)
        {
            this.ius = ius;
        }
        //
        // GET: /Login/

        public ActionResult Login(string username , string password)
        {
            //---
            //此处应该有容错处理...loginInput的新建有约束 可能会出错！！
            if (username != null && password != null)
            {

                LoginInput loginer = new LoginInput();
                loginer.username = username;
                loginer.password = password;
                //---
                return Json(ius.Get(loginer.username, loginer.password));
            }
            else
            {
                return View();
            }
        }
        /// <summary>
        /// 传入用户注册信息..通过input来验证..将input类转换为model类..save
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            RegisterInput register = new RegisterInput();
            
            return null;
        }
        public ActionResult ChangePassword()
        {
            return null;
        }
        public ActionResult ChangelUserInfo()
        {
            return null;
        }
    }
}
