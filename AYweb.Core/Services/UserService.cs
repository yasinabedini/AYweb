using AYweb.Core.Services.Interfaces;
using AYweb.Dal.Context;
using AYweb.Dal.Entities.User;

namespace AYweb.Core.Services;

public class UserService:IUserService
{
    private readonly AYWebDbContext _context;

    public UserService(AYWebDbContext context)
    {
        _context = context;
    }

    public User GetUserByUsername(string username)
    {
        return _context.Users.First(t => t.Username == username);
    }
}