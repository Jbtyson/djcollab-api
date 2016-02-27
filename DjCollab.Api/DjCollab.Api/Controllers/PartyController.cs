using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using DjCollab.Party;

namespace DjCollab.Api.Controllers
{
    [RoutePrefix("v1/party")]
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

        [HttpPut]
        [Route("{partyId}/{songId}")]
        [ResponseType(typeof (Party.Model.Party))]
        public IHttpActionResult AddSongToParty(string partyId, string songId)
        {
            var party = partyService.AddSongToParty(int.Parse(partyId), int.Parse(songId));

            return Ok(party);
        }

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
