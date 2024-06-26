﻿using AIPFramework.Commands;
using AYweb.Domain.Common.ValueObjects;
using AYweb.Domain.Models.Transaction.Enums;
using AYweb.Domain.Models.Transaction.ValueObjects;

namespace AYweb.Application.Models.Transaction.Commands.CreateTransaction;

public class CreateTransactionCommand:ICommand<long>
{
    public long UserId { get;  set; }

    public int Price { get;  set; }
    
    public required _TransactionType Type { get; set; }    

    public required string Description { get;  set; }
}
