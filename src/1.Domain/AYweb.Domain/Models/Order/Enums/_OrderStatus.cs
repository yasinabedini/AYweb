using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Order.Enums;

internal enum _OrderStatus
{
    completing = 0,
    AwaitingPaymentConfirmation = 1,
    TransactionFailed = 2,
    TransactionConfirmed = 3,
    Packing = 4,
    Posted = 5
}
