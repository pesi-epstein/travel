using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
namespace SmallWorldWebApi.Controllers
{  // [RoutePrefix("Suggestion")]
    public class SuggestionController : ApiController
    {

        [HttpPost]
        [Route("Suggestion")]
        public IHttpActionResult AddSuggestion(SuggestionDto suggestionDto)
            {
            ;
            SuggestionDto s = BL.ManageSuggestion.SaveSuggestion(suggestionDto);
            if (s != null) 
                return Created<SuggestionDto>("The content inserted into the database successfully", s);
            return InternalServerError();
        }
        [HttpPut]
        [Route("Suggestion")]
        public IHttpActionResult UpdateSuggestion(SuggestionDto suggestionDto)
        {
            ;
            SuggestionDto s=   BL.ManageSuggestion.UpdateSuggestion(suggestionDto);
            if (s != null)
                return Ok(BL.ManageSuggestion.GetSuggestions(suggestionDto.HostId));
            return InternalServerError();
        }
        [HttpGet]
        [Route("Suggestion/{id}")]
        public IHttpActionResult GetSuggestion([FromUri]int id)
        {
            return Ok(BL.ManageSuggestion.GetSuggestion(id));
        }

        [HttpGet]
        [Route("Suggestions/{id}")]
        public IHttpActionResult GetSuggestions([FromUri] int id)
        {
            return Ok(BL.ManageSuggestion.GetSuggestions(id));
        }

        [HttpGet]
        [Route("SuggestionsAll")]
        public IHttpActionResult GetSuggestionsAll()
        {
            return Ok(BL.ManageSuggestion.GetSuggestionsAll());
        }

        [HttpGet]
        [Route("SuggestionsWithStatus/{travelerId}")]
        public IHttpActionResult GetSuggestionsWithStatus([FromUri] int travelerId)
        {
            return Ok(BL.ManageSuggestion.GetSuggestionsWithStatus(travelerId));
        }

        [HttpDelete]
        [Route("Suggestion/{id}")]
        public IHttpActionResult DeleteSuggestion([FromUri] int id,[FromUri] UserDto u)
        {
           if( BL.ManageSuggestion.DeleteSuggestion(id))
            return Ok(BL.ManageSuggestion.GetSuggestions(u.UserID));
            return InternalServerError();
        }

        [HttpPut]
        [Route("SaveStatus")]
        public IHttpActionResult AddOrUpdateSuggestionStatus(SuggestionTravelerDto suggestionTravelerDto)
        {
            SuggestionTravelerDto st = BL.ManageSuggestion.SaveSuggestionTraveler(suggestionTravelerDto);
            if (st != null)
                return Created<SuggestionTravelerDto>("The content inserted into the database successfully", st);
            return InternalServerError();
        }
        //add new suggestation
        //country city street 
        //[דרישות]
        //dto object that contains all דרישות
        //save in db the place
        //save the דרישות


    }
}
