using System;
using System.Collections.Generic;
using System.Linq;
using Coder.Core.Models.Commons;
using Coder.Core.Service;
using Coder.Core.Repository;

namespace Coder.Service
{
    public class UserService : CrudService<UserModel> , IUserService
    {
        public UserService(IRepository<UserModel> repo)
            : base(repo)
        {
        }
        public UserModel Get(string username, string password)
        {
            var user = repo.Where(o => o.username == username).SingleOrDefault();
            if (user == null || password.CompareTo(user.password) != 0) return null;
            return user;
        }

        public int ChangePassword(int id, string password)
        {
            Get(id).password = password;
            return Save();
        }

        public bool IsUnique(string username)
        {
            return false;
        }
    }
}
