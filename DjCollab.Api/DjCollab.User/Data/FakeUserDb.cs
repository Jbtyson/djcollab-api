using System.Collections.Generic;
using System.Linq;

namespace DjCollab.User.Data
{
    public static class FakeUserDb
    {
        private static readonly Dictionary<int, Model.User> users = new Dictionary<int, Model.User>();

        public static IList<Model.User> GetAllUsers()
        {
            return users.Values.ToList();
        } 

        public static Model.User GetUser(int userId)
        {
            return users[userId];
        }

        public static Model.User GetUser(string username)
        {
            return users.Values.Where(u => u.Username == username).ToList()[0];
        }

        public static void Reset()
        {
            users.Clear();
        }
    }
}
