using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using DjCollab.Party;
using Microsoft.Owin.Security.Provider;

namespace DjCollab.Api.Controllers
{
    [RoutePrefix("api/v1/party")]
    public class PartyController : ApiController
    {
        private IPartyService partyService;

        public PartyController()
        {
            partyService = new PartyService();
        }

        public PartyController(IPartyService partyService)
        {
            this.partyService = partyService;
        }

        /// <summary>
        /// Gets a party based on a specified Id.
        /// </summary>
        /// <param name="partyId">Id of the party to retrieve.</param>
        [HttpGet]
        [Route("{partyId}")]
        [ResponseType(typeof (Party.Model.Party))]
        public void GetParty(string partyId)
        {
            partyService.GetParty(int.Parse(partyId));
        }

        /// <summary>
        /// Get a list of all active parties.
        /// </summary>
        /// <returns>List of all active parties.</returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IList<Party.Model.Party>))]
        public IHttpActionResult GetParties()
        {
            var parties = partyService.GetAllParties();
            return Ok(parties);
        }

        /// <summary>
        /// Adds a song to a party's playlist.
        /// </summary>
        /// <param name="partyId">Id of the party to add the song to.</param>
        /// <param name="songId">Id of the song the user is trying to add.</param>
        /// <returns>Updated party object.</returns>
        [HttpPut]
        [Route("{partyId}/{songId}")]
        [ResponseType(typeof(Party.Model.Party))]
        public IHttpActionResult AddSongToParty(string partyId, string songId)
        {
            try
            {
                var party = partyService.AddSongToParty(int.Parse(partyId), songId);
                return Ok(party);
            }
            catch (FormatException e)
            {
                ErrorController.Errors.Add(e);
                return InternalServerError(e);
            }
            catch (Exception e)
            {
                ErrorController.Errors.Add(e);
                return InternalServerError(e);
            }

        }

        /// <summary>
        /// Removes a song from the playlist of a given party.
        /// </summary>
        /// <param name="partyId">Id of the party to remove the song from.</param>
        /// <param name="songId">Id of the song to remove from the party.</param>
        /// <returns>Updated party state.</returns>
        [HttpDelete]
        [Route("{partyId}/{songId}")]
        [ResponseType(typeof (Party.Model.Party))]
        public IHttpActionResult DeleteSongFromParty(string partyId, string songId)
        {
            var party = partyService.DeleteSongFromParty(int.Parse(partyId), songId);
            return Ok(party);
        }

        /// <summary>
        /// Creates a party.
        /// </summary>
        /// <param name="name">Name of the party.</param>
        /// <returns>Created party object.</returns>
        [HttpPut]
        [Route("create/{name}")]
        [ResponseType(typeof(Party.Model.Party))]
        public IHttpActionResult CreateParty(string name)
        {
            var createdParty = partyService.CreateParty(name);

            return Ok(createdParty);
        }
    }
}
