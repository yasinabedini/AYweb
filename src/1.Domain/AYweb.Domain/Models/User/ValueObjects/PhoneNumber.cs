using AIPFramework.Entities;
using AYweb.Domain.Common.Rules;
using AYweb.Domain.Models.User.Rules;

namespace AYweb.Domain.Models.User.ValueObjects;

public class PhoneNumber : BaseValueObject<PhoneNumber>
{
    #region Properties
    public string Value { get; private init; }
    #endregion

    #region Constructors

    public static PhoneNumber FromString(string value) => new PhoneNumber(value);

    public PhoneNumber(string value)
    {
        CheckRule(new TheValueMustNotBeEmpty(value));

        CheckRule(new PhoneNumberIsValid(value));

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
    public static explicit operator string(PhoneNumber title) => title.Value;
    public static implicit operator PhoneNumber(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;
    #endregion
}
