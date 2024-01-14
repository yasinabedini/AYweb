using AYweb.Domain.Models.Transaction.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Transaction.Repositories
{
    public class TransactionRepository : BaseRepository<Domain.Models.Transaction.Entities.Transaction>, ITransactionRepository
    {
        public TransactionRepository(AyWebDbContext context) : base(context)
        {
        }
    }
}
