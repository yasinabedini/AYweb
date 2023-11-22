using AYweb.Dal.Entities.User;

namespace AYweb.Core.Services.Interfaces;

public interface IUserService
{
    User GetUserByUsername(string username);
}