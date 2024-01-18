using AIPFramework.Exceptions;
using AIPFramework.ValueObjects;
using AYweb.Domain.Common.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Common.ValueObjects;

public class Description : BaseValueObject<Description>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static Description FromString(string value) => new(value);
    public Description(string value)
    {
        CheckRule(new TheValueMustNotBeEmpty(value));
        CheckRule(new TheDescriptionShouldNotBeMoreThan500(value));

        Value = value;
    }
    private Description() { }
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Operator Overloading
    public static explicit operator string(Description description) => description.Value;

    public static implicit operator Description(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;
    #endregion
}
