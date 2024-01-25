using AIPFramework.Entities;
using AIPFramework.ValueObjects;
using AYweb.Domain.Common.Rules;

namespace AYweb.Domain.Models.Plan.ValueObjects;

public class PlanFeature : Entity
{
    #region Properties
    public string Value { get; private init; }
    public List<Plan.Entities.Plan> Plans { get; set; }
    #endregion

    #region Constructors

    public static PlanFeature FromString(string value) => new PlanFeature(value);

    private PlanFeature() { }
    public PlanFeature(string value)
    {        
        Value = value;
    }
    #endregion            
}