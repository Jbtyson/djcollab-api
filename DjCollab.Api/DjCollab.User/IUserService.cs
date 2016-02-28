using System.Collections;
using System.Collections.Generic;

namespace DjCollab.User
{
    public interface IUserService
    {
        IList<Model.User> GetAllUsers();
        Model.User GetUser(int userId);
        Model.User GetUser(string username);
    }
}
