using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;
using AYweb.Domain.Models.Plan.Enums;
using AYweb.Domain.Models.Plan.ValueObjects;

namespace AYweb.Domain.Models.Plan.Entities;

public class Plan : AggregateRoot
{
    #region Properties
    public Title Title { get; private set; }

    public PlanType PlanType { get; private init; }

    public int Price { get; private set; }

    public bool IsDelete { get; private set; }

    //public List<PlanFeature> planFeatures { get;private set; }
    //public IReadOnlyList<User_Plans> User_Plans { get;private set; }
    #endregion

    #region Constructors And Factories
    private Plan() { }
    public Plan(string title, _PlanType planType, int price)
    {
        Title = new Title(title);
        PlanType = new PlanType(planType.ToString());
        Price = price;
       // planFeatures = new List<PlanFeature>();
        CreateAt = DateTime.Now;
    }
    public static Plan Create(string title, _PlanType planType, int price)
    {
        return new Plan(title, planType, price);
    }
    #endregion

    #region Command

    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public void ChangeTitle(string title)
    {
        Title = new Title(title);
        Modified();
    }

    public void ChangePrice(int price)
    {
        Price = price;
        Modified();
    }

    public void Update(string? title,int? price)
    {
        Title = new Title(title);
        Price = price.HasValue ? price.Value : Price;
        Modified();
    }

    public void Delete()
    {
        IsDelete = true;
        Modified();
    }

    //public void AddFeature(PlanFeature feature)
    //{
    //    planFeatures.Add(feature);
    //    Modified();
    //}

    //public bool CheckUser(int userId)
    //{
    //    return User_Plans.Any(t => t.User.Id == userId);
    //}

    #endregion
}