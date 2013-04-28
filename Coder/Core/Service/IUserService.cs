using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coder.Core.Models.Commons;

namespace Coder.Core.Service
{
    public interface IUserService : ICrudService<UserModel>
    {
        UserModel Get(string username, string password);
        int ChangePassword(int id, string password);
        bool IsUnique(string username);
    }
}
