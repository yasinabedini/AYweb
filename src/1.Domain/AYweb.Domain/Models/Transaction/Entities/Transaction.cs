
using AIPFramework.Entities;
using AYweb.Domain.Models.Transaction.ValueObjects;
using AYweb.Domain.Models.Transaction.Enums;
using AIPFramework.Exceptions;
using AYweb.Domain.Common.ValueObjects;

namespace AYweb.Domain.Models.Transaction.Entities;

public class Transaction : AggregateRoot
{
    #region Properties
    public long UserId { get; private set; }

    public int Price { get; private set; }

    public TransactionStatus Status { get; private set; }

    public TransactionType Type { get; private set; }

    public PaymentMethod PaymentMethod { get; private set; }

    public string TransactionScreenShot { get; private set; }

    public bool IsApproved { get; private set; }

    public Description Description { get; private set; }

    public User.Entities.User User { get; private set; }

    public List<TransactionLine> TransactionLines { get; set; }
    #endregion

    #region Constructor And Factories
    private Transaction() { }
    public Transaction(long userId, int price, _TransactionType transactionType, _PaymentMethod paymentMethod, string description, string transactionScreenShot = "No Image")
    {
        UserId = userId;
        Price = price;
        Type = new TransactionType(transactionType.ToString());
        Status = new TransactionStatus(_TransactionStatus.AwaitingPayment.ToString());
        PaymentMethod = new PaymentMethod(paymentMethod.ToString());
        Description = description;
        if (paymentMethod == _PaymentMethod.CardByCard && transactionScreenShot == "No Image")
        {
            throw new InvalidEntityStateException("If Payment Method Is Card by Card, Transaction Image Most be have value. ");
        }
        TransactionScreenShot = transactionScreenShot;
    }
    public static Transaction Create(long userId, int price, _TransactionType transactionType, _PaymentMethod paymentMethod, string description, string transactionScreenShot = "No Image")
    {
        return new Transaction(userId, price, transactionType, paymentMethod, description, transactionScreenShot);
    }
    #endregion

    #region Common

    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public void PaymentRegistration()
    {
        Status = new TransactionStatus(_TransactionStatus.AwaitingApproval.ToString());
        Modified();
    }

    public void ApproveTransaction()
    {
        Status = new TransactionStatus(_TransactionStatus.Approved.ToString());
        IsApproved = true;
        Modified();
    }

    public void RejectTransaction()
    {
        Status = new TransactionStatus(_TransactionStatus.Failed.ToString());
        IsApproved = false;        
        Modified();
    }

    void ChangeScreenShot(string screenShot)
    {
        TransactionScreenShot = screenShot;
        Modified();
    }

    public void RequestForPay(string screenShot)
    {
        Status = _TransactionStatus.AwaitingApproval.ToString();
        ChangeScreenShot(screenShot); 
        Modified();
    }

    public bool IsAccepted()
    {
        if (IsApproved && Status.Value == _TransactionStatus.Approved.ToString()) return true;
        else return false;
    }
    #endregion
}
