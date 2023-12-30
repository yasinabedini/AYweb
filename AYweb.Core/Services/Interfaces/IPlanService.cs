using AYweb.Dal.Entities.Plan;
using Microsoft.AspNetCore.Http;

namespace AYweb.Core.Services.Interfaces;

public interface IPlanService
{
    void AddPlan(Plan plan);
    void UpdatePlan(Plan plan);
    List<Plan> GetAllPlans();
    Plan GetPlanById(int id);    
    Plan GetAuthonticatedUserPlan(HttpContext context);
    Plan GetNormalPlan();    
    void AddPlanToUser(int userId, Plan plan, IFormFile? transactionScreen);
}