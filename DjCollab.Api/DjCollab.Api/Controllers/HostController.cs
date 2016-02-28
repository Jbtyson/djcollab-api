using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Web.WebSockets;
using DjCollab.Host;

namespace DjCollab.Api.Controllers
{
    [RoutePrefix("api/v1/host")]
    public class HostController : ApiController
    {
        private readonly IHostService hostService;

        public HostController()
        {
            hostService = new HostService();
        }

        /// <summary>
        /// Establishes a websocket connection between a host and the server.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Host()
        {
            HttpContext.Current.AcceptWebSocketRequest(new HostWebSocketHandler());
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
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
