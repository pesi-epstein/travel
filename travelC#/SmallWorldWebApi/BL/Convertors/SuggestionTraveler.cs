using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SuggestionTraveler
    {
        public static SuggestionTravelerDto ToDTO(DAL.SuggestionTraveler model)
        {
            SuggestionTravelerDto suggestionTravelerDto = new SuggestionTravelerDto()
            {
                SuggestionId = model.SuggestionId,
                TravelerId = model.TravelerId,
                Status = model.Status
            };
            return suggestionTravelerDto;
        }

        public static DAL.SuggestionTraveler ToDAL(SuggestionTravelerDto suggestionTravelerDto)
        {
            DAL.SuggestionTraveler suggestionTraveler = new DAL.SuggestionTraveler()
            {
                SuggestionId = suggestionTravelerDto.SuggestionId,
                TravelerId = suggestionTravelerDto.TravelerId,
                Status = suggestionTravelerDto.Status
            };
            return suggestionTraveler;
        }
    }
}
