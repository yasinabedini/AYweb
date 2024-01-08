using AIPFramework.ValueObjects;
using AYweb.Domain.Common.Rules;
using AYweb.Domain.Models.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Order.ValueObjects
{
    public class OrderStatus : BaseValueObject<OrderStatus>
    {
        #region Properties
        public string Value { get; set; } 
        #endregion

        #region Constructor
        public static OrderStatus FromString(string value) => new OrderStatus(value);
        public OrderStatus(string value)
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
        public static explicit operator string(OrderStatus title) => title.Value;
        public static implicit operator OrderStatus(string value) => new(value);
        #endregion

        #region Methods
        public override string ToString() => Value;
        #endregion


    }
}
