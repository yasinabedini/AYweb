using AYweb.Core.Services.Interfaces;
using AYweb.Dal.Context;

namespace AYweb.Core.Services;

public class UserService:IUserService
{
    private readonly AYWebDbContext _context;

    public UserService(AYWebDbContext context)
    {
        _context = context;
    }
}