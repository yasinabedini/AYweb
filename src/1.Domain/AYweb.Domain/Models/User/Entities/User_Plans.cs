using AIPFramework.Entities;

namespace AYweb.Domain.Models.User.Entities;

public class User_Plans : Entity<long>
{
    #region Properties
    public long UserId { get; private set; }

    public long PlanId { get; private set; }

    public DateTime EndDate { get; private set; }

    public User User { get; private set; }

    public Plan.Entities.Plan Plan { get; private set; }

    public long TransactionId { get; private set; }

    public bool IsDelete { get; set; } 
    #endregion

    #region Constructors And Factories
    private User_Plans() { }
    public User_Plans(long userId, long planId, long transactionId)
    {
        UserId = userId;
        PlanId = planId;
        TransactionId = transactionId;
        CreateAt = DateTime.Now;
        EndDate = DateTime.Now.AddDays(30);
    }
    public static User_Plans Create(long userId, long planId, long transactionId)
    {
        return new User_Plans(userId, planId, transactionId);
    } 
    #endregion

    #region Command
    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public bool ActivateCheck()
    {
        if (EndDate >= DateTime.Now) return true;
        return false;
    }

    public void Delete()
    {
        IsDelete = true;
        Modified();
    } 
    #endregion

}