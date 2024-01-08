using AIPFramework.ValueObjects;
using AYweb.Domain.Common.Rules;

namespace AYweb.Domain.Models.Plan.ValueObjects;

public class PlanFeature : BaseValueObject<PlanFeature>
{
    #region Properties
    public string Value { get; private init; }
    #endregion

    #region Constructors

    public static PlanFeature FromString(string value) => new PlanFeature(value);

    public PlanFeature(string value)
    {
        CheckRule(new TheValueMustNotBeEmpty(value));
        Value = value;
    }
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Operator Overloading
    public static explicit operator string(PlanFeature title) => title.Value;
    public static implicit operator PlanFeature(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;
    #endregion
}