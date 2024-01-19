using AYweb.Domain.Models.User.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.User.Repositories;

public class UserRepository : BaseRepository<Domain.Models.User.Entities.User>, IUserRepository
{
    private readonly AyWebDbContext _context;
    private readonly IHttpContextAccessor _httpContext;

    public UserRepository(AyWebDbContext context, IHttpContextAccessor httpContext) : base(context)
    {
        _context = context;
        _httpContext = httpContext;
    }

    public Domain.Models.User.Entities.User GetAuthenticatedUser()
    {
        if (!_httpContext.HttpContext.User.Identity.IsAuthenticated)
        {
            throw new Exception("User Is Not Authenticated");
        }
        
        var claimsIdentity = _httpContext.HttpContext.User.Identity as ClaimsIdentity;
        var username = claimsIdentity.Claims.First(t => t.Type == ClaimTypes.NameIdentifier).Value;

        return GetUSerByUsername(username);
    }

    public Domain.Models.User.Entities.User GetUserByEmail(string email)
    {
        return _context.Users.First(t => t.Email == email);
    }

    public Domain.Models.User.Entities.User GetUserById(long id)
    {
        return _context.Users.Find(id);
    }

    public Domain.Models.User.Entities.User GetUSerByPhoneNumber(string phoneNumber)
    {
        return _context.Users.First(t => t.PhoneNumber.Value == phoneNumber);
    }

    public Domain.Models.User.Entities.User GetUSerByUsername(string username)
    {
        throw new NotImplementedException();
    }
}
