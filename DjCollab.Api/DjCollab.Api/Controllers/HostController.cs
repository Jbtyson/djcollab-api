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
        /// <param name="userId">Id of the user attempting to establish the connection.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IHttpActionResult Host()
        {
            HttpContext.Current.AcceptWebSocketRequest(new HostWebSocketHandler());
            return Ok();
        }
    }
}
