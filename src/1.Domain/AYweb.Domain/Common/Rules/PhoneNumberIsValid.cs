using AIPFramework.Exceptions;
using System.Text.RegularExpressions;

namespace AYweb.Domain.Common.Rules;

public class PhoneNumberIsValid : IBusinessRule
{
    private readonly string _value;
    public PhoneNumberIsValid(string value)
    {
        _value = value;
    }
    public bool HasValidRule()
    {
        if (Regex.IsMatch(_value, @"^(00989|\+989|09)(\d{9})$")) return true;
        return false;
    }
    public string Message => $"the phoneNumber value is not valid. ";

}
