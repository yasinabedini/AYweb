namespace AYweb.Dal.Entities.Transaction;

public class Transaction
{
    public int Price { get; set; }
    public bool IsSuccess { get; set; }
    public DateTime PayDate { get; set; }
    public TransactionType TransactionType { get; set; }


}