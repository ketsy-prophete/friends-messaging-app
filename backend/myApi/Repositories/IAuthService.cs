using myApi.Models;

namespace myApi.Repositories;

public interface IAuthService
{
    User CreateUser(User user);

    string SignIn(string userName, string password);
}