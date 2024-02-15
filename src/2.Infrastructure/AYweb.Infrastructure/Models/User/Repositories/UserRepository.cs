using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Transaction.Enums;
using AYweb.Domain.Models.Transaction.Repositories;
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

public class UserRepository : BaseRepository<Domain.Models.User.Entities.User>, IUserRepository,ICounselingRepository
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly AyWebDbContext _context;
    private readonly IHttpContextAccessor _httpContext;

    public UserRepository(AyWebDbContext context, IHttpContextAccessor httpContext, ITransactionRepository transactionRepository) : base(context)
    {
        _context = context;
        _httpContext = httpContext;
        _transactionRepository = transactionRepository;
    }

    public Domain.Models.User.Entities.User GetByIdWithGraph(long id)
    {
        return _context.Users.Include(t => t.MyOrders).ThenInclude(t => t.OrderLines).ThenInclude(t => t.Product).Include(t => t.Transactions).Include(t => t.RolesList).FirstOrDefault(t => t.Id == id);
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

    public void ConfirmPhoneNumber(string phoneNumber)
    {
        var user = GetUSerByPhoneNumber(phoneNumber);
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
        var phoneNumber = claimsIdentity.Claims.First(t => t.Type == ClaimTypes.NameIdentifier).Value;

        return GetUSerByPhoneNumber(phoneNumber);
    }

    public Domain.Models.Plan.Entities.Plan GetUserActivePlan(long userId)
    {
        var userplans = _context.User_Plans.Include(t => t.Plan).OrderBy(t => t.Id).FirstOrDefault(t => t.UserId == userId);

        if (userplans is not null)
        {
            var transaction = _transactionRepository.GetById(userplans.TransactionId);

            if (transaction is not null)
            {
                if (userplans is not null && !userplans.ActivateCheck() || userplans is null || !transaction.IsAccepted())
                {
                    userplans = User_Plans.Create(userId, 4, 0);
                }
            }
        }
        else
        {
            userplans = User_Plans.Create(userId, 0, 0);
        }
        return userplans.Plan ?? Domain.Models.Plan.Entities.Plan.Create("کاربر عادی", "Normal", 0);
    }

    public Domain.Models.User.Entities.User GetUserByEmail(string email)
    {
        return GetList().First(t => t.Email == email);
    }

    public Domain.Models.User.Entities.User GetUserById(long id)
    {
        return GetList().FirstOrDefault(t => t.Id == id);
    }

    public Domain.Models.User.Entities.User GetUSerByPhoneNumber(string phoneNumber)
    {
        return _context.Users.Include(t => t.RolesList).Include(t => t.MyOrders).Include(t => t.Transactions).Include(t => t.Notifications).FirstOrDefault(t => t.PhoneNumber == new Domain.Common.ValueObjects.PhoneNumber(phoneNumber));
    }

    public string GetUserVerificationCode(string phoneNumber)
    {
        return GetList().First(t => t.PhoneNumber.Value == phoneNumber).GetVerificationCode();
    }

    public bool IsUserExisting(string phoneNumber)
    {
        return _context.Users.IgnoreQueryFilters().Any(t => t.PhoneNumber.Value == phoneNumber);
    }

    public Domain.Models.User.Entities.User Login(string phoneNumber, string password)
    {
        return GetList().SingleOrDefault(t => t.PhoneNumber.Value == phoneNumber && t.Password == password);
    }

    public void SetEmail(long userId, string setEmail)
    {
        var user = GetById(userId);
        user.SetEmail(setEmail);
        Update(user);
    }

    public void CallSuccess(long id)
    {
        var counseling = _context.Counselings.Find(id);
        counseling.CallSuccess();
        Update(counseling);
    }

    Counseling IRepository<Counseling>.GetById(long id)
    {
        return _context.Counselings.Find(id);
    }

    public void Add(Counseling entity)
    {
        _context.Add(entity);
    }

    List<Counseling> IRepository<Counseling>.GetList()
    {
        return _context.Counselings.ToList();
    }

    public void Update(Counseling entity)
    {
        _context.Update(entity);
    }

    public void AddRoleToUser(long roleId, long userId)
    {
        _context.Role_Users.Add(Domain.Models.Role.Entities.Role_Users.Create(roleId, userId));
    }

    public List<Domain.Models.Role.Entities.Role> GetUserRoles(long userId)
    {
        return _context.Users.Include(t => t.RolesList).ThenInclude(t => t.Role).FirstOrDefault(t => t.Id == userId).RolesList.Select(t => t.Role).ToList(); ;
    }

    public void DeleteAllUserRoles(long userId)
    {
        _context.Role_Users.RemoveRange(_context.Role_Users.Where(t => t.UserId == userId));
    }
}
