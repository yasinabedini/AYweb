using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Dal.Entities.Transaction
{
    public class PaymentMethod
    {
        public string Method { get; set; }

        public PaymentMethod(string method)
        {
            Method = method;
        }
    }
}
