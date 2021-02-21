using System;
using DTO;
using System.Collections.Generic;
using System.Linq;
namespace DAL
{
    public class ManageUser
    {
        public static User Login(User u)
        {
            try
            {
                using (YMprojectEntities1 ym = new YMprojectEntities1())
                {
                    User uu = null;
                    uu=ym.Users.Where(user => user.UserName == u.UserName && user.UserPassword == u.UserPassword).First();
                    if (uu == null)
                        throw new Exception("user name or password are incorect");
                    return uu;
                }
            }
            catch(Exception e)
            {
                return null;
            }
           
        }
        public static bool IsExist (string userName)
        {
            try
            {
                using (YMprojectEntities1 entities = new YMprojectEntities1())
                {
                   return entities.Users.Any(u => u.UserName.Equals(userName));
                }
            }
            catch (Exception e)
            {
                //print exception
                return false;
            }
        }
    }
}