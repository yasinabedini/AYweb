using AIPFramework.Entities;
using AYweb.Domain.Common.Rules;
using AYweb.Domain.Models.User.Rules;

namespace AYweb.Domain.Models.User.ValueObjects;

public class FirstName : BaseValueObject<FirstName>
{
    #region Properties
    public string Value { get; private init; } 
    #endregion

    #region Constructors

    public static FirstName FromString(string value) => new FirstName(value);

    public FirstName(string value)
    {
        CheckRule(new TheValueMustNotBeEmpty(value));

        CheckRule(new StringLengthMostBebetween2And40(value));

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
    public static explicit operator string(FirstName title) => title.Value;
    public static implicit operator FirstName(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;
    #endregion
}
