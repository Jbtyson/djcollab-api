using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Web.WebSockets;
using DjCollab.Host;
using DjCollab.Party;

namespace DjCollab.Api.Controllers
{
    [RoutePrefix("api/v1/host")]
    public class HostController : ApiController
    {
        private readonly IHostService hostService;
        private readonly IPartyService partyService;

        public HostController()
        {
            hostService = new HostService();
        }

        /// <summary>
        /// Establishes a websocket connection between a host and the server.
        /// </summary>
        /// <param name="partyId">Id of the party to begin hosting.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{partyId}")]
        public HttpResponseMessage Host(string partyId)
        {
            try
            {
                var id = int.Parse(partyId);
                HttpContext.Current.AcceptWebSocketRequest(new HostWebSocketHandler(id));
                //var handler = hostService.GetHostByPartyId(id);
                //partyService.GetParty(id).HostId = handler.HostId;
            }
            catch (FormatException e)
            {
                ErrorController.Errors.Add(e);
            }
            catch (Exception e)
            {
                ErrorController.Errors.Add(e);
            }
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
        }

        /// <summary>
        /// Registers a hostId to a partyId
        /// </summary>
        /// <param name="hostId">Id of the host.</param>
        /// <param name="partyId">Id of the party.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{hostId}/{partyId}")]
        public IHttpActionResult Register(string hostId, string partyId)
        {
            hostService.Register(int.Parse(hostId), int.Parse(partyId));
            partyService.GetParty(int.Parse(partyId)).HostId = int.Parse(hostId);
            return Ok();
        }

        /// <summary>
        /// Returns a list of hosts.
        /// </summary>
        /// <returns>A list of hosts.</returns>
        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetHosts()
        {
            return Ok(hostService.GetHosts());
        }
    }
}
