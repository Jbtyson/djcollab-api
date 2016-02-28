using System.Collections;
using System.Collections.Generic;
using DjCollab.User.Data;

namespace DjCollab.User
{
    public class UserService : IUserService
    {
        public IList<Model.User> GetAllUsers()
        {
            return FakeUserDb.GetAllUsers();
        }

        public Model.User GetUser(int userId)
        {
            return FakeUserDb.GetUser(userId);
        }

        public Model.User GetUser(string username)
        {
            return FakeUserDb.GetUser(username);
        }
    }
}
