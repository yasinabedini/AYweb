using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Transaction.Commands.AddTransactionLine
{   
    public class AddTransactionLineCommand:ICommand
    {
        public required long TransactionId { get;  set; }
        public required string Commodity { get;  set; }
        public required int Amount { get;  set; }
        public required int UnitPrice { get;  set; }
    }
}
