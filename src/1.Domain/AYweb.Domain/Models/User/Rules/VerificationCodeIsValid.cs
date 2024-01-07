using AIPFramework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.User.Rules;

public class VerificationCodeIsValid : IBusinessRule
{
    private readonly string _value;

    public VerificationCodeIsValid(string value)
    {
        _value = value;
    }

    public bool HasValidRule()
    {
        if(_value.Length==6) return true;
        return false;
    }

    public string Message => "Verification code Is not valid. ";
}
