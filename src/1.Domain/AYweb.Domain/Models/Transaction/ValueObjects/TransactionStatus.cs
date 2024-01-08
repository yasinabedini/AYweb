using AIPFramework.ValueObjects;
using AYweb.Domain.Common.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Transaction.ValueObjects;

public class TransactionStatus:BaseValueObject<TransactionStatus>
{               
        #region Properties
        public string Value { get; set; }
        #endregion

        #region Constructor
        public static TransactionStatus FromString(string value) => new TransactionStatus(value);
        public TransactionStatus(string value)
        {
            CheckRule(new TheValueMustNotBeEmpty(value));
            Value = value;
        }
        #endregion


        #region Equality Check
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        #endregion

        #region Operator Overloading
        public static explicit operator string(TransactionStatus title) => title.Value;
        public static implicit operator TransactionStatus(string value) => new(value);
        #endregion

        #region Methods
        public override string ToString() => Value;
        #endregion    
}
