using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Dal.Entities.Transaction
{
    public class TransactionStatus
    {
        public string Status { get; set; }

        public TransactionStatus(string status)
        {
            Status = status;
        }
    }
}
