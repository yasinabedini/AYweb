using AIPFramework.Queries;
using AYweb.Application.Models.Transaction.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Transaction.Queries.GetUnApprovedTransactions
{
    public class GetUnApprovedTransactionsQuery:PageQuery<PagedData<TransactionResult>>
    {
    }
}
