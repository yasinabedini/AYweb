using AYweb.Core.Services.Interfaces;
using AYweb.Dal.Context;
using AYweb.Dal.Entities.Plan;
using Microsoft.EntityFrameworkCore;

namespace AYweb.Core.Services;

public class PlanService:IPlanService
{
    private readonly AYWebDbContext _context;

    public PlanService(AYWebDbContext context)
    {
        _context = context;
    }

    public void AddPlan(Plan plan)
    {
        _context.Plans.Add(plan);
        _context.SaveChanges();
    }

    public void UpdatePlan(Plan plan)
    {
        _context.Plans.Update(plan);
        _context.SaveChanges();
    }

    public List<Plan> GetAllPlans()
    {
        return _context.Plans.Include(t => t.PlanFeatures).ToList();
    }

    public Plan GetPlanById(int id)
    {
        return _context.Plans.Include(t=>t.PlanFeatures).First(t=>t.Id==id);
    }

    public void AddPlanToUser(int planId, int userId, TimeSpan validDays)
    {
        _context.User_Plans.Add(new UserPlans()
        {
            UserId = userId,
            PlanId = planId,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.Add(validDays)
        });
        _context.SaveChanges();
    }
}