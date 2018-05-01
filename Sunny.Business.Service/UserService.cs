using Sunny.Business.Interface;
using Sunny.EF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunny.Business.Service
{
    public class UserService : BaseService<User>, IUserService
    {
        private DbSet<User> UserSet;
        public UserService(DbContext context) : base(context)
        {
            this.UserSet = base.Context.Set<User>();
        }

        public List<User> GetVip()
        {
            return UserSet.Where(s => s.Level == 2).ToList();
        }
    }
}
