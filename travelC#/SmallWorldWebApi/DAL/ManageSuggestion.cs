using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DAL
{
    public static class ManageSuggestion
    {
        public static Suggestion GetSuggestion(int id)
        {
            try
            {
                using (YMprojectEntities1 entities = new YMprojectEntities1())
                {
                    Suggestion suggestion = entities.Suggestions
                        .Include(ss => ss.bookedDates)
                        .Include(ss => ss.ageRange)
                        .Include(ss => ss.Address)
                        .Include(ss => ss.ServiceTypesToSuggestions)
                        .Include(ss => ss.HoursRange)
                        .First(s => s.SuggestionID == id);
                    int trygit = 1;
                    return suggestion;
                }
            }
            catch { return null; }
        }

        public static List<Suggestion> GetSuggestions(int id)
        {
            try
            {
                using (YMprojectEntities1 entities = new YMprojectEntities1())
                {
                    List<Suggestion> suggestions = entities.Suggestions
                     .Include(ss => ss.bookedDates)
                    .Include(ss => ss.ageRange)
                    .Include(ss => ss.Address)
                    .Include(ss => ss.ServiceTypesToSuggestions)
                    .Include(ss => ss.HoursRange)
                    .Where(s => s.hostId == id).ToList();
                    return suggestions;
                }
            }
            catch (Exception ex) { return null; }
        }

        public static List<Suggestion> GetSuggestionsAll()
        {
            try
            {
                using (YMprojectEntities1 entities = new YMprojectEntities1())
                {
                    List<Suggestion> suggestions = entities.Suggestions
                     .Include(ss => ss.bookedDates)
                    .Include(ss => ss.ageRange)
                    .Include(ss => ss.Address)
                    .Include(ss => ss.ServiceTypesToSuggestions)
                    .Include(ss => ss.HoursRange)
                    .Include(ss => ss.SuggestionTravelers)
                    .ToList();
                    return suggestions;
                }
            }
            catch { return null; }
        }


        public static Suggestion SaveSuggestion(Suggestion suggestion)
        {
            using (YMprojectEntities1 entities = new YMprojectEntities1())
            {
                try
                {
                    entities.Suggestions.Add(suggestion);
                    entities.SaveChanges();
                    return suggestion;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static bool DeleteSuggestion(int id)
        {
            using (YMprojectEntities1 entities = new YMprojectEntities1())
            {
                try
                {
                    Suggestion suggestion = entities.Suggestions.Where(s => s.SuggestionID == id)
                        .Include(ss => ss.ServiceTypesToSuggestions)
                        .Include(ss => ss.bookedDates)
                        .First();
                    if (suggestion.Address != null)
                        entities.Addresses.Remove(suggestion.Address);
                    if (suggestion.ageRange != null)
                        entities.ageRanges.Remove(suggestion.ageRange);
                    if (suggestion.HoursRange != null)
                        entities.HoursRanges.Remove(suggestion.HoursRange);
                    if (suggestion.ServiceTypesToSuggestions != null)
                        entities.ServiceTypesToSuggestions.RemoveRange(suggestion.ServiceTypesToSuggestions);
                    if (suggestion.bookedDates != null)
                        entities.bookedDates.RemoveRange(suggestion.bookedDates);

                    // suggestion.ServiceTypesToSuggestions.Clear();

                    entities.Suggestions.Remove(suggestion);
                    entities.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }

        public static Suggestion UpdateSuggestion(Suggestion suggestion)
        {

            try
            {
                try
                {
                    using (YMprojectEntities1 entities = new YMprojectEntities1())
                    {
                        var ss = entities.Suggestions.First(s => s.SuggestionID == suggestion.SuggestionID);

                        DbEntityEntry<Suggestion> ee = entities.Entry(ss);
                        ee.CurrentValues.SetValues(suggestion);
                        entities.SaveChanges();
                        return suggestion;
                    }
                }
                catch (Exception ex1)
                {
                    int id = suggestion.SuggestionID;
                    using (YMprojectEntities1 entities = new YMprojectEntities1())
                    {

                        //Suggestion ss;
                        var ss = entities.Suggestions.First(s => s.SuggestionID == suggestion.SuggestionID);
                        // ss = suggestion;
                    }
                    using (YMprojectEntities1 entities = new YMprojectEntities1())
                    {
                        suggestion.Host = null;
                        ManageSuggestion.DeleteSuggestion(id);
                    }
                    using (YMprojectEntities1 entities = new YMprojectEntities1())
                    {
                        Suggestion spdt = ManageSuggestion.SaveSuggestion(suggestion);
                        entities.SaveChanges();

                        // Suggestion pdt = entities.Suggestions.Where(spdt => id== spdt.SuggestionID).First();
                        return spdt;
                    }

                }

            }



            catch (Exception ex)
            {
                return null;
            }
        }

        public static SuggestionTraveler SaveSuggestionTraveler(SuggestionTraveler suggestionTraveler)
        {
            using (YMprojectEntities1 entities = new YMprojectEntities1())
            {
                try
                {
                    SuggestionTraveler st = entities.SuggestionTravelers.FirstOrDefault(s => s.SuggestionId == suggestionTraveler.SuggestionId && s.TravelerId == suggestionTraveler.TravelerId);
                    if (st == null)
                    {
                        entities.SuggestionTravelers.Add(suggestionTraveler);
                    }
                    else
                    {
                        st.Status = suggestionTraveler.Status;
                    }
                    entities.SaveChanges();
                    return suggestionTraveler;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }


}




