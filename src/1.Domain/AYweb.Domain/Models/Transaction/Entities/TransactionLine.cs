using AIPFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Transaction.Entities
{
    public class TransactionLine : Entity
    {
        public long TransactionId { get;private set; }
        public string Commodity { get;private set; }
        public int Amount { get; private set; }
        public int UnitPrice { get; private set; }
        public int SumPrice { get; private set; }
        public Transaction Transaction { get; private set; }

        private TransactionLine() { CreateAt = DateTime.Now; }

        public TransactionLine(long transactionId,string commodity, int amount, int unitPrice)
        {
            TransactionId = transactionId;
            Commodity = commodity;
            Amount = amount;
            UnitPrice = unitPrice;
            SumPrice = unitPrice * amount;
            CreateAt = DateTime.Now;            
        }
        public static TransactionLine Create(long transactionId, string commodity, int amount, int unitPrice)
        {
            return new TransactionLine(transactionId, commodity, amount, unitPrice);
        }

        #region Common

        private void Modified()
        {
            ModifiedAt = DateTime.Now;
        }

        public int CalculateSumPrice()
        {
            return Amount* UnitPrice;
        }

        public void SetSumPrice()
        {
            SumPrice = CalculateSumPrice();
            Modified();
        }

        public void ChangeCommodity(string commodity)
        {
            Commodity = commodity;
            Modified();
        }

        public void ChangeAmount(int amount)
        {
            Amount = amount;
            Modified();
        }

        public void ChnageUnitPrice(int price)
        {
            UnitPrice = price;
            Modified();
        }

        public void Delete()
        {
            IsDelete = true;
            Modified();
        }

        #endregion

    }
}
