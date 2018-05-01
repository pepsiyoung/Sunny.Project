using Sunny.EF.Model;
using Sunny.Framework.AOP.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunny.Business.Interface
{   
    public interface IUserService : IBaseService<User>
    {
        [LogHandler(Order = 1)]
        List<User> GetVip();
    }
}
