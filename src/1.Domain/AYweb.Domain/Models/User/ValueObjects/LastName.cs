using AIPFramework.Entities;
using AYweb.Domain.Common.Rules;
using AYweb.Domain.Models.User.Rules;

namespace AYweb.Domain.Models.User.ValueObjects;

public class LastName : BaseValueObject<LastName>
{
    #region Properties
    public string Value { get; private init; }
    #endregion

    #region Constructors

    public static LastName FromString(string value) => new LastName(value);

    public LastName(string value)
    {
        CheckRule(new StringLengthMostBebetween2And40(value));

        CheckRule(new TheValueMustNotBeEmpty(value));
        Value = value;
    }

    private LastName() { }
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Operator Overloading
    public static explicit operator string(LastName title) => title.Value;
    public static implicit operator LastName(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;
    #endregion
}
