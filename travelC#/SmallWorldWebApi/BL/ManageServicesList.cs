using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BL
{
  public static  class ManageServicesList
    {
        /// <summary>
        /// קבלת שרותיים
        /// </summary>
        /// <returns></returns>
        public static List<ServiceTypeMapper> GetServicesList()
        {
           List< DAL.ServiceTypeList> servicesList = DAL.ManageServicesList.GetServicesList();
            List<ServiceTypeMapper> serviceTypeMapperDto = servicesList.ConvertAll(s =>
            { return new ServiceTypeMapper() { IdServiceType = s.ServiceTypeListID, ServiceTypeName = s.ServiceTypeName }; });

            return serviceTypeMapperDto;
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

        public static HostDto UpdateHost(HostDto hostDto)
        {
            return Host.ToDTO( DAL.ManageHost.UpdateHost(Host.ToDAL(hostDto)));
        }





    }
}
