using AYweb.Domain.Common.ValueObjects;
using AYweb.Domain.Models.Transaction.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Transaction.Queries.Common
{
    public class TransactionResult
    {
        public long UserId { get;  set; }

        public int Price { get;  set; }

        public required string Status { get;  set; }

        public required string Type { get;  set; }

        public required string PaymentMethod { get;  set; }

        public required string TransactionScreenShot { get;  set; }

        public bool IsApproved { get;  set; }

        public required string Description { get;  set; }
    }
}
