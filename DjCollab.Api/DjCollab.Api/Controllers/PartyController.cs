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
        public IHttpActionResult AddSongToParty(string partyId, string songId)
        {
            //var party = partyService.AddSongToParty(int.Parse(partyId), songId);

            return Ok();
        }

        /// <summary>
        /// Creates a party.
        /// </summary>
        /// <param name="name">Name of the party.</param>
        /// <returns>Created party object.</returns>
        [HttpPut]
        [Route("create/{name}")]
        [ResponseType(typeof (Party.Model.Party))]
        public IHttpActionResult CreateParty(string name)
        {
            var createdParty = partyService.CreateParty(name);

            return Ok(createdParty);
        }
    }
}
