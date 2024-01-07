using AIPFramework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Common.Rules;

public class TheDescriptionShouldNotBeMoreThan500 : IBusinessRule
{
    public string value { get; set; }

    public TheDescriptionShouldNotBeMoreThan500(string value)
    {
        this.value = value;
    }

    public bool HasValidRule()
    {
        if (value.Length <= 500) return true;
        return false;
    }
    public string Message => "The description should not be more than 500. ";
}
