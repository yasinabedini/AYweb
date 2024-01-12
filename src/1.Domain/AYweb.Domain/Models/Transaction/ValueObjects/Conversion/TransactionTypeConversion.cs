using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AYweb.Domain.Models.Transaction.ValueObjects.Conversion;

public class TransactionTypeConversion:ValueConverter<TransactionType,string>
{
    public TransactionTypeConversion() : base(c => c.Value, c => TransactionType.FromString(c)) { }
}
