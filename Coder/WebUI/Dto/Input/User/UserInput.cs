using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Coder.WebUI.Dto.Attribute;

namespace Coder.WebUI.Dto.Input.User
{
    public class LoginInput
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class RegisterInput
    {
        [RegisterUnique]
        public string username { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
        public string sex { get; set; }
        public string school { get; set; }
        public string nickname { get; set; }
    }

    public class ChangePwInput : InputBase
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }

    public class ChangeUserInfo : InputBase
    {

    }
}