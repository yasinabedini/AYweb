using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Transaction.Commands.RejectTransaction
{
    public class RejectTransactionCommand:ICommand
    {
        public long Id { get; set; }
    }
}
