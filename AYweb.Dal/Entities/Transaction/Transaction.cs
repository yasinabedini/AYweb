using AYweb.Dal.Entities.User;
using AYweb.Dal.Enums;
using System.Reflection.Metadata.Ecma335;

namespace AYweb.Dal.Entities.Transaction;

public class Transaction
{
    public int Id { get; set; }
    public int Price { get; set; }
    public string TransactionScreenShot { get; set; }
    public bool IsApproved { get; set; }
    public TransactionStatus Status { get; set; }
    public TransactionType Type { get; set; }
    public User.User User { get; set; }
    public int UserId { get; set; }
    public string Description { get; set; }
    public DateTime PayDate { get; set; }

    public Transaction() { }
    public Transaction(int price, int userId,_TransactionType type ,string description, string transactionScreenShot)
    {        
        Price = price;
        TransactionScreenShot = transactionScreenShot;
        Type = new TransactionType(type.ToString());
        UserId = userId;
        Status = new TransactionStatus(_TransactionStatus.AwaitingApproval.ToString());
        PayDate = DateTime.Now;
        Description = description;
    }

    public static Transaction Create(int price, int userId, _TransactionType type,string description ,string transactionScreenShot)
    {
        return new Transaction(price, userId, type, description,transactionScreenShot);
    }
}