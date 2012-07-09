using System.Linq;
using FoodOrder.Model;

namespace FoodOrder.Helper
{
    internal static class UserManager
    {
        private static FoodOrderDatabaseEntities _database;

        private static string _username;

        public static void SetDatabaseContext(FoodOrderDatabaseEntities database)
        {
            _database = database;
        }

        public static void SetCookie(User user)
        {
            if (user == null) return;
            _username = user.username;
            PageManager.SetContent(PageManager.View.Home);
        }

        public static void RemoveCookie()
        {
            _username = null;
            PageManager.SetContent(PageManager.View.Login, true);
        }

        public static bool IsLoggedIn()
        {
            return _username != null &&
                   _database.Users.SingleOrDefault(t => t.username == _username) != null;
        }

        public static User GetUser()
        {
            return _database.Users.SingleOrDefault(t => t.username == _username);
        }
    }
}