﻿using AIPFramework.Exceptions;
using AYweb.Domain.Models.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.User.Rules
{
    public class StringLengthMostBebetween2And40 : IBusinessRule
    {
        private readonly string _value;
        public StringLengthMostBebetween2And40(string value)
        {
            _value = value;
        }
        public bool HasValidRule()
        {
            if (_value.Length < 2 || _value.Length > 40) return false;
            return true;
        }
        public string Message => $"The value of {_value} must not be null or empty. ";
    }
}
