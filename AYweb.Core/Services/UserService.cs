using AYweb.Core.DTOs;
using AYweb.Core.Generators;
using AYweb.Core.Security;
using AYweb.Core.Services.Interfaces;
using AYweb.Dal.Context;
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
}