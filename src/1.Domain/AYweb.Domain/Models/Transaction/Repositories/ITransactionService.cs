using AYweb.Domain.Common.Repositories;

namespace AYweb.Domain.Models.Transaction.Repositories;

public interface ITransactionService : IRepository<Transaction.Entities.Transaction>
{
}
