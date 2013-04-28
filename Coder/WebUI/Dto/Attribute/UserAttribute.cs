using System;
using System.ComponentModel.DataAnnotations;
using Coder.Core.Service;
using Coder.Infra;
using Coder.Service;



namespace Coder.WebUI.Dto.Attribute
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class RegisterUniqueAttribute : ValidationAttribute
    {
        private static readonly string DefaultErrorMessage = "用户名已存在";//;
        public RegisterUniqueAttribute()
            : base(DefaultErrorMessage)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            return DefaultErrorMessage;
        }

        public override bool IsValid(object value)
        {
            if (string.IsNullOrEmpty((string)value)) return true;
            return IoC.Resolve<IUserService>().IsUnique((string)value);
        }
    }


}