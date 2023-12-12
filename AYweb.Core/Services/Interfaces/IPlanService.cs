using AYweb.Dal.Entities.Plan;

namespace AYweb.Core.Services.Interfaces;

public interface IPlanService
{
    void AddPlan(Plan plan);
    void UpdatePlan(Plan plan);
    List<Plan> GetAllPlans();
    Plan GetPlanById(int id);
    void AddPlanToUser(int planId, int userId, TimeSpan validDays);
}