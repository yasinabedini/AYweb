using AYweb.Core.DTOs;
using Zamin.Utilities.Services.DependentyInjection;
using AYweb.Dal.Entities.User;

namespace AYweb.Core.Services.Interfaces;

public interface IUserService
{
    bool IsUserExisting(string phoneNumber);

    User GetUserByUsername(string username);
    string UserRegister(SignUpViewModel user);
    User LoginUser(LoginViewModel user);
    void AddEmailToNewsLatters(string email);
    User GetUserByPhoneNumber(string phoneNumber);
    string GetVerificationCode(string phoneNumber);
    void ConfirmPhoneNumber(string phoneNumber);
    bool UpdateUser(User user);

    void CounselingUser(CounselingViewModel Counseling);
}