using AYweb.Domain.Models.User.Entities;
using AYweb.Domain.Models.User.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

    public void AddPlanToUser(User_Plans user_Plans)
    {
        _context.User_Plans.Add(user_Plans);
    }

    public void ChangeEmail(long userId, string email)
    {
        var user = GetById(userId);
        user.ChangeEmail(email);
        Update(user);
    }

    public void ChangeFirstName(long userId, string firstName)
    {
        var user = GetById(userId);
        user.ChangeFirstName(firstName);
        Update(user);
    }

    public void ChangeLastName(long userId, string lastName)
    {
        var user = GetById(userId);
        user.ChangeLastName(lastName);
        Update(user);
    }

    public void ChangePassword(long userId, string hassPassword)
    {
        var user = GetById(userId);
        user.ChangePassword(hassPassword);
        Update(user);
    }

    public void ChangePhoneNumber(long userId, string phoneNumber)
    {
        var user = GetById(userId);
        user.ChangePhoneNumber(phoneNumber);
        Update(user);
    }

    public void ConfirmEmail(long userId)
    {
        var user = GetById(userId);
        user.ConfirmEmail();
        Update(user);
    }

    public void ConfirmPhoneNumber(long userId)
    {
        var user = GetById(userId);
        user.ConfirmPhoneNumber();
        Update(user);
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

    public Domain.Models.Plan.Entities.Plan GetUserActivePlan(long userId)
    {
        return _context.User_Plans.Include(t=>t.Plan).Single(t => t.UserId == userId && t.ActivateCheck()).Plan;
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

    public void SetEmail(long userId, string setEmail)
    {
        var user = GetById(userId);
        user.SetEmail(setEmail);
        Update(user);
    }
}
