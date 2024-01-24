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
        private readonly AyWebDbContext _context;
        public TransactionRepository(AyWebDbContext context) : base(context)
        {
            _context = context;
        }

        public void ApproveTransaction(long transactionId)
        {
            var transaction = GetById(transactionId);
            transaction.ApproveTransaction();
            Update(transaction);
        }

        public List<Domain.Models.Transaction.Entities.Transaction> GetTransactionByUserId(long userId)
        {
            return GetList().Where(t => t.UserId == userId).ToList();
        }

        public List<Domain.Models.Transaction.Entities.Transaction> GetUnApprovedTransaction()
        {
            return _context.Transactions.Where(t => !t.IsAccepted()).ToList();
        }

        public List<Domain.Models.Transaction.Entities.Transaction> GetUnApprovedTransactions()
        {
            return _context.Transactions.Where(t => !t.IsAccepted()).ToList();
        }

        public void RejectTransaction(long transactionId)
        {
            var transaction = GetById(transactionId);
            transaction.RejectTransaction();
            Update(transaction);
        }

        public void RequestForPayTransaction(long Id, string transactionScreenShot = "No Image")
        {
            var transaction = GetById(Id);
            transaction.RequestForPay(transactionScreenShot);
            Update(transaction);
        }
    }
}
