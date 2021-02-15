using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO;

namespace BL
{
    static public class Suggestion
    {

        public static SuggestionDto ToDTO(DAL.Suggestion model)
        {
            //List<int> vs = new List<int>();
            //List<string> vss = new List<string>();
            //if (model.ServiceTypesToSuggestions.Count > 0)
            //{
            //    foreach (var item in model.ServiceTypesToSuggestions)
            //    {
            //        vs.Add(item.ServiceTypeListID);
            //    }
            //}
            //if (model.ServiceTypesToSuggestions.Count > 0)
            //{
            //    //פה יש שגיאה!!
            //    foreach (var item in model.ServiceTypesToSuggestions)
            //    {
            //        vss.Add(item.ServiceTypeList.ServiceTypeName);
            //    }
            //}
            List<ServiceTypeMapper> lstmp = new List<ServiceTypeMapper>();
            if (model.ServiceTypesToSuggestions.Count > 0)
            {
                foreach (var item in model.ServiceTypesToSuggestions)
               {
                    string s = "";

                    //if (item.ServiceTypeList != null)
                    //    s = item.ServiceTypeList.ServiceTypeName;
                    s = DAL.ManageServicesList.GetServiceNameById(item.ServiceTypeListID);
                   lstmp.Add(new ServiceTypeMapper() { IdServiceType = item.ServiceTypeListID, ServiceTypeName = s });
                   
                }
            }
            SuggestionDto suggestionDto = new SuggestionDto()
            {
                SuggestionID = model.SuggestionID,
                Description = model.SuggestionDescreotion,
                Gender = model.gender,
                // ServicesTypeName = vss, ServicesType = vs,
                Title = model.SuggestionTitle,
                mapperServices = lstmp,
                City = model.Address.city,
                Country = model.Address.country,
                Street = model.Address.street,
                HostId = model.hostId,
                // Status = model.SuggestionTravelers == null ? null : model.SuggestionTravelers.FirstOrDefault()?.Status
                //boo
                
            };
            List<DTO.bookedDate> bookedDateDto = new List<DTO.bookedDate>();
            if (model.bookedDates != null && model.bookedDates.Count > 0)
            {
               
                foreach (var item in model.bookedDates)
                {
                    bookedDateDto.Add(new DTO.bookedDate()
                    {
                        dateEnd = item.dateEnd.Value,
                        dateStart = item.dateStart.Value
                    });
                }
            }
            suggestionDto.bookedDates = bookedDateDto;
            if (model.ageRange != null)
                suggestionDto.RangeAge = new AgeRange()
                {
                    MaxAge = model.ageRange.age_max,
                    MinAge = model.ageRange.age_min,

                };
            if (model.HoursRange != null)
                suggestionDto.RangeHours = new DTO.HoursRange()
                {
                    MaxHour = model.HoursRange.hours_end,
                    StartHour = model.HoursRange.hours_start
                };
            return suggestionDto;
        }

        public static DAL.Suggestion ToDAL(SuggestionDto suggestionDto)
        {
            DAL.Suggestion suggestion = new DAL.Suggestion()
            {
                SuggestionID = suggestionDto.SuggestionID,
                SuggestionDescreotion = suggestionDto.Description,
                SuggestionTitle = suggestionDto.Title,

                Address = new DAL.Address()
                {
                    city = suggestionDto.City,
                    country = suggestionDto.Country,
                    street = suggestionDto.Street,
                },

                gender = suggestionDto.Gender,
                hostId = suggestionDto.HostId,
                
                
            };
            //suggestion.ServiceTypesToSuggestions = suggestionDto.ServicesType.ConvertAll<DAL.ServiceTypesToSuggestion>(s =>
            // {
            //     return new ServiceTypesToSuggestion()
            //     {
            //         ServiceTypeListID = s,

            //     };
            // });
            suggestion.ServiceTypesToSuggestions = suggestionDto.mapperServices.ConvertAll<DAL.ServiceTypesToSuggestion>(s =>
            {
                return new ServiceTypesToSuggestion()
                {
                    ServiceTypeListID = s.IdServiceType,
                   // ServiceTypeList = new ServiceTypeList() { ServiceTypeListID = s.IdServiceType, ServiceTypeName = s.ServiceTypeName },

                };
            }
            );
            if (suggestionDto.RangeHours != null)
                suggestion.HoursRange = new DAL.HoursRange()
                {
                    hours_end = suggestionDto.RangeHours.MaxHour,
                    hours_start = suggestionDto.RangeHours.StartHour
                };
            if (suggestionDto.RangeAge != null)
                suggestion.ageRange = new DAL.ageRange()
                {
                    age_max = suggestionDto.RangeAge.MaxAge,
                    age_min = suggestionDto.RangeAge.MinAge,
                };
            suggestion.bookedDates = suggestionDto.bookedDates.ConvertAll<DAL.bookedDate>(s =>
            {
                return new DAL.bookedDate() { dateEnd = s.dateEnd, dateStart = s.dateStart, };
            });
            return suggestion;
        }
    }
}