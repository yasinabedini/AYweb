using AYweb.Core.DTOs;
using AYweb.Core.Generators;
using AYweb.Core.Security;
using AYweb.Core.Senders;
using AYweb.Core.Services.Interfaces;
using AYweb.Dal.Context;
using Zamin.Utilities.Services.DependentyInjection;
using AYweb.Dal.Entities.User;

namespace AYweb.Core.Services;

public class UserService : IUserService
{
    private readonly AYWebDbContext _context;

    public UserService(AYWebDbContext context)
    {
        _context = context;
    }

    public bool IsUserExisting(string phoneNumber)
    {
        return _context.Users.Any(t => t.PhoneNumber == phoneNumber || t.PhoneNumber.Contains(phoneNumber));
    }

    public User GetUserByUsername(string username)
    {
        return _context.Users.First(t => t.Username == username);
    }

    public string UserRegister(SignUpViewModel user)
    {
        var newUser = new User()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Password = Security.PasswordHelper.EncodePasswordMd5(user.Password),
            PhoneNumber = user.PhoneNumber,
            ActivationCode = Generator.CreateUniqueText(12),
            Username = Generator.CreateUniqueText(7),
            VerificationCode = Generator.CreateVerificationCode(),
            RegisterDate = DateTime.Now,
        };
        _context.Users.Add(newUser);
        _context.SaveChanges();
        return newUser.VerificationCode;
    }

    public User LoginUser(LoginViewModel user)
    {
        string hashPass = PasswordHelper.EncodePasswordMd5(user.Password);
        var userFound = _context.Users.SingleOrDefault(t=>t.PhoneNumber==user.PhoneNumber&&t.Password==hashPass);
        return userFound;
    }

    public void AddEmailToNewsLatters(string email)
    {
        if (!_context.Newsletters.Any(t=>t.Email==email))
        {
            _context.Newsletters.Add(new Newsletters()
            {
                Email = email
            });
            _context.SaveChanges();
        }
    }

    public User GetUserByPhoneNumber(string phoneNumber)
    {
        return _context.Users.First(t => t.PhoneNumber == phoneNumber);
    }

    public string GetVerificationCode(string phoneNumber)
    {
        User user = _context.Users.First(t => t.PhoneNumber == phoneNumber);
        string verificationCode = user.VerificationCode;
        user.VerificationCode = Generator.CreateVerificationCode();
        UpdateUser(user);
        return verificationCode;
    }

    public void ConfirmPhoneNumber(string phoneNumber)
    {
        User user = _context.Users.First(t => t.PhoneNumber == phoneNumber);
        user.PhoneNumberConfrimation = true;
        UpdateUser(user);
    }

    public bool UpdateUser(User user)
    {
        _context.Update(user);
        var result = _context.SaveChanges();
        return result == 1;
    }

    public void CounselingUser(CounselingViewModel Counseling)
    {
        _context.Counselings.Add(new Counseling
        {
            PhoneNumber = Counseling.PhoneNumber,
            Message = Counseling.Message,
            UserName = Counseling.UserName,
            Title = Counseling.Title,
            IsCall = false
        });
        _context.SaveChanges();

        Sms.CounselingRequest(Counseling.PhoneNumber, Counseling.UserName);
    }
}