using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Transaction.Queries.Common
{
    public class TransactionLineResult
    {
        public required string Commodity { get;  set; }
        public required int Amount { get;  set; }
        public required int UnitPrice { get;  set; }
        public required int SumPrice { get;  set; }
    }
}
