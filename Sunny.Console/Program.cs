using Sunny.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunny.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User() { UserName = "钢铁侠", Nick = "Iron Man", Password = "789456", Level = 2, Phone = "15509876543", Url = "www.google.com" };
            MyContext context = new MyContext();
            context.User.Add(user);
            context.SaveChanges();
        }
    }
}
