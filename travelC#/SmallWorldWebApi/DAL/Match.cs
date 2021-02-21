using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.Entity;
namespace DAL
{
    public static class Match
    {
        public static DAL.YMprojectEntities1 entities1 = new YMprojectEntities1();
        private static bool Between(this int input, int num1, int num2)
        {
            return (input >= num1 && input <= num2);
        }
        private static int AgeInYears(this DateTime birthDate)
        {
            return DateTime.Now.Year - birthDate.Year;
        }

        private static bool CalcRanges(int sugStart, int sugEnd, int reqStart, int reqEnd)
        {
            int sectionStart;
            int sectionEnd;
            int overlappingStart;
            int overlappingEnd;
            if (sugStart > reqStart)
            {

                sectionStart = reqStart;
                overlappingStart = sugStart;
            }
            else
            {
                sectionStart = sugStart;
                overlappingStart = reqStart;
            }

            if (sugEnd > reqEnd)
            {

                sectionEnd = sugEnd;
                overlappingEnd = reqEnd;
            }
            else
            {
                sectionEnd = reqEnd;
                overlappingEnd = sugEnd;
            }
            if ((double)(overlappingEnd - overlappingStart) / (double)(sectionEnd - sectionStart) < 0.5)
            {
                bool contained = (sugEnd == overlappingEnd && sugStart == overlappingStart) ||
                (reqEnd == overlappingEnd && reqStart == overlappingStart);
                if (!contained)
                    return false;
            }
            return true;
        }
        private static bool Between(this DateTime input, DateTime date1, DateTime date2)
        {
            return (input >= date1 && input <= date2);
        }
        private static bool checkAdress(Suggestion suggestion, RequestDto requestDto)
        {
            if (suggestion.Address.country == requestDto.Country)
            {
                if (
                    ((requestDto.City != null || requestDto.City != "") && requestDto.City == suggestion.Address.city)//יש דרישה של עיר והיא שווה
                    || ((requestDto.City == null || requestDto.City == ""))//אין דרישה של עיר
                    )
                {

                    if (
                        ((requestDto.Street != null || requestDto.Street != "") && requestDto.Street == suggestion.Address.street)//יש דרישה של עיר והיא שווה
                        || ((requestDto.Street == null || requestDto.Street == ""))//אין דרישה של עיר
                        )
                        return true;
                }
            }
            return false;
        }
        private static bool checkGender(Suggestion suggestion, RequestDto requestDto)
        {
            if ((suggestion.gender == requestDto.Traveler.gender || suggestion.gender == null || suggestion.gender == ""))
            {
                if (requestDto.Gender == "" || requestDto.Gender == null)
                    return true;
                if (suggestion.Host.gender == requestDto.Gender)
                    return true;
            }
            return false;
        }
        private static bool checkDate(Suggestion s, RequestDto requestDto)
        {

            foreach (var item in s.bookedDates)
            {
                if (!(item.dateEnd.Value.Between(requestDto.DateStart, requestDto.DateEnd)) ||
                !(item.dateStart.Value.Between(requestDto.DateStart, requestDto.DateEnd)))
                    return false;
            }
            return true;
        }
        private static bool checkAge(Suggestion s, RequestDto requestDto)
        {
            if (s.ageRange == null ||
                requestDto.Traveler.BirthDate.AgeInYears().Between(s.ageRange.age_min, s.ageRange.age_max)//גיל המבקש בטווח הגיל המבוקש על ידי המציע

                )
            {
                if (requestDto.AgeRange == null || s.Host.BirthDate.AgeInYears().Between(requestDto.AgeRange.MinAge, requestDto.AgeRange.MaxAge))
                    return true;
            }
            return false;
        }
        private static bool checkHours(Suggestion s, RequestDto requestDto)
        {
            if (s.HoursRange != null && requestDto.HoursRange != null)
            {
                if (!CalcRanges(s.HoursRange.hours_start, s.HoursRange.hours_end, requestDto.HoursRange.StartHour, requestDto.HoursRange.MaxHour))
                    return false;
            }
            return true;
        }
        private static bool checkServicesTypes(Suggestion s, RequestDto requestDto)
        {
            if (requestDto.ServicesTypes != null && requestDto.ServicesTypes.Count != 0)
            {
                foreach (int sID in requestDto.ServicesTypes)
                {
                    if (s.ServiceTypesToSuggestions.FirstOrDefault(st => st.ServiceTypeListID == sID) != null)
                    {
                        return true;
                    }
                }
                return false;
            }
            return true;
        }
        public static bool te(Suggestion s, RequestDto requestDto)
        {

            return checkAdress(s, requestDto)
                && checkAge(s, requestDto)
                && checkDate(s, requestDto)
                && checkGender(s, requestDto)
                && checkHours(s, requestDto)
                && checkServicesTypes(s, requestDto);

        }
        public static List<Suggestion> GetMatchingSuggestions(RequestDto requestDto)
        {
            try
            {
                return entities1.Suggestions
                .Include(i => i.Address)
                .Include(i => i.ageRange)
                .Include(i => i.bookedDates)
                .Include(i => (i.ServiceTypesToSuggestions))
                .Include(i => i.HoursRange)
                .Include(i => i.Host)
                .Include(i => i.SuggestionTravelers)
                .Where(delegate (Suggestion s)
                 {
                     return te(s, requestDto);
                 }).ToList();

            }
            catch (Exception e) { return null; }
        }
    }
}
