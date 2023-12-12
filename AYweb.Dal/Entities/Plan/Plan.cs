namespace AYweb.Dal.Entities.Plan;

public class Plan
{
    public int Id { get; set; }
    public string Title { get; set; }
    public PlanType PlanType { get; set; }
    public List<PlanFeature> PlanFeatures { get; set; }
    public int Price { get; set; }
}