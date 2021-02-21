using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BL
{
    public static class ManageTraveler
    {
        /// <summary>
        /// קבלת נוסע לפי קוד
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static TravelerDto GetTraveler(int id)
        {
            return Traveler.ToDTO(DAL.ManageTraveler.GetTraveler(id));
        }

        /// <summary>
        /// שמירת נוסע
        /// </summary>
        /// <param name="travelerDto"></param>
        /// <returns></returns>
        public static TravelerDto SaveTraveler(TravelerDto travelerDto)
        {
            return Traveler.ToDTO(DAL.ManageTraveler.SaveTraveler(Traveler.ToUserDAL(travelerDto)));
        }

        /// <summary>
        /// מחיקת נוסע
        /// </summary>
        /// <param name="travelerDto"></param>
        /// <returns></returns>
        public static bool DeleteTraveler(TravelerDto travelerDto)
        {
            return DAL.ManageTraveler.DeleteTraveler(Traveler.ToDAL(travelerDto));
        }

        /// <summary>
        /// עדכון נוסע
        /// </summary>
        /// <param name="travelerDto"></param>
        /// <returns></returns>
        public static bool UpdateTraveler(TravelerDto travelerDto)
        {
            return DAL.ManageTraveler.UpdateTraveler(Traveler.ToDAL(travelerDto));
        }
    }

}

