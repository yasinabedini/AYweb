using AYweb.Domain.Common.Repositories;

namespace AYweb.Domain.Models.Transaction.Repositories;

public interface ITransactionRepository : IRepository<Transaction.Entities.Transaction>
{
}
