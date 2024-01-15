using AIPFramework.Entities;
using AYweb.Domain.Models.User.ValueObjects;
using AYweb.Domain.Common.ValueObjects;
using AYweb.Domain.Models.Role.Entities;
using AYweb.Domain.Models.Notification.Entities;

namespace AYweb.Domain.Models.User.Entities;

public class User : AggregateRoot
{
    #region Properties
    public FirstName FirstName { get; private set; }

    public LastName LastName { get; private set; }

    public PhoneNumber PhoneNumber { get; private set; }

    public string? Email { get; private set; }

    public bool PhoneNumberConfrimation { get; private set; }

    public bool EmailConfrimation { get; private set; }

    public string Password { get; private set; }

    public VerificationCode VerificationCode { get; set; }

    public bool IsActive { get; private set; }

    public bool IsDelete { get; private set; }

    public List<UserNotification> Notifications { get; set; }

    public List<Role_Users> RolesList { get; private set; }

    #endregion

    #region Constructors And Factories
    private User()
    {
        CreateAt = DateTime.Now;
        IsActive = true;
        SetVerificationCode();
    }
    public User(string firstName, string lastName, string phoneNumber, string hashPassword)
    {
        FirstName = new FirstName(firstName);
        LastName = new LastName(lastName);
        PhoneNumber = new PhoneNumber(phoneNumber);

        SetVerificationCode();

        Password = hashPassword;
        CreateAt = DateTime.Now;
        IsActive = true;
    }

    public static User Create(string firstName, string lastName, string phoneNumber, string hashPassword)
    {
        return new User(firstName, lastName, phoneNumber, hashPassword);
    }
    #endregion

    #region Command

    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    private void SetVerificationCode()
    {
        Random random = new Random();
        VerificationCode = new VerificationCode(random.Next(111111, 999999).ToString());
    }

    public void ChangeFirstName(string firstName)
    {
        FirstName = new FirstName(firstName);
        Modified();
    }

    public void ChangeLastName(string lastName)
    {
        LastName = new LastName(lastName);
        Modified();
    }

    public void ChangePhoneNumber(string phoneNumber)
    {
        PhoneNumber = new PhoneNumber(phoneNumber);
        PhoneNumberConfrimation = false;
        Modified();
    }

    public void ChangePassword(string hashPassword)
    {
        Password = hashPassword;
        Modified();
    }

    public void SetEmail(string email)
    {
        Email = email;
        Modified();
    }

    public void ChangeEmail(string email)
    {
        Email = email;
        Modified();
    }

    public void ConfirmEmail()
    {
        EmailConfrimation = true;
        Modified();
    }

    public void ConfirmPhoneNumber()
    {
        PhoneNumberConfrimation = true;
        Modified();
    }

    private void ChangeVerificationCode()
    {
        Random random = new Random();
        VerificationCode = new VerificationCode(random.Next(111111, 999999).ToString());
        Modified();
    }

    public string GetVerificationCode()
    {
        string previousCode = VerificationCode.ToString();
        ChangeVerificationCode();
        return previousCode;
    }

    public void UpdateUser(string? firstName, string? lastName, string? phoneNumber)
    {
        if (!string.IsNullOrEmpty(firstName))
        {
            ChangeFirstName(firstName);
        }

        if (!string.IsNullOrEmpty(lastName))
        {
            ChangeLastName(lastName);
        }

        if (!string.IsNullOrEmpty(phoneNumber))
        {
            ChangePhoneNumber(phoneNumber);
        }
    }

    public void AddUserRole(Role.Entities.Role role)
    {
        RolesList.Add(Role_Users.Create((int)role.Id, (int)Id));
    }

    public void AddNotification(int notificationId)
    {
        Notifications.Add(UserNotification.Create(notificationId, (int)Id));
    }

    public void DeleteUser()
    {
        IsDelete = true;
        Modified();
    }
    #endregion
}
