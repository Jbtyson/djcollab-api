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
    [RoutePrefix("v1/host")]
    public class HostController : ApiController
    {
        private readonly IHostService hostService;

        public HostController()
        {
            hostService = new HostService();
        }

        [HttpGet]
        [Route("{userId}")]
        public IHttpActionResult Get(string userId)
        {
            HttpContext.Current.AcceptWebSocketRequest(new HostWebSocketHandler(int.Parse(userId)));
            return Ok(HttpStatusCode.SwitchingProtocols);
        }
    }
}
