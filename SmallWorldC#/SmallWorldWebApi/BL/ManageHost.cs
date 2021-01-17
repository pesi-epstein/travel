using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BL
{
  public static  class ManageHost
    {

        /// <summary>
        /// קבלת מארח
        /// </summary>
        /// <param name="id">קוד מארח</param>
        /// <returns></returns>
        public static HostDto GetHost(int id)
        {
            return Host.ToDTO(DAL.ManageHost.GetHost(id));
        }

        /// <summary>
        /// שמירת מארח
        /// </summary>
        /// <param name="hostDto"></param>
        /// <returns></returns>
        public static HostDto SaveHost(HostDto hostDto)
        {

            return Host.ToDTO( DAL.ManageHost.SaveHost(Host.ToUserDAL(hostDto)));
        }

        /// <summary>
        /// מחיקת מארח
        /// </summary>
        /// <param name="hostDto"></param>
        /// <returns></returns>
        public static bool DeleteHost(UserDto hostDto)
        {
            return DAL.ManageHost.DeleteHost(User.ToDAL(hostDto));
        }

        /// <summary>
        /// עדכון מארח
        /// </summary>
        /// <param name="hostDto"></param>
        /// <returns></returns>
        public static HostDto UpdateHost(HostDto hostDto)
        {
            return Host.ToDTO( DAL.ManageHost.UpdateHost(Host.ToDAL(hostDto)));
        }

    }
}
