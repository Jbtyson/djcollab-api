using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace DjCollab.Api.Controllers
{
    [RoutePrefix("api/v1/error")]
    public class ErrorController : ApiController
    {
        public static IList<Exception> Errors = new List<Exception>();

        public ErrorController()
        {
        }

        /// <summary>
        /// Error log.
        /// </summary>
        /// <returns>List of errors since last server restart.</returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof (IList<string>))]
        public IHttpActionResult Get()
        {
            return Ok(Errors);
        }
    }
}
