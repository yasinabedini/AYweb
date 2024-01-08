using AIPFramework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPFramework.ValueObjects.Rule;

public class BussinesIdIsValid : IBusinessRule
{
    public string value { get; set; }

    public BussinesIdIsValid(string value)
    {
        this.value = value;
    }


    public bool HasValidRule()
    {
        if (Guid.TryParse(value, out Guid tempValue)) return true;
        return false;
    }
    public string Message => "The Bussines Id Is Not Valid. ";
}
