using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Transaction.Entities;
using AYweb.Domain.Models.Transaction.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Transaction.Repositories
{
    public class TransactionRepository : BaseRepository<Domain.Models.Transaction.Entities.Transaction>, ITransactionRepository,ITransactionLineRepository
    {
        private readonly AyWebDbContext _context;
        public TransactionRepository(AyWebDbContext context) : base(context)
        {
            _context = context;
        }

        public void Add(TransactionLine entity)
        {
            _context.Add(entity);
        }

        public void ApproveTransaction(long transactionId)
        {
            var transaction = GetById(transactionId);
            transaction.ApproveTransaction();
            Update(transaction);
        }

        public Domain.Models.Transaction.Entities.Transaction GetByIdWithRelations(long id)
        {
            return _context.Transactions.Include(t => t.TransactionLines).Include(t=>t.User).First(t => t.Id == id);
        }

        public List<Domain.Models.Transaction.Entities.Transaction> GetListWithRelations()
        {
            return _context.Transactions.Include(t => t.User).ToList();
        }

        public List<Domain.Models.Transaction.Entities.Transaction> GetTransactionByUserId(long userId)
        {
            return _context.Transactions.Include(t=>t.TransactionLines).Where(t => t.UserId == userId).ToList();
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

        public void RequestForPayTransaction(long Id, int paymentMethod, string transactionScreenShot = "No Image")
        {
            var transaction = GetById(Id);
            transaction.RequestForPay(transactionScreenShot,paymentMethod);
            Update(transaction);
        }

        public void Update(TransactionLine entity)
        {
            _context.Update(entity);
        }

        TransactionLine IRepository<TransactionLine>.GetById(long id)
        {
            return _context.TransactionLines.First(t => t.Id == id);
        }

        List<TransactionLine> IRepository<TransactionLine>.GetList()
        {
            return _context.TransactionLines.ToList();
        }
    }
}
