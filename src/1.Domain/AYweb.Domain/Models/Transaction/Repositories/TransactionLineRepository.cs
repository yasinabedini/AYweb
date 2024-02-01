using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Transaction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Transaction.Repositories
{
    public interface ITransactionLineRepository:IRepository<TransactionLine>
    {
    }
}
