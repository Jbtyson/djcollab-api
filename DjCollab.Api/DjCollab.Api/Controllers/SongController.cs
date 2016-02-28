using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using DjCollab.Song;
using DjCollab.Song.Model;

namespace DjCollab.Api.Controllers
{
    [RoutePrefix("api/v1/song")]
    public class SongController : ApiController
    {
        private readonly ISongService songService;

        public SongController()
        {
            songService = new SongService();
        }

        /// <summary>
        /// Gets all of the song counts available.
        /// </summary>
        /// <returns>List of SongCountInfo</returns>
        [HttpGet]
        [Route("count")]
        [ResponseType(typeof(IList<SongCountInfo>))]
        public IHttpActionResult GetCount()
        {
            return Ok(songService.GetSongCountInfo());
        }

        /// <summary>
        /// Gets top 'x' song counts.
        /// </summary>
        /// <param name="max">Maximum song counts to return</param>
        /// <returns>List of top 'x' SongCountInfo's</returns>
        [HttpGet]
        [Route("count/top/{max}")]
        [ResponseType(typeof(IList<SongCountInfo>))]
        public IHttpActionResult GetCount(string max)
        {
            return Ok(songService.GetTopSongCountInfo(int.Parse(max)));
        }
    }
}
