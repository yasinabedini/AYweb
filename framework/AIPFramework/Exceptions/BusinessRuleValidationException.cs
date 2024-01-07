namespace AIPFramework.Exceptions;

public class BusinessRuleValidationException : Exception
{
    public BusinessRuleValidationException(IBusinessRule brokenRule) : base(brokenRule.Message)
    {

    }
}