using AIPFramework.ValueObjects;
using AYweb.Domain.Common.Rules;

namespace AYweb.Domain.Models.Transaction.ValueObjects;

public class PaymentMethod : BaseValueObject<PaymentMethod>
{
    #region Properties
    public string Value { get; set; }
    #endregion

    #region Constructor
    public static PaymentMethod FromString(string value) => new PaymentMethod(value);
    public PaymentMethod(string value)
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
    public static explicit operator string(PaymentMethod title) => title.Value;
    public static implicit operator PaymentMethod(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;
    #endregion
}