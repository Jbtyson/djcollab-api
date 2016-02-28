using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DjCollab.User;
using Microsoft.AspNet.Identity;

namespace DjCollab.Api.Controllers
{
    [RoutePrefix("api/v1/user")]
    public class UserController : ApiController
    {
        private readonly IUserService userService; 

        public UserController()
        {
            userService = new UserService();
        }

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Gets a list of all users.
        /// </summary>
        /// <returns>List of all users</returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IList<User.Model.User>))]
        public IHttpActionResult GetAllUsers()
        {
            var users = userService.GetAllUsers();
            return Ok(users);
        }

        /// <summary>
        /// Gets a user based on the passed in id.
        /// </summary>
        /// <param name="userId">Id of the user to return.</param>
        /// <returns>The user matching the passed in id.</returns>
        [HttpGet]
        [Route("id/{userId}")]
        [ResponseType(typeof(IList<User.Model.User>))]
        public IHttpActionResult GetUser(string userId)
        {
            var user = userService.GetUser(int.Parse(userId));
            return Ok(user);
        }

        /// <summary>
        /// Searches for a user based on a username.
        /// </summary>
        /// <param name="username">Username to search by.</param>
        /// <returns>User found by given username.</returns>
        [HttpGet]
        [Route("username/{username}")]
        [ResponseType(typeof(IList<User.Model.User>))]
        public IHttpActionResult SearchUsername(string username)
        {
            var user = userService.GetUser(username);
            return Ok(user);
        }
    }
}
