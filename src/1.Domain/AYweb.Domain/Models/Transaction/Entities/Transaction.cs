
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

    public TransactionType? Type { get; private set; }

    public PaymentMethod? PaymentMethod { get; private set; }

    public string? TransactionScreenShot { get; private set; }

    public bool IsApproved { get; private set; }

    public Description Description { get; private set; }

    public User.Entities.User User { get; private set; }

    public List<TransactionLine> TransactionLines { get; set; }
    #endregion

    #region Constructor And Factories
    private Transaction() { CreateAt = DateTime.Now; }
    public Transaction(long userId, int price, _TransactionType type, string description)
    {
        UserId = userId;
        Price = price;
        Status = new TransactionStatus(_TransactionStatus.AwaitingPayment.ToString());
        Type = type.ToString();
        Description = description;
        CreateAt = DateTime.Now;
    }
    public static Transaction Create(long userId, int price, _TransactionType type, string description)
    {
        return new Transaction(userId, price, type, description);
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

    public void RequestForPay(string screenShot, int paymentMethod)
    {
        if (paymentMethod == (int)_PaymentMethod.CardByCard)
        {
            Status = _TransactionStatus.AwaitingApproval.ToString();
            ChangeScreenShot(screenShot);
            PaymentMethod = _PaymentMethod.CardByCard.ToString();
        }


        else if (paymentMethod == (int)_PaymentMethod.PaymentGateway)
        {
            Status = _TransactionStatus.Approved.ToString();
            ChangeScreenShot("No Image");
            PaymentMethod = _PaymentMethod.CardByCard.ToString();
        }        


        Modified();
    }

    public bool IsAccepted()
    {
        if (IsApproved && Status.Value == _TransactionStatus.Approved.ToString()) return true;
        else return false;
    }
    #endregion
}
