using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Transaction.ValueObjects.Conversion
{
    public class TransactionStatusConversion : ValueConverter<TransactionStatus, string>
    {
        public TransactionStatusConversion() : base(c => c.Value, c => TransactionStatus.FromString(c)) { }
    }
}
