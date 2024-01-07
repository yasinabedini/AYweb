using AIPFramework.Entities;
using AYweb.Domain.Common.Rules;
using AYweb.Domain.Models.Blog.Rules;

namespace AYweb.Domain.Models.Blog.ValueObjects;
public class Title : BaseValueObject<Title>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static Title FromString(string value) => new Title(value);
    public Title(string value)
    {
        CheckRule(new TheValueMustNotBeEmpty(value));
        CheckRule(new TheTitleShouldNotBeMoreThan250(value));
     
        Value = value;
    }
    private Title()
    {

    }
    #endregion


    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Operator Overloading
    public static explicit operator string(Title title) => title.Value;
    public static implicit operator Title(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;

    #endregion
}
