using Capstone.Models;

namespace Capstone.DAO
{
    public interface IUserDao
    {
        User GetUser(string username);
        User AddUser(string username, string password, string role);
        UserInfo GetUserInfo(int user_id);
        bool UpdateUserInfo(UserInfo userInfo);
    }
}
