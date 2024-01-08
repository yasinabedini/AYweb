using AIPFramework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPFramework.ValueObjects.Rule
{
    public class TheValueMustNotBeEmpty : IBusinessRule
    {
        private readonly string _value;

        public TheValueMustNotBeEmpty(string value)
        {
            _value = value;
        }

        public bool HasValidRule()
        {
            if (string.IsNullOrWhiteSpace(_value)) return false;
            return true;
        }


        public string Message => "The Value Must Not Be Empty. ";
    }
}
