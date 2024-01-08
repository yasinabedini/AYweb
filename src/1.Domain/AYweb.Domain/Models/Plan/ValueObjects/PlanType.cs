using AIPFramework.ValueObjects;
using AYweb.Domain.Common.Rules;
using AYweb.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Plan.ValueObjects;

public class PlanType : BaseValueObject<PlanType>
{
    #region Properties
    public string Value { get; private init; }
    #endregion

    #region Constructors

    public static PlanType FromString(string value) => new PlanType(value);

    public PlanType(string value)
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
    public static explicit operator string(PlanType title) => title.Value;
    public static implicit operator PlanType(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;
    #endregion
}
