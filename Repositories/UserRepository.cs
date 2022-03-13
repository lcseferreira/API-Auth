using APIAuth.Models;

namespace APIAuth.Repositories;

public static class UserRepository
{
    public static User Get(string username, string password)
    {
        var users = new List<User>
        {
        new User { Id = 1, Username = "lcsef", Password = "lcsef", Role = "manager"},
        new User { Id = 2, Username = "lmfdr", Password = "lmfdr", Role = "secretary"}
    };

        // return users
        // .Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password)
        // .FirstOrDefault();

        return users
            .FirstOrDefault(x =>
                string.Equals(x.Username, username, StringComparison.CurrentCultureIgnoreCase)
                && x.Password == password);
    }
}