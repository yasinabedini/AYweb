using AYweb.Core.Generators;
using AYweb.Core.Services.Interfaces;
using AYweb.Core.Tools;
using AYweb.Dal.Context;
using AYweb.Dal.Entities.Plan;
using AYweb.Dal.Entities.Transaction;
using AYweb.Dal.Entities.User;
using AYweb.Dal.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AYweb.Core.Services;

public class PlanService : IPlanService
{
    private readonly AYWebDbContext _context;
    private IPermissionService _permissionService;
    private readonly ITransactionService _transactionService;

    public PlanService(AYWebDbContext context, IPermissionService permissionService, ITransactionService transactionService)
    {
        _context = context;
        _permissionService = permissionService;
        _transactionService = transactionService;
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
        return _context.Plans.Include(t => t.PlanFeatures).First(t => t.Id == id);
    }

    public Plan GetAuthonticatedUserPlan(HttpContext context)
    {
        User user = _permissionService.GetAuthonticatedUser(context);
        var userPlans = _context.User_Plans;

        var userPlan = userPlans.FirstOrDefault(t => t.UserId == user.UserId && t.EndDate > DateTime.Now);

        if (userPlan != null)
        {
            Transaction transaction = _transactionService.GetTransactionById(userPlan.TransactionId);
            if (transaction.IsApproved == true)
            {
                return userPlan.Plan;
            }
        }
        return GetNormalPlan();
    }

    public Plan GetNormalPlan()
    {
        return new Plan() { Price = 0, Title = "پنل عادی", PlanType = PlanType.Normal };
    }

    public void AddPlanToUser(int userId, Plan plan, IFormFile? transactionScreen)
    {
        string fileName = "";
        if (transactionScreen != null)
        {
            fileName = Generator.CreateUniqueText(15) + Path.GetDirectoryName(transactionScreen.FileName);
            FileTools file = new FileTools();
            file.SaveImage(transactionScreen, fileName, "Transaction-ScreenShots", false);
        }

        Transaction transaction = Transaction.Create(plan.Price, userId, _TransactionType.PaymentPlan, $"Payment Plan for user by user Id : ({userId})", fileName);
        _transactionService.AddTransaction(transaction);

        UserPlans userPlans = new UserPlans()
        {
            PlanId = plan.Id,
            UserId = userId,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(1),
            TransactionId = transaction.Id,
        };
        _context.User_Plans.Add(userPlans);
        _context.SaveChanges();
    }


}