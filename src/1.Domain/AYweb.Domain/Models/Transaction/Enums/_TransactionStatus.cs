namespace AYweb.Domain.Models.Transaction.Enums;

public enum _TransactionStatus
{
    AwaitingPayment = 0,
    AwaitingApproval = 1,
    Approved = 2,
    Failed = 3
}
