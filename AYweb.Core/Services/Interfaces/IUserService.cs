using AYweb.Core.DTOs;
using AYweb.Dal.Entities.User;

namespace AYweb.Core.Services.Interfaces;

public interface IUserService
{
    bool IsUserExisting(string phoneNumber);

    User GetUserByUsername(string username);
    string UserRegister(SignUpViewModel user);
    User LoginUser(LoginViewModel user);
}