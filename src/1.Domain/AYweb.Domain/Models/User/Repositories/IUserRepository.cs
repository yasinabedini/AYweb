using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Blog.Entities;
using AYweb.Domain.Models.Plan.Entities;
using AYweb.Domain.Models.User.Entities;

namespace AYweb.Domain.Models.User.Repositories;

public interface IUserRepository : IRepository<User.Entities.User>
{
    User.Entities.User GetUSerByPhoneNumber(string phoneNumber);
    Entities.User GetUserById(long id);
    User.Entities.User GetUserByEmail(string email);
    User.Entities.User GetUSerByUsername(string username);
    User.Entities.User GetAuthenticatedUser();

    #region Plan
    void AddPlanToUser(User_Plans user_Plans);
    Plan.Entities.Plan GetUserActivePlan(long userId);
    #endregion

}
