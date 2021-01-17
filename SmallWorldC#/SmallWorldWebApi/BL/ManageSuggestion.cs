using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BL
{
 public static   class ManageSuggestion
    {

        /// <summary>
        /// קבלת הצעה לפי קוד
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SuggestionDto GetSuggestion(int id)
        {
            return Suggestion.ToDTO(DAL.ManageSuggestion.GetSuggestion(id));
        }

        /// <summary>
        ///לפי מארח קבלת הצעות 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List< SuggestionDto> GetSuggestions(int id)
        {
            List<SuggestionDto> dto = new List<SuggestionDto>();
            foreach (var item in DAL.ManageSuggestion.GetSuggestions(id))
            {
                dto.Add(Suggestion.ToDTO(item));
            }
            return dto;
        }

        /// <summary>
        /// קבלת כל הצעות
        /// </summary>
        /// <returns></returns>
        public static List<SuggestionDto> GetSuggestionsAll()
        {
            List<SuggestionDto> dto = new List<SuggestionDto>();
            foreach (var item in DAL.ManageSuggestion.GetSuggestionsAll())
            {
                dto.Add(Suggestion.ToDTO(item));
            }
            return dto;
        }

        /// <summary>
        /// שמירת הצעה
        /// </summary>
        /// <param name="suggestionDto"></param>
        /// <returns></returns>
        public static SuggestionDto SaveSuggestion(SuggestionDto suggestionDto)
        {
            return Suggestion.ToDTO( DAL.ManageSuggestion.SaveSuggestion(Suggestion.ToDAL(suggestionDto)));
        }

        /// <summary>
        /// מחיקת הצעה
        /// </summary>
        /// <param name="suggestionDto"></param>
        /// <returns></returns>
        public static bool DeleteSuggestion(int id)
        {
            return DAL.ManageSuggestion.DeleteSuggestion(id);
        }

        /// <summary>
        /// עדכון הצעה
        /// </summary>
        /// <param name="suggestionDto"></param>
        /// <returns></returns>
        public static SuggestionDto UpdateSuggestion(SuggestionDto suggestionDto)
        {
            return Suggestion.ToDTO( DAL.ManageSuggestion.UpdateSuggestion(Suggestion.ToDAL(suggestionDto)));
        }

    }
}
