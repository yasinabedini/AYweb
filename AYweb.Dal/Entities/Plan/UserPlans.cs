namespace AYweb.Dal.Entities.Plan;

public class UserPlans
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PlanId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public User.User User { get; set; }
    public Plan Plan { get; set; }
}