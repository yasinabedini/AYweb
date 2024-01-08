using AIPFramework.ValueObjects;
using AYweb.Domain.Common.Rules;
using AYweb.Domain.Models.User.Rules;

namespace AYweb.Domain.Models.User.ValueObjects;

public class VerificationCode : BaseValueObject<VerificationCode>
{
    #region Properties
    public string Value { get; private init; }
    #endregion

    #region Constructors

    public static VerificationCode FromString(string value) => new VerificationCode(value);

    public VerificationCode(string value)
    {
        CheckRule(new TheValueMustNotBeEmpty(value));
        CheckRule(new VerificationCodeIsValid(value));

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
    public static explicit operator string(VerificationCode title) => title.Value;
    public static implicit operator VerificationCode(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;
    #endregion
}
