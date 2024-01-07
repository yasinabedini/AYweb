using AIPFramework.Exceptions;

namespace AYweb.Domain.Models.Blog.Rules;

public class TheTitleShouldNotBeMoreThan250 : IBusinessRule
{
    public string Value { get; set; }

    public TheTitleShouldNotBeMoreThan250(string value)
    {
        Value = value;
    }

    public bool HasValidRule()
    {
        if (Value.Length <= 250) return true;
        return false;
    }

    public string Message => "The Title Should Not Be More Than 250. ";
}
