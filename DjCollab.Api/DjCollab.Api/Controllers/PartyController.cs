using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using DjCollab.Party;

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
        /// Get a list of all active parties.
        /// </summary>
        /// <returns>List of all active parties.</returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof (IList<Party.Model.Party>))]
        public IHttpActionResult GetParties()
        {
            var parties = partyService.GetAllParties();
            return Ok(parties);
        }

        /// <summary>
        /// Adds a song to a party's playlist.
        /// </summary>
        /// <param name="partyId">Id of the party to add the song to.</param>
        /// <param name="senderId">Id of the user attempting to add the song.</param>
        /// <param name="songId">Id of the song the user is trying to add.</param>
        /// <returns>Updated party object.</returns>
        [HttpPut]
        [Route("{partyId}/{songId}")]
        [ResponseType(typeof (Party.Model.Party))]
        public IHttpActionResult AddSongToParty(string partyId, string senderId, string songId)
        {
            var party = partyService.AddSongToParty(int.Parse(partyId), int.Parse(senderId), int.Parse(songId));

            return Ok(party);
        }

        /// <summary>
        /// Creates a party.
        /// </summary>
        /// <param name="userId">User attempting to host a party.</param>
        /// <param name="party">Party creation information.</param>
        /// <returns>Created party object.</returns>
        [HttpPut]
        [Route("create/{userId}")]
        [ResponseType(typeof (Party.Model.Party))]
        public IHttpActionResult CreateParty(string userId, Party.Model.Party party)
        {
            var createdParty = partyService.CreateParty(int.Parse(userId), party);

            return Ok(createdParty);
        }
    }
}
