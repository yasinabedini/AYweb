using AYweb.Domain.Common.Repositories;
using System.Transactions;

namespace AYweb.Domain.Models.Transaction.Repositories;

public interface ITransactionRepository : IRepository<Entities.Transaction>
{
    void ApproveTransaction(long transactionId);
    void RejectTransaction(long transactionId);
    List<Entities.Transaction> GetUnApprovedTransactions();
    void RequestForPayTransaction(long Id,int paymentMethod,string transactionScreenShot = "No Image");
    List<Entities.Transaction> GetTransactionByUserId(long userId);
    List<Entities.Transaction> GetUnApprovedTransaction();
    Transaction.Entities.Transaction GetByIdWithRelations(long id);

}
